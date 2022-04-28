using AutoMapper;
using EnsureThat;
using Sketec.Application.Filters;
using Sketec.Application.Interfaces;
using Sketec.Application.Utils;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using Sketec.Core.Interfaces;
using Sketec.Core.Resources;
using Sketec.FileWriter.Excels;
using Sketec.FileWriter.Resources;
using Sketec.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sketec.Application.Resources;
using Sketec.Core.Specifications;
using Sketec.Core.Domains.Types;
using System.IO;
using Sketec.Application.Resources.Users;

namespace Sketec.Application.Services
{
    public class StatusTrackingService : ApplicationService, IStatusTrackingService
    {
        IMapper mapper;
        IWCUnitOfWork uow;
        IWCDapperRepository dapper;
        IWCQueryRepository queryRepo;
        IUserService userService;
        IWCRepository<NewRegist> dataRepo;
        IWCRepository<Core.Domains.FileInfo> fileRepo;
        IWCAzureBlobStorageService azureBlobStorageService;
        public StatusTrackingService(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            IUserService userService,
            IWCRepository<NewRegist> dataRepo,
            IWCRepository<Core.Domains.FileInfo> fileRepo,
            IWCQueryRepository queryRepo,
            IWCAzureBlobStorageService azureBlobStorageService)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.dapper = dapper;
            this.queryRepo = queryRepo;
            this.dataRepo = dataRepo;
            this.fileRepo = fileRepo;
            this.userService = userService;
            this.azureBlobStorageService = azureBlobStorageService;
        }
        public async Task<IEnumerable<StatusTrackingSearchResultDto>> GetStatusTrackings(StatusTrackingFilter filter)
        {
            var data = new List<StatusTrackingSearchResultDto>();
            var spec = new StatusTrackingLinqSearchSpec(filter ?? new StatusTrackingFilter(), Role, Team, UserName, Email);
            var list = await queryRepo.ListAsync(spec);

            var picData = await userService.GetUserData(new UserFilter());
            foreach (var item in list)
            {
                var pic = picData.Where(x => x.Email == item.PICEmail).FirstOrDefault();
                var user = new UserResultDto();
                if (pic != null)
                {
                    user = pic;
                }
                item.IsCanEdit = SketecUtils.IsCanEdit(item.Team, user.ManagerEmail, user.ReportToEmail2, user.ReportToEmail3, item.PICEmail, item.VerifierEmail
                                                        , user.Sec_Name, Role, Team, Email, Section, Department, user.Dep_Name);

                if (SketecUtils.RoleFilterDataNewRegist().Contains(Role) && item.IsCanEdit == false)
                {
                    // Nothing
                }
                else
                {
                    data.Add(item);
                }
            }

            return data;
        }

        public async Task<DownloadFileResponse> DownloadFile(Guid id)
        {
            var data = await fileRepo.GetByIdAsync(id);

            var file = await azureBlobStorageService.Download(data.Path);

            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);

                return new DownloadFileResponse
                {
                    Filename = data.FileName,
                    Data = ms.ToArray()
                };
            }

            
        }

        public async Task UploadExcel(Guid id, UploadNewRegistRequest request)
        {
            EnsureArg.IsNotNullOrEmpty(request.FileType, "FileType");
            EnsureArg.IsNotNullOrEmpty(request.Filename, "FileName");
            EnsureArg.IsNotNullOrEmpty(request.Data, "Data");

            var newRegist = await dataRepo.GetByIdAsync(id);

            var byteArray = Convert.FromBase64String(request.Data);
            var spec = new FileInfoSearchSpec(new FileInfoFilter { RefId = id, FileType = request.FileType });
            var list = await fileRepo.ListAsync(spec);

            if (list.Any())
            {
                var data = await fileRepo.GetByIdAsync(list.FirstOrDefault().Id);
                //data.FileData = byteArray;
                data.FileName = request.Filename;

                await azureBlobStorageService.Upload(data.Path, byteArray);
            }
            else
            {
                var fileName = $"{Path.GetRandomFileName()}";
                var path = $"eplantation/NewRegist/{newRegist.RegistId}/{fileName}";
                var data = new Core.Domains.FileInfo(request.Filename)
                {
                    FileType = request.FileType,
                    RefId = id,
                    Description = newRegist.RegistId,
                    Path = path
                };

                await fileRepo.AddAsync(data);
                await azureBlobStorageService.Upload(path, byteArray);
            }

            await uow.SaveAsync();
        }
    }
}
