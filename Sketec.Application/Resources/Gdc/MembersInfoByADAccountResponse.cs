using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Resources.Gdc
{
    public class MembersInfoByADAccountResponse
    {
        public List<MembersInfoByADAccount> ResponseData { get; set; }
        public GdcResponseBase ResponseBase { get; set; }
    }

    public class MembersInfoByADAccountRequest
    {
        public string Domain { get; set; }
        public string AdAccount { get; set; }
        public string ReferenceToken { get; set; }
    }
    public class MembersInfoByADAccount
    {
        public int K2MemberOrganizationId { get; set; }
        public int MemberId { get; set; }
        public int OrganizationId { get; set; }
        public int MemberOrganizationRelationTypeId { get; set; }
        public string Domain { get; set; }
        public string AdAccount { get; set; }
        public string OrganizationName { get; set; }
        public string ScgEmployeeId { get; set; }
        public string T_FullName { get; set; }
        public string E_FullName { get; set; }
        public string NickName { get; set; }
        public string PositionName { get; set; }
        public string BusinessUnit { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string ManagerEmail { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string Div_Name { get; set; }
        public string Dep_Name { get; set; }
        public string SubDep_Name { get; set; }
        public string Sec_Name { get; set; }
        public string Shift_Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public int OrganizationLevelId { get; set; }
        public string CostCenter_Dept { get; set; }
        public int PositionId { get; set; }
        public string PL_Group { get; set; }
        public int ApproveLevelId { get; set; }

    }

}
