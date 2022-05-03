using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Sketec.Application.Resources
{
    public class MatchDataProfile : Profile
    {
        public MatchDataProfile()
        {
            CreateMap<MatchData, MatchDataDto>();
        }
    }

    public class MatchDataDto
    {
        public Guid Id { get; set; }

        public Guid Mapping9999Id { get; set; }
        public Mapping9999Dto Mapping9999 { get; set; }

        public decimal ValCOAreaCrcy { get; set; }

        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
