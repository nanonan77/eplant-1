using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sketec.Core.Domains;

namespace Sketec.Application.Resources.Users
{
    public class UserResultProfile : Profile
    {
        public UserResultProfile()
        {
            CreateMap<User, UserResultDto>();

        }

    }
    public class UserResultDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int? EmployeeId { get; set; }
        public string EmpCode { get; set; }
        public int? OrganizationId { get; set; }
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
        public int? EmployeeOrganizationRelationTypeId { get; set; }
        public int? EmpOrgLevel { get; set; }
        public string CctR_Dept { get; set; }
        public string CctR_Over { get; set; }
        public string ManagerEmail { get; set; }
        public string Tel { get; set; }
        public string MobileNo { get; set; }
        public string Team { get; set; }
        public string Role { get; set; }
        public string ReportToEmail2 { get; set; }
        public string ReportToEmail3 { get; set; }
        public bool IsLocal { get; set; }
        public bool IsForceChangePassword { get; set; }
        public DateTime LastPasswordDate { get; set; }
        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
