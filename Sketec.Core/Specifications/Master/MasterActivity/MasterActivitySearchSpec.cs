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
    public class MasterActivitySearchSpec : Specification<MasterActivity>
    {
        //public MasterActivitySearchSpec(MasterActivityFilter filter)
        //{
        //    if (!string.IsNullOrWhiteSpace(filter.ActivityEN))
        //        Query.Where(m => m.ActivityEN.Contains(filter.ActivityEN));

        //    if (!string.IsNullOrWhiteSpace(filter.ActivityTH))
        //        Query.Where(m => m.ActivityTH.Contains(filter.ActivityTH));

        //    if (!string.IsNullOrWhiteSpace(filter.ActivityCode))
        //        Query.Where(m => m.ActivityCode.Contains(filter.ActivityCode));

        //    if (!string.IsNullOrWhiteSpace(filter.ActivityGroup))
        //        Query.Where(m => m.MasterActivityType.ActivityGroup.Contains(filter.ActivityGroup));

        //    if (filter.IsActive != null)
        //        Query.Where(m => m.IsActive == filter.IsActive);
        //    if (filter.IsDelete != null)
        //        Query.Where(m => m.IsDelete == filter.IsDelete);

        //    if (!string.IsNullOrWhiteSpace(filter.CreatedBy))
        //        Query.Where(m => m.CreatedBy.Contains(filter.CreatedBy));
        //}
    }

    public class MasterActivityFilter
    {
        public int? MasterActivityTypeId { get; set; }
        public string ActivityEN { get; set; }
        public string ActivityTH { get; set; }
        public string ActivityCode { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsExport { get; set; }
        public string CreatedBy { get; set; }

    }

    public class MasterActivityCreateRequest
    {
        public string ActivityEN { get; set; }
        public string ActivityTH { get; set; }
        public string ActivityCode { get; set; }
        public int MasterActivityTypeId { get; set; }
    }

    public class MasterActivityUpdateRequest
    {
        public string ActivityEN { get; set; }
        public string ActivityTH { get; set; }
        public string ActivityCode { get; set; }
        public int? MasterActivityTypeId { get; set; }
        public bool? IsActive { get; set; }
    }
}
