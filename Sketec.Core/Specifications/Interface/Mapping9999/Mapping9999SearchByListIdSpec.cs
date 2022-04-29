using Ardalis.Specification;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using Sketec.Core.Specifications.Management.Assumptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{
    public class Mapping9999SearchByListIdSpec : Mapping9999BaseSpec
    {
        public Mapping9999SearchByListIdSpec(IEnumerable<Guid> ids)
        {
            Query.Where(m => ids.Contains(m.Id));
            Query.AsSplitQuery();
        }
    }

}
