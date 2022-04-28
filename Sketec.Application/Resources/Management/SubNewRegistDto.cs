using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sketec.Application.Resources
{
    public class SubNewRegistProfile : Profile
    {
        public SubNewRegistProfile()
        {
            CreateMap<SubNewRegist, SubNewRegistDto>();
                    //.ForMember(d => d.SoilType, o => o.MapFrom(s => string.IsNullOrEmpty(s.SoilType) ? new List<string>() : s.SoilType.Split(",", StringSplitOptions.None).Where(o => !string.IsNullOrEmpty(o))));
        }
    }
    public class SubNewRegistDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string RegistId { get; set; }
        public string SubRegistId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public decimal? Area { get; set; }
        public int? NumSoilType { get; set; }
        public string SoilType { get; set; } // public IEnumerable<string> Longitude { get; set; }
        public string LandUse { get; set; }
        public string Accessibility { get; set; }
        public string Water { get; set; }
        public int? NumSoilTest { get; set; }

        public decimal? Rainfall { get; set; }
        public decimal? DeedArea { get; set; }
        public string ItemType { get; set; }

        public string Path { get; set; }
        public int? PlantYear { get; set; }
        public int? HarvestingMonth { get; set; }
        public int? HarvestingYear { get; set; }
        public decimal? Volume { get; set; }
        public decimal? VipPrice { get; set; }
        public string Remark { get; set; }

        public Guid NewRegistId { get; private set; }
        public bool IsActive { get; set; }

        public IEnumerable<SubNewRegistTestPlotDto> SubNewRegistTestPlots { get; set; }
        public IEnumerable<NewRegistImagePathDto> SubNewRegistImagePaths { get; set; }
        public bool IsCanEdit { get; set; }

    }


}
