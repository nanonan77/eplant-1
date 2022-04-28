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
    public class MasterConfigurationService : ApplicationService, IMasterConfigurationService
    {
        IMapper mapper;
        IWCUnitOfWork uow;
        IWCDapperRepository dapper;
        IWCQueryRepository queryRepo;
        IWCRepository<MasterConfiguration> dataRepo;
        IWCRepository<Province> provinceRepo;
        IWCRepository<District> districtRepo;
        IWCRepository<SubDistrict> subDistrictRepo;
        IWCRepository<FeasibilityPrice> feasibilityPriceRepo;
        IWCRepository<FeasibilityYield> feasibilityYieldRepo;
        public MasterConfigurationService(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            IWCRepository<MasterConfiguration> dataRepo,
            IWCRepository<Province> provinceRepo,
            IWCRepository<District> districtRepo,
            IWCRepository<SubDistrict> subDistrictRepo,
            IWCRepository<FeasibilityPrice> feasibilityPriceRepo,
            IWCRepository<FeasibilityYield> feasibilityYieldRepo,
            IWCQueryRepository queryRepo)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.dapper = dapper;
            this.queryRepo = queryRepo;
            this.dataRepo = dataRepo;
            this.provinceRepo = provinceRepo;
            this.districtRepo = districtRepo;
            this.subDistrictRepo = subDistrictRepo;
            this.feasibilityPriceRepo = feasibilityPriceRepo;
            this.feasibilityYieldRepo = feasibilityYieldRepo;
        }
        public async Task<IEnumerable<MasterConfigurationSearchResultDto>> GetMasterConfiguration(MasterConfigurationFilter filter)
        {
            var spec = new MasterConfigurationSearchSpec(filter ?? new MasterConfigurationFilter());
            var list = await dataRepo.ListAsync(spec);
            return mapper.Map<List<MasterConfiguration>, IEnumerable<MasterConfigurationSearchResultDto>>(list);
        }

        public async Task<MasterConfigurationSearchResultDto> GetMasterConfiguration(int id)
        {
            var spec = await dataRepo.GetByIdAsync(id);
            var result = mapper.Map<MasterConfigurationSearchResultDto>(spec);
            return result;
        }

        public async Task CreateMasterConfiguration(Core.Specifications.MasterConfigurationCreateRequest request)
        {
            Ensure.Any.IsNotNull(request, "MasterConfigurationCreateRequest");
            var config = new MasterConfiguration
            {
                ConfigurationKey = request.ConfigurationKey,
                Code = request.Code,
                Description = request.Description,
                Value = request.Value,
                IsActive = true,
                IsDelete = false,
            };

            await dataRepo.AddAsync(config);
            await uow.SaveAsync();
        }

        public async Task UpdateMasterConfiguration(int id, Core.Specifications.MasterConfigurationUpdateRequest request, BindPropertyCollection httpPatchBindProperty = null)
        {
            Ensure.Any.IsNotNull(request, "MasterConfigurationUpdateRequest");

            var config = await dataRepo.GetByIdAsync(id);
            if (config != null)
            {
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Code)))
                    config.Code = request.Code;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Description)))
                    config.Description = request.Description;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Value)))
                    config.Value = request.Value;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.IsActive)))
                    config.IsActive = request.IsActive.Value;

                await uow.SaveAsync();
            }
        }


        public async Task<IEnumerable<ProvinceSearchResultDto>> GetProvince()
        {
            var list = await provinceRepo.ListAsync();
            return mapper.Map<List<Province>, IEnumerable<ProvinceSearchResultDto>>(list);
        }
        public async Task<IEnumerable<DistrictSearchResultDto>> GetDistrict()
        {
            var list = await districtRepo.ListAsync();
            return mapper.Map<List<District>, IEnumerable<DistrictSearchResultDto>>(list);
        }
        public async Task<IEnumerable<SubDistrictSearchResultDto>> GetSubDistrict()
        {
            var list = await subDistrictRepo.ListAsync();
            return mapper.Map<List<SubDistrict>, IEnumerable<SubDistrictSearchResultDto>>(list);
        }

        public async Task<IEnumerable<FeasibilityPriceDto>> GetFeasibilityPrice()
        {
            var list = await feasibilityPriceRepo.ListAsync();
            return mapper.Map<List<FeasibilityPrice>, IEnumerable<FeasibilityPriceDto>>(list);
        }

        public async Task<IEnumerable<FeasibilityYieldDto>> GetFeasibilityYield()
        {
            var list = await feasibilityYieldRepo.ListAsync();
            return mapper.Map<List<FeasibilityYield>, IEnumerable<FeasibilityYieldDto>>(list);
        }
    }
}
