using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Sketec.Application.Resources
{
    public class SubNewRegistTestPlotProfile : Profile
    {
        public SubNewRegistTestPlotProfile()
        {
            CreateMap<SubNewRegistTestPlot, SubNewRegistTestPlotDto>();
        }
    }
    public class SubNewRegistTestPlotDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SubNewRegistTestId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? SoilType { get; set; }
        public string Depth { get; set; }
        public string SoillFloorDepth { get; set; }
        public string GravelDepth { get; set; }
        public decimal? PH30 { get; set; }
        public decimal? PH60 { get; set; }
        public decimal? EC30 { get; set; }
        public decimal? EC60 { get; set; }
        public string Dot { get; set; }

        public string ItemType { get; set; }
        public string Path { get; set; }

        public Guid SubNewRegistId { get; private set; }
        public bool IsActive { get; set; }

        public IEnumerable<NewRegistImagePathDto> SubNewRegistTestPlotImagePaths { get; set; }

        public bool IsCanEdit { get; set; }
    }
}
