using Ardalis.Specification;
using Sketec.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{

    public class SubNewPlantationSearchByIdSpec : Specification<SubPlantation>, ISingleResultSpecification
    {
        public SubNewPlantationSearchByIdSpec(Guid Id)
        {
            Query.Where(f => f.Id == Id);
            Query.AsSplitQuery();
        }
    }
}
