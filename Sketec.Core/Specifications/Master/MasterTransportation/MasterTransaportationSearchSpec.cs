using Ardalis.Specification;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{
    public class MasterTransportationSearchSpec : Specification<MasterTransportationHeader>
    {
        public MasterTransportationSearchSpec(MasterTransportationFilter filter)
        {
            if (filter.Id != null)
                Query.Where(m => m.Id == filter.Id);

            if (!string.IsNullOrWhiteSpace(filter.TruckType))
                Query.Where(m => m.TruckType == filter.TruckType);

            if (filter.IsActive != null)
                Query.Where(m => m.IsActive == filter.IsActive);

        }
    }
    public class MasterTransportationFilter
    {
        public int? Id { get; set; }
        public string? TruckType { get; set; }
        public decimal FreightMin { get; set; }
        public decimal FreightMax { get; set; }
        public bool? IsActive { get; set; }
    }

    public class MasterTransportationCreateRequest
    {
        public int? Id { get; set; }
        public string TruckType { get; set; }
        public decimal FreightMin { get; set; }
        public decimal FreightMax { get; set; }

        public IEnumerable<MasterTransportationDetailUpdateRequest> MasterTransportationDetails { get; set; }
    }

    public class MasterTransportationUpdateRequest
    {
        public int? Id { get; set; }
        public string TruckType { get; set; }
        public decimal FreightMin { get; set; }
        public decimal FreightMax { get; set; }
        public bool? IsActive { get; set; }

        public IEnumerable<MasterTransportationDetailUpdateRequest> MasterTransportationDetails { get; set; }
    }

    public class MasterTransportationDetailUpdateRequest
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
