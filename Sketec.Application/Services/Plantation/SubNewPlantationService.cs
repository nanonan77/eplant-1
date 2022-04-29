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

namespace Sketec.Application.Services
{
    public class SubNewPlantationService : ApplicationService, ISubNewPlantationService
    {
        IMapper mapper;
        IWCUnitOfWork uow;
        IWCDapperRepository dapper;
        IWCQueryRepository queryRepo;
        ISharePointService sharePointService;
        IWCRepository<Plantation> dataRepo;
        IWCRepository<SubPlantation> dataSubRepo;
        IWCRepository<NewRegistImagePath> imgRepo;
        IRunningNumberService runningService;
        IWCRepository<Core.Domains.FileInfo> fileInfoRepo;
        IFileInfoService fileService;
        IWCAzureBlobStorageService azureBlobStorageService;
        public SubNewPlantationService(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            ISharePointService sharePointService,
            IWCRepository<Plantation> dataRepo,
            IWCRepository<SubPlantation> dataSubRepo,
            IWCRepository<Core.Domains.FileInfo> fileInfoRepo,
            IFileInfoService fileService,
            IWCAzureBlobStorageService azureBlobStorageService,
            IWCRepository<NewRegistImagePath> imgRepo,
            IWCQueryRepository queryRepo,
            IRunningNumberService runningService)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.dapper = dapper;
            this.queryRepo = queryRepo;
            this.sharePointService = sharePointService;
            this.dataRepo = dataRepo;
            this.dataSubRepo = dataSubRepo;
            this.imgRepo = imgRepo;
            this.runningService = runningService;
            this.fileService = fileService;
            this.fileInfoRepo = fileInfoRepo;
            this.azureBlobStorageService = azureBlobStorageService;
        }

