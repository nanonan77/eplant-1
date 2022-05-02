using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Sketec.Application.Resources
{
    public class NewPlantationProfile : Profile
    {
        public NewPlantationProfile()
        {
            CreateMap<Plantation, NewPlantationDto>();
        }
    }
    public class NewPlantationDto
    {
        public Guid? Id { get; set; }
        public Guid? NewRegistId { get; set; }
        public string PlantationId { get; set; }
        public string Title { get; set; }
        public string ContractType { get; set; }
        public string Status { get; set; }
        public string PIC { get; set; }
        public int? ContractYear { get; set; }
        public int? ContractMonth { get; set; }
        public int? Contract { get; set; }
        public string ContractId { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public string Village { get; set; }
        public decimal? RentalArea { get; set; }
        public decimal? ProductiveArea { get; set; }
        public decimal? PotentialArea { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Remark { get; set; }
        public string Zone { get; set; }
        public string MOUType { get; set; }
        public int? Seedling { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Action { get; set; }
        public bool IsActive { get; set; }

        public IEnumerable<SubNewPlantationDto> SubPlantations { get; set; }
        public IEnumerable<NewRegistImagePathDto> NewRegistImagePaths { get; set; }

        public bool IsCanEdit { get; set; }
    }


}
