using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Sketec.Application.Resources
{
    public class MappingTransProfile : Profile
    {
        public MappingTransProfile()
        {
            CreateMap<MappingTrans, MappingTransDto>();
        }
    }

    public class MappingTransDto
    {
        public Guid Id { get; set; }
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }

        public IEnumerable<Match9999Dto> Match9999 { get; set; }

        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
