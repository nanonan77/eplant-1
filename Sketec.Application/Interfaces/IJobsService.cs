using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces
{
    public interface IJobsService : IApplicationService
    {
        Task ExportMasterActivityToSharepoint();
        Task ImportNewRegistrationFromSharepoint();
        Task NotiNewRegist();
    }
}
