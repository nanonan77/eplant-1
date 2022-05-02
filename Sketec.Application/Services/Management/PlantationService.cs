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
using Sketec.FileReader.Excels;

namespace Sketec.Application.Services
{
    public class PlantationService : ApplicationService, IPlantationService
    {
        IMapper mapper;
        IWCUnitOfWork uow;
        IWCDapperRepository dapper;
        IWCQueryRepository queryRepo;
        IWCRepository<Plantation> dataRepo;
        IWCRepository<Core.Domains.FileInfo> fileRepo;
        IWCRepository<NewRegist> dataRepoNewRegist;
        IRunningNumberService runningService;


        public PlantationService(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            IWCRepository<Plantation> dataRepo,
            IWCRepository<Core.Domains.FileInfo> fileRepo,
            IWCRepository<NewRegist> dataRepoNewRegist,
            IWCQueryRepository queryRepo,
            IRunningNumberService runningService)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.dapper = dapper;
            this.queryRepo = queryRepo;
            this.dataRepo = dataRepo;
            this.fileRepo = fileRepo;
            this.dataRepoNewRegist = dataRepoNewRegist;
            this.runningService = runningService;
        }
        public async Task<IEnumerable<PlantationSearchResultDto>> GetPlantations(PlantationFilter filter)
        {
            var spec = new PlantationLinqSearchSpecLinqSearchSpec(filter ?? new PlantationFilter());
            var list = await queryRepo.ListAsync(spec);

            return list;

        }

        public async Task<DownloadFileResponse> DownloadFile(Guid id)
        {
            var data = await fileRepo.GetByIdAsync(id);
            return new DownloadFileResponse
            {
                Filename = data.FileName,
                Data = data.FileData
            };
        }

        public async Task UploadExcel(Guid id, UploadPlantationRequest request)
        {
            EnsureArg.IsNotNullOrEmpty(request.FileType, "FileType");
            EnsureArg.IsNotNullOrEmpty(request.Filename, "FileName");
            EnsureArg.IsNotNullOrEmpty(request.Data, "Data");

            var byteArray = Convert.FromBase64String(request.Data);
            var spec = new FileInfoSearchSpec(new FileInfoFilter { RefId = id, FileType = request.FileType });
            var list = await fileRepo.ListAsync(spec);

            if (list.Any())
            {
                var data = await fileRepo.GetByIdAsync(list.FirstOrDefault().Id);
                data.FileData = byteArray;
                data.FileName = request.Filename;
            }
            else
            {
                var data = new Core.Domains.FileInfo(request.Filename)
                {
                    FileType = request.FileType,
                    RefId = id,
                    FileData = byteArray,
                };

                await fileRepo.AddAsync(data);
            }

            // create plantaion

            var specNewRegist = new NewRegistSearchByIdSpec(id).InCludeSubNewRegists();
            var dataNewRegist = await dataRepoNewRegist.GetBySpecAsync(specNewRegist);

            var specPlantation = new PlantationLinqSearchSpec(new PlantationFilter() { NewRegistID = id });
            var listPlantation = await queryRepo.ListAsync(specPlantation);

            if (listPlantation.Count == 0) {

                //var specAll = new PlantationLinqSearchSpec(new PlantationFilter());
                //var listAll = await queryRepo.ListAsync(specAll);


                //var name = dataNewRegist.ContractType == "Rental" ? "PREN" : dataNewRegist.ContractType == "MOU" ? "PMOU" : "PVIP";

                //listAll = listAll.Where(item => item.PlantationNo.Contains(name.ToString())).ToList();

                //var currentNo = listAll.Count;

                //var plantationNo = name + DateTime.Now.ToString("yyyyMMdd") + (currentNo > 9 ? (currentNo + 1).ToString() : "0" + (currentNo + 1).ToString());
                var runningNumber = await runningService.GetRunningNumber("Plantation"+ dataNewRegist.ContractType, DateTime.Now.Year, DateTime.Now.ToString("MM"));

                var data = new Core.Domains.Plantation()
                {
                    Title = dataNewRegist.Title,
                    PlantationNo = runningNumber,
                    Latitude = dataNewRegist.Latitude,
                    Longitude = dataNewRegist.Longitude,
                    NewRegistId = dataNewRegist.Id , 
                    Contract = dataNewRegist.Contract,
                    PIC = dataNewRegist.PIC,
                    ContractType = dataNewRegist.ContractType,
                    Village = dataNewRegist.Village,
                    District = dataNewRegist.District,
                    Province = dataNewRegist.Province,
                    SubDistrict = dataNewRegist.SubDistrict,
                    Remark = dataNewRegist.Remark,
                    Zone = dataNewRegist.Zone,
                    MOUType = dataNewRegist.MOUType,
                    Seedling = dataNewRegist.Seedling,
                    IsActive = true,
                    IsDelete = false
                };

                await dataRepo.AddAsync(data);
            }

            await uow.SaveAsync();
            //public async Task<IEnumerable<StatusTrackingSearchResultDto>> GetStatusTracking(StatusTrackingFilter filter)
            //{
            //    var spec = new StatusTrackingSearchSpec(filter ?? new StatusTrackingFilter());
            //    var list = await dataRepo.ListAsync(spec);
            //    return mapper.Map<List<NewRegist>, IEnumerable<StatusTrackingSearchResultDto>>(list);
            //}

        }
        public async Task UploadAmortizedExcel(Guid id, UploadPlantationRequest request)
        {
            EnsureArg.IsNotNullOrEmpty(request.FileType, "FileType");
            EnsureArg.IsNotNullOrEmpty(request.Filename, "FileName");
            EnsureArg.IsNotNullOrEmpty(request.Data, "Data");

            var byteArray = Convert.FromBase64String(request.Data);
            var spec = new FileInfoSearchSpec(new FileInfoFilter { RefId = id, FileType = request.FileType });
            var list = await fileRepo.ListAsync(spec);

            // Read File into Table PlantationAmortized
            var newRegistData = PlantationAmortizedFileReader.GetNewPlantationAmortized(byteArray,id);
            if (newRegistData == null)
            {
                return;
            }
            if (newRegistData.Any())
            {
                var specNewPlantation = new NewPlantationSearchByIdSpec(id).InCludeSubNewPlantations();
                var data = await dataRepo.GetBySpecAsync(specNewPlantation);

                if (data.PlantationAmortizeds.Count > 0)
                {
                    foreach (var item in data.PlantationAmortizeds) {
                        data.RemovePlantationAmortized(item);
                    }
                }

                foreach (var item in newRegistData)
                {
                    item.PlantationId = id;
                    data.AddPlantationAmortized(item);
                }
            }
            // -- Read File into Table PlantationAmortized

            if (list.Any())
            {
                var data = await fileRepo.GetByIdAsync(list.FirstOrDefault().Id);
                data.FileData = byteArray;
                data.FileName = request.Filename;
            }
            else
            {
                var data = new Core.Domains.FileInfo(request.Filename)
                {
                    FileType = request.FileType,
                    RefId = id,
                    FileData = byteArray,
                };

                await fileRepo.AddAsync(data);
            }
        await uow.SaveAsync();
        }

        public async Task<DownloadFileResponse> DownloadAmortizedFile(Guid id)
        {
            var data = await fileRepo.GetByIdAsync(id);
            return new DownloadFileResponse
            {
                Filename = data.FileName,
                Data = data.FileData
            };
        }
    }
}
