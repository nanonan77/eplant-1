using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sketec.Core.Domains;

namespace Sketec.Application.Resources.Users
{
    public class RoleActivityProfile : Profile
    {
        public RoleActivityProfile()
        {
            CreateMap<RoleActivity, RoleActivityDto>();

        }

    }
    public class RoleActivityDto
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Page { get; set; }
        public string Activity { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
