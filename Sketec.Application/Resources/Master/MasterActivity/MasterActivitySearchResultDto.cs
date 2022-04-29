using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Sketec.Application.Resources
{
    public class MasterActivityProfile : Profile
    {
        public MasterActivityProfile()
        {
            CreateMap<MasterActivity, MasterActivitySearchResultDto>();
        }
    }
    public class MasterActivitySearchResultDto
    {
        public int Id { get; set; }
        public string ActivityEN { get; set; }
        public string ActivityTH { get; set; }
        public string ActivityCode { get; set; }
        public int MasterActivityTypeId { get; set; }
        public MasterActivityTypeSearchResultDto MasterActivityType { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }


}
