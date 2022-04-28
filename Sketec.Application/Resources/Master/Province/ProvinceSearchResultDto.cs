using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Sketec.Application.Resources
{
    public class ProvinceProfile : Profile
    {
        public ProvinceProfile()
        {
            CreateMap<Province, ProvinceSearchResultDto>();
        }
    }
    public class ProvinceSearchResultDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ProvinceID { get; set; }
        public string ProvinceThai { get; set; }
        public string ZoneID { get; set; }
        public bool IsActive { get; set; }
    }

}
