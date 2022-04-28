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
    public class MasterRunningNumberSpec : Specification<MasterRunningNumber>, ISingleResultSpecification
    {
        public MasterRunningNumberSpec(string topic)
        {
            Query.Where(m => m.Topic == topic);
        }
    }
}
