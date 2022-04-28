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
    public class AssumptionSearchByIdSpec : AssumptionBaseSpec
    {
        public AssumptionSearchByIdSpec(Guid id)
        {
            Query.Where(m => m.Id == id);
            Query.AsSplitQuery();
        }
    }

}
