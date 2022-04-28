using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Sketec.Application.Resources
{
    public class NewRegistImagePathProfile : Profile
    {
        public NewRegistImagePathProfile()
        {
            CreateMap<NewRegistImagePath, NewRegistImagePathDto>();
        }
    }
    public class NewRegistImagePathDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurveyId { get; set; }
        public string PlantationId { get; set; }
        public string ImageInfo { get; set; }
        public string ImageInfo2 { get; set; }
        public string ImageInfo3 { get; set; }
        public string ItemType { get; set; }
        public string Path { get; set; }
        public Guid NewRegistId { get; set; }
        public Guid? SubNewRegistId { get; set; }
        public Guid? SubNewRegistTestPlotId { get; set; }
        public NewRegistLevel ImageLevel { get; set; }
        public byte[] Base64 { get; set; }
        public bool IsActive { get; set; }
        public bool IsSelectedStep2 { get; set; }
        public bool IsSelectedStep3 { get; set; }
    }
}
