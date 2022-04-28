using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Sketec.Application.Resources
{
    public class MasterTransportationDetailProfile : Profile
    {
        public MasterTransportationDetailProfile()
        {
            CreateMap<MasterTransportationDetail, MasterTransportationDetailSearchResultDto>();

        }
    }

    public class MasterTransportationDetailSearchResultDto
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }


    }
}
