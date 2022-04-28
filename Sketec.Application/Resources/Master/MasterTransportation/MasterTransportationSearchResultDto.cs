using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Sketec.Application.Resources
{
    public class MasterTransportationProfile : Profile
    {
        public MasterTransportationProfile()
        {
            CreateMap<MasterTransportationHeader, MasterTransportationSearchResultDto>();
        }
    }

    public class MasterTransportationSearchResultDto
    {
        public int Id { get; set; }
        public string TruckType { get; set; }
        public decimal FreightMin { get; set; }
        public decimal FreightMax { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public IEnumerable<MasterTransportationDetailSearchResultDto> MasterTransportationDetails { get; set; }

    }
}
