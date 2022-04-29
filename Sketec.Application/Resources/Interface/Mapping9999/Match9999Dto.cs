using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Sketec.Application.Resources
{
    public class Match9999Profile : Profile
    {
        public Match9999Profile()
        {
            CreateMap<Match9999, Match9999Dto>();
        }
    }

    public class Match9999Dto
    {
        public Guid Id { get; set; }
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }

        public Guid MappingTransId { get; set; }
        //public MappingTransDto MappingTrans { get; set; }

        public IEnumerable<MatchDataDto> MatchDatas { get; set; }
        public IEnumerable<MatchPlantationDto> MatchPlantations { get; set; }

        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }

    public class Mapping9999CreateRequest
    {
        public Guid MappingTransId { get; set; }
        public string type { get; set; }
        public Match9999Dto Match9999s { get; set; }
    }
}
