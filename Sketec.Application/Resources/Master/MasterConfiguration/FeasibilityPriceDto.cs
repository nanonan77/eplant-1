using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Sketec.Application.Resources
{
    public class FeasibilityPriceProfile : Profile
    {
        public FeasibilityPriceProfile()
        {
            CreateMap<FeasibilityPrice, FeasibilityPriceDto>();
        }
    }
    public class FeasibilityPriceDto
    {
        public int Id { get; set; }
        public string Mill { get; set; }
        public string PriceType { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }

}
