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

            if (dataNewRegist.ContractType != "Rental") {
                Guid plantation = await GetCreatePlantation(id);
            }
            // create plantaion



            //var specPlantation = new PlantationLinqSearchSpec(new PlantationFilter() { NewRegistID = id });
            //var listPlantation = await queryRepo.ListAsync(specPlantation);

            //if (listPlantation.Count == 0) {
            //    var runningNumber = await runningService.GetRunningNumber("Plantation"+ dataNewRegist.ContractType, DateTime.Now.Year, DateTime.Now.ToString("MM"));

            //    var data = new Core.Domains.Plantation()
            //    {
            //        Title = dataNewRegist.Title,
            //        PlantationNo = runningNumber,
            //        Latitude = dataNewRegist.Latitude,
            //        Longitude = dataNewRegist.Longitude,
            //        NewRegistId = dataNewRegist.Id , 
            //        Contract = dataNewRegist.Contract,
            //        PIC = dataNewRegist.PIC,
            //        ContractType = dataNewRegist.ContractType,
            //        Village = dataNewRegist.Village,
            //        District = dataNewRegist.District,
            //        Province = dataNewRegist.Province,
            //        SubDistrict = dataNewRegist.SubDistrict,
            //        Remark = dataNewRegist.Remark,
            //        Zone = dataNewRegist.Zone,
            //        MOUType = dataNewRegist.MOUType,
            //        Seedling = dataNewRegist.Seedling,
            //        IsActive = true,
            //        IsDelete = false
            //    };

            //    await dataRepo.AddAsync(data);
            //}
            await uow.SaveAsync();

        }
        private async Task<Guid> GetCreatePlantation(Guid newRegisId)
        {
            var specNewRegist = new NewRegistSearchByIdSpec(newRegisId).InCludeSubNewRegists();
            var dataNewRegist = await dataRepoNewRegist.GetBySpecAsync(specNewRegist);

            var specPlantation = new PlantationLinqSearchSpec(new PlantationFilter() { NewRegistID = newRegisId });
            var listPlantation = await queryRepo.ListAsync(specPlantation);

            Guid plantationId;
            if (listPlantation.Count == 0)
            {
                var runningNumber = await runningService.GetRunningNumber("Plantation" + dataNewRegist.ContractType, DateTime.Now.Year, DateTime.Now.ToString("MM"));

                var data = new Core.Domains.Plantation()
                {
                    Id = new Guid(),
                    Title = dataNewRegist.Title,
                    PlantationNo = runningNumber,
                    Latitude = dataNewRegist.Latitude,
                    Longitude = dataNewRegist.Longitude,
                    NewRegistId = dataNewRegist.Id,
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
                    Verifier = dataNewRegist.Verifier,
                    IsActive = true,
                    IsDelete = false
                };

                await dataRepo.AddAsync(data);

                await uow.SaveAsync();

                plantationId = data.Id;
            }
            else {
                plantationId = listPlantation[0].Id.Value;
            }

            return plantationId;
        }

        public async Task UploadAmortizedExcel(Guid id, UploadPlantationRequest request)
        {
            EnsureArg.IsNotNullOrEmpty(request.FileType, "FileType");
            EnsureArg.IsNotNullOrEmpty(request.Filename, "FileName");
            EnsureArg.IsNotNullOrEmpty(request.Data, "Data");

            // Read File into Table PlantationAmortized
            var byteArray = Convert.FromBase64String(request.Data);
            var newRegistData = PlantationAmortizedFileReader.GetNewPlantationAmortized(byteArray);
            if (newRegistData == null)
            {
                return;
            }
            if (newRegistData.Any())
            {
                //if (dataNewRegist.ContractType == "Rental") { 

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


                //}
                // create Plantation
                //Guid plantationId = await GetCreatePlantation(id);

                //var specNewPlantation = new NewPlantationSearchByIdSpec(plantationId).InCludeNewPlantationAmortized();
                //var dataPlant = await dataRepo.GetBySpecAsync(specNewPlantation);

                //if (dataPlant.PlantationAmortizeds.Count > 0)
                //{
                //    foreach (var item in dataPlant.PlantationAmortizeds)
                //    {
                //        dataPlant.RemovePlantationAmortized(item);
                //    }
                //}

                //foreach (var item in newRegistData)
                //{
                //    //item.PlantationId = plantationId;
                //    dataPlant.AddPlantationAmortized(item);
                //}

                //// -- Read File into Table PlantationAmortized
                //// add FileInfo
                //var dataFile = new Core.Domains.FileInfo(request.Filename)
                //{
                //    FileType = request.FileType,
                //    RefId = plantationId,
                //    FileData = byteArray,
                //};

                //await fileRepo.AddAsync(dataFile);
            }
            // add FileInfo
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

        public async Task<DownloadFileResponse> DownloadPlanYieldFile(Guid id)
        {
            var data = await fileRepo.GetByIdAsync(id);
            return new DownloadFileResponse
            {
                Filename = data.FileName,
                Data = data.FileData
            };
        }

        public async Task UploadPlanYieldExcel(Guid id, UploadPlantationRequest request)
        {
            EnsureArg.IsNotNullOrEmpty(request.FileType, "FileType");
            EnsureArg.IsNotNullOrEmpty(request.Filename, "FileName");
            EnsureArg.IsNotNullOrEmpty(request.Data, "Data");

            // Read File into Table PlantationAmortized
            var byteArray = Convert.FromBase64String(request.Data);
            var newRegistData = PlantationAmortizedFileReader.GetNewPlantationAmortized(byteArray);
            if (newRegistData == null)
            {
                return;
            }
            if (newRegistData.Any())
            {
                Guid plantationId = await GetCreatePlantation(id);

                //var specNewPlantation = new NewPlantationSearchByIdSpec(plantationId).InCludeNewPlantationAmortized();
                //var dataPlant = await dataRepo.GetBySpecAsync(specNewPlantation);

                //if (dataPlant.PlantationAmortizeds.Count > 0)
                //{
                //    foreach (var item in dataPlant.PlantationAmortizeds)
                //    {
                //        dataPlant.RemovePlantationAmortized(item);
                //    }
                //}

                //foreach (var item in newRegistData)
                //{
                //    //item.PlantationId = plantationId;
                //    dataPlant.AddPlantationAmortized(item);
                //}

                //// -- Read File into Table PlantationAmortized
                //// add FileInfo
                var dataFile = new Core.Domains.FileInfo(request.Filename)
                {
                    FileType = request.FileType,
                    RefId = plantationId,
                    FileData = byteArray,
                };

                await fileRepo.AddAsync(dataFile);
            }
            // add FileInfo
            await uow.SaveAsync();


        }
    }
}
