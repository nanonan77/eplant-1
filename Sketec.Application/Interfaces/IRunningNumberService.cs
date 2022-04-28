using Sketec.Core.Domains.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces
{
    public interface IRunningNumberService:IApplicationService
    {
        //Task<string> BillDocumentControl(string salesOrg, string type, int year);
        Task<string> GetRunningNumber(string topic, int? year = null, string temp1 = null, string temp2 = null, string temp3 = null);
    }
}
