using Sketec.Application.Filters;
using Sketec.Application.Resources;
using Sketec.Core.Specifications;
using Sketec.FileWriter.Excels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces
{
    public interface ITestNewRegistStatusLogService : IApplicationService
    {
        Task CreateNewRegistStatusLog(IEnumerable<NewRegistStatusLogCreateRequest> request);

        Task<IEnumerable<NewRegistStatusLogResultDto>> GetNewRegistStatusLogs(NewRegistStatusLogFilter filter);

        //Task UpdateNewRegistStatusLog(Guid newRegisID, NewRegistUpdateRequest request, BindPropertyCollection httpPatchBindProperty = null);
        //Task<byte[]> Pdf();
    }
}
