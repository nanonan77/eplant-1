using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sketec.Application.Resources
{
    public class SubNewPlantationProfile : Profile
    {
        public SubNewPlantationProfile()
        {
            CreateMap<SubPlantation, SubNewPlantationDto>();
                    //.ForMember(d => d.SoilType, o => o.MapFrom(s => string.IsNullOrEmpty(s.SoilType) ? new List<string>() : s.SoilType.Split(",", StringSplitOptions.None).Where(o => !string.IsNullOrEmpty(o))));
        }
    }
    public class SubNewPlantationDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string PlantationId { get; set; }
        public string SubPlantationNo { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public decimal? Area { get; set; }
        public int? Seedling { get; set; }
        public string Remark { get; set; }
        public int? PlantYear { get; set; }
        public int? HarvestingMonth { get; set; }
        public int? HarvestingYear { get; set; }
        public decimal? Volume { get; set; }
        public decimal? VipPrice { get; set; }
        public decimal? ActualVolume { get; set; }
        public decimal? ActualVipPrice { get; set; }
        public string PlantationNo { get; set; }

        public Guid NewRegistId { get; private set; }
        public bool IsActive { get; set; }

        public IEnumerable<NewRegistImagePathDto> SubNewRegistImagePaths { get; set; }

        public bool IsCanEdit { get; set; }

    }


}
