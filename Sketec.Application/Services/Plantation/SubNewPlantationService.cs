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
        public SubNewPlantationService(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            ISharePointService sharePointService,
            IWCRepository<Plantation> dataRepo,
            IWCRepository<SubPlantation> dataSubRepo,
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
        }

        public async Task<SubNewPlantationDto> GetSubNewPlantation(Guid subNewRegisID)
        {

            var spec = new SubNewPlantationSearchByIdSpec(subNewRegisID);
            var data = await dataSubRepo.GetBySpecAsync(spec);


            //var specSub = new NewRegistSearchBySubRegistIdSpec("R02-2112003-01");
            //var dataSub = await dataRepo.GetBySpecAsync(specSub);

            var result = mapper.Map<SubNewPlantationDto>(data);

            var specImg = new NewPlantationImagePathSearchBySubPlantationIdSpec(result.SubPlantationNo);
            var dataImg = await imgRepo.ListAsync(specImg);
            var resultImg = mapper.Map<List<NewRegistImagePath>, IEnumerable<NewRegistImagePathDto>>(dataImg);

            //foreach (var item in resultImg)
            //{
            //    item.Base64 = sharePointService.GetImage(item.ImageInfo);
            //}
            result.SubNewRegistImagePaths = resultImg;

            return result;

        }
        public async Task CreateSubNewPlantation(SubNewPlantationCreateRequest request)
        {
            try
            {

                Ensure.Any.IsNotNull(request, "SubNewPlantationCreateRequest");

                var spec = new NewPlantationSearchByIdSpec(request.PlantationId).InCludeSubNewPlantations();
                var data = await dataRepo.GetBySpecAsync(spec);

                var runningNumber = await runningService.GetRunningNumber("SubPlantation", null, data.PlantationNo);
                
                //var currentNo = data.SubPlantations.Count == 0 ? 0 : data.SubPlantations.Select(o => o.SubPlantationNo.Replace($"{data.PlantationNo}-", string.Empty)).Select(o => Convert.ToInt32(o)).Max();
                
                //string no = currentNo > 9 ? (currentNo + 1).ToString(): "0" + (currentNo + 1).ToString();
                //var data = await GetMasterActivitys(new MasterActivityFilter { MasterActivityTypeId = request.MasterActivityTypeId });
                //var codeMax = data.OrderByDescending(x => x.ActivityCode).FirstOrDefault();
                //request.ActivityCode = codeMax.ActivityGroup + (Convert.ToInt32(codeMax.ActivityCode.Substring(1)) + 1).ToString().PadRight(2, '0');
                data.AddSubPlantation(new SubPlantation
                {
                    //Id = Guid.NewGuid(),
                    Title = request.Title,
                    PlantationNo = data.PlantationNo,
                    SubPlantationNo = runningNumber,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    Area = request.Area,
                    Seedling = request.Seedling,
                    Remark = request.SubPlantationNo,
                    PlantYear = request.PlantYear,
                    HarvestingMonth = request.HarvestingMonth,
                    HarvestingYear = request.HarvestingYear,
                    Volume = request.Volume,
                    VipPrice = request.VipPrice,
                    ActualVolume = request.ActualVolume,
                    ActualVipPrice = request.ActualVipPrice,
                    IsActive = true,
                    IsDelete = false
                });
                await uow.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task UpdateSubNewPlantation(Guid subNewRegisID, SubNewPlantationUpdateRequest request, BindPropertyCollection httpPatchBindProperty = null)
        {
            Ensure.Any.IsNotNull(request, "SubNewRegistUpdateRequest");

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


                await uow.SaveAsync();
            }
        }
    }
}
