using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Sketec.Application.Resources
{
    public class DistrictProfile : Profile
    {
        public DistrictProfile()
        {
            CreateMap<District, DistrictSearchResultDto>();
        }
    }
    public class DistrictSearchResultDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DistrictID { get; set; }
        public string DistrictThai { get; set; }
        public string ProvinceID { get; set; }
        public string ZoneID { get; set; }
        public bool IsActive { get; set; }
    }

}
