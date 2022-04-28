using Ardalis.Specification;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications.RunningNumbers
{
    public class RunningNumberSpec : Specification<RunningNumber>, ISingleResultSpecification
    {
        public RunningNumberSpec(string topic, int? year, string saleOrg, string temp1 = null, string temp2 = null, string temp3 = null)
        {
            Query.Where(m => m.Topic == topic);

            if (year != null)
            {
                Query.Where(m => m.Year == year);
            }

            if (!string.IsNullOrWhiteSpace(temp1))
            {
                Query.Where(m => m.Temp1 == temp1);
            }

            if (!string.IsNullOrWhiteSpace(temp2))
            {
                Query.Where(m => m.Temp2 == temp2);
            }

            if (!string.IsNullOrWhiteSpace(temp3))
            {
                Query.Where(m => m.Temp3 == temp3);
            }
        }
    }
}
