using Sketec.Application.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces.Management
{
    public interface IAssumptionService : IApplicationService
    {
        Task<AssumptionDto> GetAssumption(Guid newRegistId);
        Task CreateAssumption(AssumptionDto request);
        Task UpdateAssumption(Guid newRegistId, AssumptionDto request);
        Task ReCalData();
    }
}
