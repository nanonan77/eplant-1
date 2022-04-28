using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Resources.Gdc
{
    public class EmployeeOrgChartByOrganizationIdDoaIdResponse
    {
        public List<EmployeeOrgChartByOrganizationId> ResponseData { get; set; }
        public GdcResponseBase ResponseBase { get; set; }
    }
    public class EmployeeOrgChartByOrganizationIdDoaIdRequest
    {
        public int OrganizationId { get; set; }
        public string ReferenceToken { get; set; }
    }
    public class EmployeeOrgChartByOrganizationId
    {
        public int K2ChainOfCommandId { get; set; }
        public int OrganizationId { get; set; }
        public int OrganizationParentId { get; set; }
        public string ManagerADAccount { get; set; }
        public string ManagerEmail { get; set; }
        public int ApprovalLevelId { get; set; }
        public int ServiceTypeId { get; set; }
        public int OrganizationLevelId { get; set; }
        public string PositionName { get; set; }
        public string Position_Name_English { get; set; }
        public string Position_Name_Thai { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string E_FullName { get; set; }
        public int ManagerOrganizationId { get; set; }
        public string ApprovalLevelNameForPO { get; set; }
        public int DoaId { get; set; }
    }
}
