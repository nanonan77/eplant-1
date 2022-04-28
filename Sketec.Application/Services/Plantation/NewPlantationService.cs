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
using Sketec.FileWriter.Pdf;
using System.Globalization;
using System.IO;
using Sketec.Core.Resources.Email;

namespace Sketec.Application.Services
{
    public class NewPlantationService : ApplicationService, INewPlantationService
    {
        IMapper mapper;
        IWCUnitOfWork uow;
        IWCDapperRepository dapper;
        IWCQueryRepository queryRepo;
        ISharePointService sharePointService;
        IWCRepository<Plantation> dataRepo;
        IWCRepository<SubPlantation> dataSubRepo;
        IWCRepository<NewRegistImagePath> imgRepo;
        IWCRepository<Core.Domains.FileInfo> fileInfoRepo;
        IFileInfoService fileService;
        IWCAzureBlobStorageService azureBlobStorageService;
        IEmailService emailService;
        IUserService userService;
        public NewPlantationService(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            ISharePointService sharePointService,
            IWCRepository<Plantation> dataRepo,
            IWCRepository<SubPlantation> dataSubRepo,
            IWCRepository<NewRegistImagePath> imgRepo,
            IWCRepository<Core.Domains.FileInfo> fileInfoRepo,
            IUserService userService,
            IFileInfoService fileService,
            IEmailService emailService,
            IWCAzureBlobStorageService azureBlobStorageService,
            IWCQueryRepository queryRepo)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.dapper = dapper;
            this.sharePointService = sharePointService;
            this.queryRepo = queryRepo;
            this.dataRepo = dataRepo;
            this.dataSubRepo = dataSubRepo;
            this.imgRepo = imgRepo;
            this.fileService = fileService;
            this.userService = userService;
            this.fileInfoRepo = fileInfoRepo;
            this.emailService = emailService;
            this.azureBlobStorageService = azureBlobStorageService;
        }

        public async Task<IEnumerable<NewPlantationDto>> GetPlantation(PlantationFilter filter)
        {
            var spec = new PlnatationSearchSpec(filter ?? new PlantationFilter()).InCludeUnplans();
            var data = await dataRepo.ListAsync(spec);
            return mapper.Map<List<Plantation>, IEnumerable<NewPlantationDto>>(data);
        }

        public async Task<NewPlantationDto> GetNewPlantation(Guid newRegisID)
        {

            var spec = new NewPlantationSearchByIdSpec(newRegisID).InCludeSubNewPlantations();
            var data = await dataRepo.GetBySpecAsync(spec);
            var result = mapper.Map<NewPlantationDto>(data);
            result.IsCanEdit = true;

            var specImg = new NewPlantationImagePathSearchByPlantationIdSpec(result.PlantationNo);
            var dataImg = await imgRepo.ListAsync(specImg);
            var resultImg = mapper.Map<List<NewRegistImagePath>, IEnumerable<NewRegistImagePathDto>>(dataImg);

            //foreach(var item in resultImg)
            //{
            //    item.Base64 = sharePointService.GetImage(item.ImageInfo);
            //}
            result.NewPlantationImagePaths = resultImg;
            return result;
        }

