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
        public NewPlantationService(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            ISharePointService sharePointService,
            IWCRepository<Plantation> dataRepo,
            IWCRepository<SubPlantation> dataSubRepo,
            IWCRepository<NewRegistImagePath> imgRepo,
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
        }

        public async Task<NewPlantationDto> GetNewPlantation(Guid newRegisID)
        {

            var spec = new NewPlantationSearchByIdSpec(newRegisID).InCludeSubNewPlantations();
            var data = await dataRepo.GetBySpecAsync(spec);
            var result = mapper.Map<NewPlantationDto>(data);

            var specImg = new NewPlantationImagePathSearchByPlantationIdSpec(result.PlantationId);
            var dataImg = await imgRepo.ListAsync(specImg);
            var resultImg = mapper.Map<List<NewRegistImagePath>, IEnumerable<NewRegistImagePathDto>>(dataImg);

            //foreach(var item in resultImg)
            //{
            //    item.Base64 = sharePointService.GetImage(item.ImageInfo);
            //}
            result.NewRegistImagePaths = resultImg;
            return result;
        }

        public async Task UpdateNewPlantation(Guid newRegisID, NewPlantationUpdateRequest request, BindPropertyCollection httpPatchBindProperty = null)
        {
            Ensure.Any.IsNotNull(request, "NewRegistUpdateRequest");

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

                await uow.SaveAsync();
            }
        }
    }
}
