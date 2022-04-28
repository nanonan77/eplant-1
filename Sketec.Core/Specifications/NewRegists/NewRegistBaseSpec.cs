using Ardalis.Specification;
using Sketec.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{
    public class NewRegistBaseSpec : Specification<Sketec.Core.Domains.NewRegist>, ISingleResultSpecification
    {

        public NewRegistBaseSpec InCludeSubNewRegists()
        {
            Query.Include(b => b.SubNewRegists);

            return this;
        }
        public NewRegistBaseSpec InCludeSubNewRegistTestPlots()
        {
            Query.Include(b => b.SubNewRegists).ThenInclude(o => o.SubNewRegistTestPlots);

            return this;
        }
        public NewRegistBaseSpec InCludeNewRegistStatusLogs()
        {
            Query.Include(b => b.NewRegistStatusLogs);

            return this;
        }
    }

    public class NewRegistFilter
    {
        
        public Guid Id { get; set; }

    }

    public class NewRegistUpdateRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string RegistId { get; set; }
        public string Status { get; set; }
        public string OwnerName { get; set; }
        public string OwnerLastName { get; set; }
        public string OwnerTel { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public string Village { get; set; }
        public int? Plot { get; set; }
        public decimal? TotalArea { get; set; }
        public decimal? Rai { get; set; }
        public decimal? Ngan { get; set; }
        public decimal? Meter { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Clearing1 { get; set; }
        public decimal? Clearing1Area { get; set; }
        public string Clearing2 { get; set; }
        public DateTime? CreatedFromFile { get; set; }
        public int? Contract { get; set; }
        public DateTime? ModifiedFromFile { get; set; }

        public string PIC { get; set; }
        public int? Generated { get; set; }
        public int? Interface { get; set; }
        public string ItemType { get; set; }
        public string Path { get; set; }
        public string Zone { get; set; }
        public string Verifier { get; set; }
        public string MOUType { get; set; }
        public int? Seedling { get; set; }
        public int? HarvestingYear1 { get; set; }
        public int? HarvestingMonth1 { get; set; }
        public int? HarvestingYear2 { get; set; }
        public int? HarvestingMonth2 { get; set; }
        public decimal? MOUPrice { get; set; }
        public decimal? PlanVolume { get; set; }
        public string Remark { get; set; }
        public string ContractType { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsStatus { get; set; }
    }

}
