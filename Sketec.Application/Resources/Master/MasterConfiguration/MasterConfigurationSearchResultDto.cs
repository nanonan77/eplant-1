using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Sketec.Application.Resources
{
    public class MasterConfigurationProfile : Profile
    {
        public MasterConfigurationProfile()
        {
            CreateMap<MasterConfiguration, MasterConfigurationSearchResultDto>();
        }
    }
    public class MasterConfigurationSearchResultDto
    {
        public int Id { get; set; }
        public string ConfigurationKey { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
    }

}