        public async Task UpdateNewPlantation(Guid newRegisID, NewPlantationDto request, BindPropertyCollection httpPatchBindProperty = null)
        {
            Ensure.Any.IsNotNull(request, "NewPlantaionUpdateRequest");

            var spec = new NewPlantationSearchByIdSpec(newRegisID);
            var data = await dataRepo.GetBySpecAsync(spec);

            if (data != null)
            {
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Title)))
                    data.Title = request.Title;

                //if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.PlantationNo)))
                //    data.PlantationNo = request.PlantationNo;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Status)))
                    data.Status = request.Status;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.ContractType)))
                    data.ContractType = request.ContractType;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.PIC)))
                    data.PIC = request.PIC;


                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.ContractYear)))
                    data.ContractYear = request.ContractYear;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.ContractMonth)))
                    data.ContractMonth = request.ContractMonth;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Contract)))
                    data.Contract = request.Contract;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.ContractId)))
                    data.ContractId = request.ContractId;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Province)))
                    data.Province = request.Province;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.ContractStartDate)))
                    data.ContractStartDate = request.ContractStartDate;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.ContractEndDate)))
                    data.ContractEndDate = request.ContractEndDate;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.District)))
                    data.District = request.District;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.SubDistrict)))
                    data.SubDistrict = request.SubDistrict;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Village)))
                    data.Village = request.Village;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.RentalArea)))
                    data.RentalArea = request.RentalArea;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.ProductiveArea)))
                    data.ProductiveArea = request.ProductiveArea;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.PotentialArea)))
                    data.PotentialArea = request.PotentialArea;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Latitude)))
                    data.Latitude = request.Latitude;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Longitude)))
                    data.Longitude = request.Longitude;


                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Remark)))
                    data.Remark = request.Remark;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Zone)))
                    data.Zone = request.Zone;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.MOUType)))
                    data.MOUType = request.MOUType;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Seedling)))
                    data.Seedling = request.Seedling;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.IsActive)))
                    data.IsActive = request.IsActive ?? true;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.IsDelete)))
                    data.IsDelete = request.IsDelete ?? false;

                var specInfo = new FileInfoSearchSpec(new FileInfoFilter { RefId = request.Id, FileType = "Other" });
                var list = await fileInfoRepo.ListAsync(specInfo);
                //foreach (var item in list)
                //{
                //    item.IsActive = false;
                //}

                if (request.NewPlantationImageOther != null){

                    foreach (var item in request.NewPlantationImageOther)
                    {
                        var detail = list.FirstOrDefault(f => f.Id == item.Id);
                        if (detail != null)
                        {
                            detail.IsActive = true;
                        }
                        else
                        {
                            var fileName = $"{Path.GetRandomFileName()}";
                            var path = $"eplantation/NewPlantation/{request.Id}/Other/{fileName}";
                            //await azureBlobStorageService.Upload(path, item.Base64);

                            detail = new Core.Domains.FileInfo(item.FileName)
                            {
                                FileType = "Other",
                                RefId = request.Id,
                                Path = path
                            };
                            await fileInfoRepo.AddAsync(detail);
                        }

                    }
                }

                

                await uow.SaveAsync();

                // Send Mail
                if (request.IsDelete != true) {
                    var status = request.IsActive ?? false ? "Active" : "Cancel";
                    var statusValue = request.Status;
                    if (status == "Cancel" && statusValue == "Completed") {
                        var emailCC = new List<string>();
                        //emailCC.Add(data.Verifier);
                        //emailCC.Add(Email);

                        var picData = await userService.GetUserData(new UserFilter { Email = data.PIC });
                        if (picData.Any()) {
                            var name = "";
                            var currentUser = await userService.GetUserData(new UserFilter { Email = Email });
                            if (currentUser != null)
                                name = currentUser.FirstOrDefault().E_FullName;

                            var content = $"เรียน : {picData.FirstOrDefault().E_FullName}<br/>";
                            content += $"แจ้งเตือน {status} แปลงสวนไม้ {data.ContractType} {data.Title}<br/>";
                            content += $"โดย {name}<br/><br/><br/>";
                            content += $"Best regards,<br/>";
                            content += $"{name}";

                            //await emailService.SendEmailAsync(new SendEmailRequest
                            //{
                            //    EmailsTo = new string[] { data.PIC },
                            //    EmailsCC = emailCC,
                            //    Subject = $"[New Plantation] {status} {data.ContractType}",
                            //    Content = content
                            //});
                        }
                    }
                }
                // Send Mail
            }
        }

        public async Task<IEnumerable<FileInfoDto>> GetNewPlantationForExportPdfImageOther(Guid newPlantationID)
        {
            var other = await fileService.GetFileInfos(new FileInfoFilter { RefId = newPlantationID, FileType = "Other" });
            foreach (var item in other)
            {
                try
                {
                    var img = await azureBlobStorageService.Download(item.Path);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.CopyTo(ms);
                        item.Base64 = ms.ToArray();
                    }
                }
                catch (Exception ex)
                {

                }
            }

            return other;
        }
    }
}