        public async Task<SubNewPlantationDto> GetSubNewPlantation(Guid subNewRegisID)
        {
            var spec = new SubNewPlantationSearchByIdSpec(subNewRegisID);
            var data = await dataSubRepo.GetBySpecAsync(spec);


            //var specSub = new NewRegistSearchBySubRegistIdSpec("R02-2112003-01");
            //var dataSub = await dataRepo.GetBySpecAsync(specSub);

            var result = mapper.Map<SubNewPlantationDto>(data);
            result.IsCanEdit = true;

            var specImg = new NewPlantationImagePathSearchBySubPlantationIdSpec(result.SubPlantationNo);
            var dataImg = await imgRepo.ListAsync(specImg);
            var resultImg = mapper.Map<List<NewRegistImagePath>, IEnumerable<NewRegistImagePathDto>>(dataImg);

            //foreach (var item in resultImg)
            //{
            //    item.Base64 = sharePointService.GetImage(item.ImageInfo);
            //}
            result.SubNewPlantationImagePaths = resultImg;

            return result;

        }
        public async Task CreateSubNewPlantation(SubNewPlantationDto request)
        {
            try
            {
                Ensure.Any.IsNotNull(request, "SubNewPlantationCreateRequest");

                // check MOU Seeding less 
                var specPlantation = new NewPlantationSearchByIdSpec(request.PlantationId).InCludeSubNewPlantations();
                var dataPlantation = await dataRepo.GetBySpecAsync(specPlantation);
                var resultPlantation = mapper.Map<NewPlantationDto>(dataPlantation);

                if (resultPlantation.ContractType == "MOU")
                {
                    var listSubPlantaions = resultPlantation.SubPlantations;
                    int? sumInSubPlantations = 0;
                    foreach (var item in listSubPlantaions)
                    {
                        if (item.Id != request.Id)
                        {
                            sumInSubPlantations += item.Seedling;
                        }
                    }

                    if (resultPlantation.Seedling != null && request.Seedling != null)
                    {
                        if (sumInSubPlantations + request.Seedling > resultPlantation.Seedling)
                        {
                            throw new ApplicationException("Seeding must be less than Seeding Plan of Plantation");
                        }
                    }
                    else
                    {
                        if (resultPlantation.Seedling == null && request.Seedling != null)
                        {
                            throw new ApplicationException("Seeding must be null");
                        }
                    }
                }
                // check MOU Seeding less 

                //var spec = new NewPlantationSearchByIdSpec(request.PlantationId).InCludeSubNewPlantations();
                //var data = await dataRepo.GetBySpecAsync(spec);

                var runningNumber = await runningService.GetRunningNumber("SubPlantation", null, dataPlantation.PlantationNo);

                //var currentNo = data.SubPlantations.Count == 0 ? 0 : data.SubPlantations.Select(o => o.SubPlantationNo.Replace($"{data.PlantationNo}-", string.Empty)).Select(o => Convert.ToInt32(o)).Max();

                //string no = currentNo > 9 ? (currentNo + 1).ToString(): "0" + (currentNo + 1).ToString();
                //var data = await GetMasterActivitys(new MasterActivityFilter { MasterActivityTypeId = request.MasterActivityTypeId });
                //var codeMax = data.OrderByDescending(x => x.ActivityCode).FirstOrDefault();
                //request.ActivityCode = codeMax.ActivityGroup + (Convert.ToInt32(codeMax.ActivityCode.Substring(1)) + 1).ToString().PadRight(2, '0');

                var dataSubPlantation = new SubPlantation()
                {
                    Title = request.Title,
                    PlantationNo = dataPlantation.PlantationNo,
                    SubPlantationNo = runningNumber,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    Area = request.Area,
                    Seedling = request.Seedling,
                    Remark = request.Remark,
                    PlantYear = request.PlantYear,
                    HarvestingMonth = request.HarvestingMonth,
                    HarvestingYear = request.HarvestingYear,
                    Volume = request.Volume,
                    VipPrice = request.VipPrice,
                    ActualVolume = request.ActualVolume,
                    ActualVipPrice = request.ActualVipPrice,
                    IsActive = true,
                    IsDelete = false
                };

                dataPlantation.AddSubPlantation(dataSubPlantation);

                await uow.SaveAsync();
                //data.AddSubPlantation(new SubPlantation
                //{
                //    //Id = Guid.NewGuid(),

                //});

                var specInfo = new FileInfoSearchSpec(new FileInfoFilter { RefId = dataSubPlantation.Id, FileType = "Other" });
                var list = await fileInfoRepo.ListAsync(specInfo);
                foreach (var item in list)
                {
                    item.IsActive = false;
                }
                if (request.SubNewPlantationImageOther != null)
                {
                    foreach (var item in request.SubNewPlantationImageOther)
                    {
                        var detail = list.FirstOrDefault(f => f.Id == item.Id);
                        if (detail != null)
                        {
                            detail.IsActive = true;
                        }
                        else
                        {
                            var fileName = $"{Path.GetRandomFileName()}";
                            var path = $"eplantation/NewPlantation/{dataSubPlantation.Id}/Other/{fileName}";
                            //await azureBlobStorageService.Upload(path, item.Base64);

                            detail = new Core.Domains.FileInfo(item.FileName)
                            {
                                FileType = "Other",
                                RefId = dataSubPlantation.Id,
                                Path = path
                            };
                            await fileInfoRepo.AddAsync(detail);
                        }

                    }
                    await uow.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task UpdateSubNewPlantation(Guid subNewRegisID, SubNewPlantationDto request, BindPropertyCollection httpPatchBindProperty = null)
        {
            Ensure.Any.IsNotNull(request, "SubNewRegistUpdateRequest");

            // check MOU Seeding less 

            var specPlantation = new NewPlantationSearchByIdSpec(request.PlantationId).InCludeSubNewPlantations();
            var dataPlantation = await dataRepo.GetBySpecAsync(specPlantation);
            var resultPlantation = mapper.Map<NewPlantationDto>(dataPlantation);

            if (resultPlantation.ContractType == "MOU")
            {
                var listSubPlantaions = resultPlantation.SubPlantations;
                int? sumInSubPlantations = 0;
                foreach (var item in listSubPlantaions)
                {
                    if (item.Id != request.Id)
                    {
                        sumInSubPlantations += item.Seedling;
                    }
                }

                if (resultPlantation.Seedling != null && request.Seedling != null)
                {
                    if (sumInSubPlantations + request.Seedling > resultPlantation.Seedling)
                    {
                        throw new ApplicationException("Seeding must be less than Seeding Plan of Plantation");
                    }
                }
                else
                {
                    if (resultPlantation.Seedling == null && request.Seedling != null)
                    {
                        throw new ApplicationException("Seeding must be null");
                    }
                }
            }
            // check MOU Seeding less 

            var spec = new SubNewPlantationSearchByIdSpec(subNewRegisID);
            var data = await dataSubRepo.GetBySpecAsync(spec);
            //var activity = await dataRepo.GetByIdAsync(request.Id);
            if (data != null)
            {
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Title)))
                    data.Title = request.Title;

                //if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.PlantationNo)))
                //    data.PlantationNo = request.PlantationNo;

                //if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.SubPlantationNo)))
                //    data.SubPlantationNo = request.SubPlantationNo;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Latitude)))
                    data.Latitude = request.Latitude;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Longitude)))
                    data.Longitude = request.Longitude;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Area)))
                    data.Area = request.Area;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Seedling)))
                    data.Seedling = request.Seedling;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Remark)))
                    data.Remark = request.Remark;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.PlantYear)))
                    data.PlantYear = request.PlantYear;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.HarvestingMonth)))
                    data.HarvestingMonth = request.HarvestingMonth;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.HarvestingYear)))
                    data.HarvestingYear = request.HarvestingYear;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Volume)))
                    data.Volume = request.Volume;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.VipPrice)))
                    data.VipPrice = request.VipPrice;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.ActualVolume)))
                    data.ActualVolume = request.ActualVolume;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.ActualVipPrice)))
                    data.ActualVipPrice = request.ActualVipPrice;

                var specInfo = new FileInfoSearchSpec(new FileInfoFilter { RefId = request.Id, FileType = "Other" });
                var list = await fileInfoRepo.ListAsync(specInfo);
                //foreach (var item in list)
                //{
                //    item.IsActive = false;
                //}

                if (request.SubNewPlantationImageOther != null)
                {
                    foreach (var item in request.SubNewPlantationImageOther)
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
            }
        }

        public async Task<IEnumerable<FileInfoDto>> GetSubNewPlantationForExportPdfImageOther(Guid newPlantationID)
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
