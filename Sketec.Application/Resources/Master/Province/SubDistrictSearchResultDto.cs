using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Sketec.Application.Resources
{
    public class SubDistrictProfile : Profile
    {
        public SubDistrictProfile()
        {
            CreateMap<SubDistrict, SubDistrictSearchResultDto>();
        }
    }
    public class SubDistrictSearchResultDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TambonID { get; set; }
        public string TambonThai { get; set; }
        public string DistrictID { get; set; }
        public string ProvinceID { get; set; }
        public string ZoneID { get; set; }
        public bool IsActive { get; set; }
    }

}
