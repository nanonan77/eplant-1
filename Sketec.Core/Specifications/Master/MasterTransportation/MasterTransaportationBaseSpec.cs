using Ardalis.Specification;
using Sketec.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{
    public class MasterTransportationBaseSpec : Specification<MasterTransportationHeader>, ISingleResultSpecification
    {
        public MasterTransportationBaseSpec InCludeDetail()
        {
            Query.Include(b => b.MasterTransportationDetails);

            return this;
        }
    }
}
