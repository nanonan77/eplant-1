using Sketec.Application.Filters;
using Sketec.Application.Resources;
using Sketec.Core.Specifications;
using Sketec.FileWriter.Excels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces
{
    public interface IMasterConfigurationService : IApplicationService
    {
        Task<IEnumerable<MasterConfigurationSearchResultDto>> GetMasterConfiguration(MasterConfigurationFilter filter);

        Task<MasterConfigurationSearchResultDto> GetMasterConfiguration(int id);

        Task CreateMasterConfiguration(MasterConfigurationCreateRequest request);

        Task UpdateMasterConfiguration(int id, MasterConfigurationUpdateRequest request, BindPropertyCollection httpPatchBindProperty = null);


        Task<IEnumerable<ProvinceSearchResultDto>> GetProvince();
        Task<IEnumerable<DistrictSearchResultDto>> GetDistrict();
        Task<IEnumerable<SubDistrictSearchResultDto>> GetSubDistrict();
        Task<IEnumerable<FeasibilityPriceDto>> GetFeasibilityPrice();
        Task<IEnumerable<FeasibilityYieldDto>> GetFeasibilityYield();
    }
}
