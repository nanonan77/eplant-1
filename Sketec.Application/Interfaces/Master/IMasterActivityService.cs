using Sketec.Application.Filters;
using Sketec.Application.Resources;
using Sketec.Core.Specifications;
using Sketec.FileWriter.Excels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces
{
    public interface IMasterActivityService : IApplicationService
    {
        Task<IEnumerable<MasterActivityResultDto>> GetMasterActivitys(MasterActivityFilter filter);
        Task<MasterActivitySearchResultDto> GetMasterActivity(int id);
        Task CreateMasterActivity(MasterActivityCreateRequest request);
        Task UpdateMasterActivity(int id, MasterActivityUpdateRequest request, BindPropertyCollection httpPatchBindProperty = null);
        Task UpdateIsExportMasterActivity(IEnumerable<MasterActivityResultDto> data);
    }
}
