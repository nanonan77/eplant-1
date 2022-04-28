using Ardalis.Specification;
using Sketec.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{
    public class SubNewRegistBaseSpec : Specification<SubNewRegist>, ISingleResultSpecification
    {
        public SubNewRegistBaseSpec InCludeSubNewRegistTestPlots()
        {
            Query.Include(o => o.SubNewRegistTestPlots);

            return this;
        }
        public SubNewRegistBaseSpec InCludeNewRegist()
        {
            Query.Include(o => o.NewRegist);

            return this;
        }
    }
    public class SubNewRegistFilter
    {
        public Guid Id { get; set; }

    }

    public class SubNewRegistUpdateRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string RegistId { get; set; }
        public string SubRegistId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public decimal? Area { get; set; }
        public int? NumSoilType { get; set; }
        public string SoilType { get; set; }
        public string LandUse { get; set; }
        public string Accessibility { get; set; }
        public string Water { get; set; }
        public int? NumSoilTest { get; set; }

        public decimal? Rainfall { get; set; }
        public decimal? DeedArea { get; set; }
        public string ItemType { get; set; }

        public string Path { get; set; }
        public int? PlantYear { get; set; }
        public int? HarvestingMonth { get; set; }
        public int? HarvestingYear { get; set; }
        public decimal? Volume { get; set; }
        public decimal? VipPrice { get; set; }
        public string Remark { get; set; }
    }
}
