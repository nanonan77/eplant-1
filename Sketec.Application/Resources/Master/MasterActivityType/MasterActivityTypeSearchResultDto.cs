using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Sketec.Application.Resources
{
    public class MasterActivityTypeProfile : Profile
    {
        public MasterActivityTypeProfile()
        {
            CreateMap<MasterActivityType, MasterActivityTypeSearchResultDto>();
        }
    }
    public class MasterActivityTypeSearchResultDto
    {
        public int Id { get; set; }
        public string TitleEN { get; set; }
        public string TitleTH { get; set; }
        public string ActivityGroup { get; set; }
        public int Seq { get; set; }
        public bool IsActive { get; set; }

    }


}
