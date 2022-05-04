using Ardalis.Specification;
using System;
using System.Linq;

namespace Sketec.Core.Specifications
{
    public class MappingTransSearchByIdSpec : MappingTransBaseSpec
    {
        public MappingTransSearchByIdSpec(Guid id)
        {
            Query.Where(m => m.Id == id);
            Query.AsSplitQuery();
        }
    }

}
