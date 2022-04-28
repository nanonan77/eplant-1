using Sketec.Application.Resources.Gdc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces
{
    public interface IGdcService
    {
        Task<EmployeeInfoByADAccount> GetEmployeeInfoByADAccount(string userName);
        Task<MembersInfoByADAccount> GetMembersInfoByADAccount(string userName);
        Task<List<EmployeeOrgChartByOrganizationId>> GetEmployeeOrgChartByOrganizationId(int organizationId);
        Task<List<EmployeesByPersonnelNumberList>> GetEmployeesByPersonnelNumberList(string personnelNumberList);
    }
}
