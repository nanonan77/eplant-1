using Ardalis.Specification;
using Sketec.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{
    public class NewPlantationBaseSpec : Specification<Sketec.Core.Domains.Plantation>, ISingleResultSpecification
    {

        public NewPlantationBaseSpec InCludeSubNewPlantations()
        {
            Query.Include(b => b.SubPlantations);

            return this;
        }

        public NewPlantationBaseSpec InCludeNewPlantationAmortized()
        {
            Query.Include(b => b.PlantationAmortizeds);

            return this;
        }
        public NewPlantationBaseSpec InCludeNewRegist()
        {
            Query.Include(b => b.NewRegist);

            return this;
        }

        public NewPlantationBaseSpec InCludeUnplans()
        {
            Query.Include(b => b.Unplans);

            return this;
        }

        public NewPlantationBaseSpec NoTracking()
        {
            Query.AsNoTracking();

            return this;
        }
    }
    public class NewPlantationFilter
    {
        
        public Guid Id { get; set; }

    }

    public class NewPlantationUpdateRequest
    {
        public Guid Id { get; set; }
        public string PlantationNo { get; set; }
        public int? ContractYear { get; set; }
        public int? ContractMonth { get; set; }
        public int? Contract { get; set; }
        public string Title { get; set; }
        public string ContractType { get; set; }
        public string Status { get; set; }
        public string PIC { get; set; }
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

        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        
    }

}
