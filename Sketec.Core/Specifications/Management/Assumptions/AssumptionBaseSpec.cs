using Ardalis.Specification;
using Sketec.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications.Management.Assumptions
{
    public class AssumptionBaseSpec : Specification<Assumption>, ISingleResultSpecification
    {
        public AssumptionBaseSpec NoTracking()
        {
            Query.AsNoTracking();

            return this;
        }
        public AssumptionBaseSpec IncludeAll ()
        {
            return IncludeAssmptionYield().IncludeAssmptionClone().IncludeNewRegist().IncludeExpenses();
        }
        public AssumptionBaseSpec IncludeAssmptionYield()
        {
            Query.Include(b => b.AssumptionYields);

            return this;
        }
        public AssumptionBaseSpec IncludeAssmptionClone()
        {
            Query.Include(b => b.AssumptionClones);

            return this;
        }
        public AssumptionBaseSpec IncludeNewRegist()
        {
            Query.Include(b => b.NewRegist).ThenInclude(o => o.SubNewRegists);

            return this;
        }
        public AssumptionBaseSpec IncludeExpenses()
        {
            Query.Include(b => b.Expenses).ThenInclude(o => o.MasterActivity).ThenInclude(o => o.MasterActivityType);

            return this;
        }
    }
}
