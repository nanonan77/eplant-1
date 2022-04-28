using Sketec.Application.Filters;
using Sketec.Application.Resources;
using Sketec.Core.Specifications;
using Sketec.FileWriter.Excels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces
{
    public interface ITestSubNewRegistPhysicalService : IApplicationService
    {
        Task<SubNewRegistTestPlotDto> GetSubNewRegistTestPlot(Guid newRegisID);
        Task<IEnumerable<NewRegistImagePathDto>> GetImage(Guid id);

        Task UpdateSubNewRegistTestPlot(Guid subnNewRegistTestPlotID, SubNewRegistTestPlotUpdateRequest request, BindPropertyCollection httpPatchBindProperty = null);

    }
}
