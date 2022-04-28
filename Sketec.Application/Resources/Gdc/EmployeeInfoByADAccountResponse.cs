using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Resources.Gdc
{
    public class EmployeeInfoByADAccountResponse
    {
        public List<EmployeeInfoByADAccount> ResponseData { get; set; }
        public GdcResponseBase ResponseBase { get; set; }
    }

    public class EmployeeInfoByADAccountRequest
    {
        public string Username { get; set; }
        public string ReferenceToken { get; set; }
    }
    public class EmployeeInfoByADAccount
    {
        public int EmployeeId { get; set; }
        public string EmpCode { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string AdAcount { get; set; }
        public string T_FullName { get; set; }
        public string E_FullName { get; set; }
        public string NickName { get; set; }
        public string PositionName { get; set; }
        public string BusinessUnit { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string Div_Name { get; set; }
        public string Dep_Name { get; set; }
        public string SubDep_Name { get; set; }
        public string Sec_Name { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public int EmployeeOrganizationRelationTypeId { get; set; }
        public int EmpOrgLevel { get; set; }
        public string CctR_Dept { get; set; }
        public string CctR_Over { get; set; }
        public string ManagerEmail { get; set; }
        public string Tel { get; set; }
        public string MobileNo { get; set; }
    }

}
