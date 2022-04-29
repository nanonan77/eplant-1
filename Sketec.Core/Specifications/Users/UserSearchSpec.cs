using Ardalis.Specification;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sketec.Core.Specifications
{

    public class UserSearchSpec : Specification<User>
    {
        public UserSearchSpec(UserFilter filter)
        {
            if(filter.IsEqual != null)
            {
                if (!string.IsNullOrEmpty(filter.Username))
                    Query.Where(m => m.Username == filter.Username);
                if (!string.IsNullOrEmpty(filter.Email))
                    Query.Where(m => m.Email == filter.Email);
            }
            else
            {
                if (!string.IsNullOrEmpty(filter.Username))
                    Query.Where(m => m.Username.Contains(filter.Username));
                if (!string.IsNullOrEmpty(filter.Email))
                    Query.Where(m => m.Email.Contains(filter.Email));
            }
            
            if (!string.IsNullOrEmpty(filter.E_FullName))
                Query.Where(m => m.E_FullName.Contains(filter.E_FullName));
            if (!string.IsNullOrEmpty(filter.PositionName))
                Query.Where(m => m.PositionName.Contains(filter.PositionName));
            if (!string.IsNullOrEmpty(filter.Sec_Name))
                Query.Where(m => m.Sec_Name.Contains(filter.Sec_Name));
            if (!string.IsNullOrEmpty(filter.Dep_Name))
                Query.Where(m => m.Dep_Name.Contains(filter.Dep_Name));
            if (!string.IsNullOrEmpty(filter.Team))
            {
                var keyList = filter.Team.Split(',');
                Query.Where(m => keyList.Contains(m.Team));
            }
            if (!string.IsNullOrEmpty(filter.Role))
            {
                var keyList2 = filter.Role.Split(',');
                Query.Where(m => keyList2.Contains(m.Role));
            }
            if (filter.IsLocal != null)
                Query.Where(m => m.IsLocal == filter.IsLocal);
            if (filter.IsActive != null)
                Query.Where(m => m.IsActive == filter.IsActive);

            Query.Where(m => m.IsDelete == false);
        }
    }

    public class UserCreateRequest
    {
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
        public bool IsLocal { get; set; }
      //  public DateTime LastPasswordDate { get; set; }
    }


    public class UserUpdateRequest
    {
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
        public bool IsLocal { get; set; }
       // public DateTime LastPasswordDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class UserFilter
    {
        public string Username { get; set; }
        public string E_FullName { get; set; }
        public string PositionName { get; set; }
        public string Dep_Name { get; set; }
        public string Sec_Name { get; set; }
        public string Email { get; set; }
        public string ManagerEmail { get; set; }
        public string Team { get; set; }
        public string Role { get; set; }
        public bool? IsLocal { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsEqual { get; set; }
    }

}