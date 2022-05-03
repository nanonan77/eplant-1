using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Sketec.Application.Resources
{
    public class MatchPlantationProfile : Profile
    {
        public MatchPlantationProfile()
        {
            CreateMap<MatchPlantation, MatchPlantationDto>();
        }
    }

    public class MatchPlantationDto
    {
        public Guid Id { get; set; }

        public Guid PlantationId { get; set; }
        public NewPlantationDto Plantation { get; set; }

        public int MasterActivityId { get; set; }
        public MasterActivitySearchResultDto MasterActivity { get; set; }

        public decimal Amount { get; set; }

        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
