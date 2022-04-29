using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{
    public class NewPlantationSearchByIdSpec : NewPlantationBaseSpec
    {
        public NewPlantationSearchByIdSpec(Guid Id) 
        {
            Query.Where(f => f.Id == Id && f.IsDelete == false);
            Query.AsSplitQuery();
        }
    }
}
