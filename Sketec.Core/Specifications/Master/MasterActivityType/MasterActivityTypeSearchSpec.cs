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
    public class MasterActivityTypeSearchSpec : Specification<MasterActivityType>
    {
        public MasterActivityTypeSearchSpec(MasterActivityTypeFilter filter)
        {
            if (!string.IsNullOrWhiteSpace(filter.TitleEN))
                Query.Where(m => m.TitleEN.Contains(filter.TitleEN));

            if (!string.IsNullOrWhiteSpace(filter.TitleTH))
                Query.Where(m => m.TitleTH.Contains(filter.TitleTH));

            if (!string.IsNullOrWhiteSpace(filter.ActivityGroup))
                Query.Where(m => m.ActivityGroup.Contains(filter.ActivityGroup));

            if(filter.IsActive != null)
                Query.Where(m => m.IsActive == filter.IsActive);

        }
    }

    public class MasterActivityTypeFilter
    {

        public string TitleEN { get; set; }
        public string TitleTH { get; set; }
        public string ActivityGroup { get; set; }
        public bool? IsActive { get; set; }
    }
}
