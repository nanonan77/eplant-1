using Sketec.Application.Filters;
using Sketec.Application.Resources;
using Sketec.Core.Specifications;
using Sketec.FileWriter.Excels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces
{
    public interface ITestSubNewRegistService : IApplicationService
    {
        Task<SubNewRegistDto> GetSubNewRegist(Guid newRegisID);
        Task<IEnumerable<NewRegistImagePathDto>> GetImage(Guid id);

        Task UpdateSubNewRegist(Guid subNewRegisID, SubNewRegistUpdateRequest request, BindPropertyCollection httpPatchBindProperty = null);

    }
}
