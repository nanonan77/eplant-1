using Ardalis.Specification;
using Sketec.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{
    public class Mapping9999BaseSpec : Specification<Mapping9999>, ISingleResultSpecification
    {
        public Mapping9999BaseSpec NoTracking()
        {
            Query.AsNoTracking();

            return this;
        }
    }
}
