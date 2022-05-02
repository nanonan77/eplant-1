using Sketec.Application.Filters;
using Sketec.Application.Resources;
using Sketec.Core.Specifications;
using Sketec.FileWriter.Excels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces
{
    public interface IRollingPlanService : IApplicationService
    {
        Task<IEnumerable<RollingPlanSearchResultDto>> GetRollingPlans(RollingPlanFilter filter);
    }
}
