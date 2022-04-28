using Ardalis.Specification;
using Sketec.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{
    public class SubNewPlantationFilter
    {
        public Guid Id { get; set; }

    }

    public class SubNewPlantationUpdateRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
       
        public string PlantationNo { get; set; }
        public string SubPlantationNo { get; set; }
        public decimal? Area { get; set; }
        public int? Seedling { get; set; }
        public string Remark { get; set; }

        public int? PlantYear { get; set; }
        public int? HarvestingMonth { get; set; }
        public int? HarvestingYear { get; set; }
        public decimal? Volume { get; set; }
        public decimal? VipPrice { get; set; }
        public decimal? ActualVolume { get; set; }
        public decimal? ActualVipPrice { get; set; }
        public Guid PlantationId { get; private set; }

    }

    public class SubNewPlantationCreateRequest
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }
        public string PlantationNo { get; set; }
        public string SubPlantationNo { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public decimal? Area { get; set; }
        public int? Seedling { get; set; }
        public string Remark { get; set; }
        public int? PlantYear { get; set; }
        public int? HarvestingMonth { get; set; }
        public int? HarvestingYear { get; set; }
        public decimal? Volume { get; set; }
        public decimal? VipPrice { get; set; }
        public decimal? ActualVolume { get; set; }
        public decimal? ActualVipPrice { get; set; }
        public Guid PlantationId { get; set; }

    }
}
