using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Sketec.Application.Resources
{
    public class FeasibilityYieldProfile : Profile
    {
        public FeasibilityYieldProfile()
        {
            CreateMap<FeasibilityYield, FeasibilityYieldDto>();
        }
    }
    public class FeasibilityYieldDto
    {
        public int Id { get; set; }
        public string SoilType { get; set; }
        public int? RainfallStart { get; set; }
        public int? RainfallEnd { get; set; }
        public decimal Yield { get; set; }
        public bool IsActive { get; set; }
    }

}
