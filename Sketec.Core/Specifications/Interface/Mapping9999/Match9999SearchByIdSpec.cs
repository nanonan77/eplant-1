using Ardalis.Specification;
using System;
using System.Linq;

namespace Sketec.Core.Specifications
{
    public class Match9999SearchByIdSpec : Match9999BaseSpec
    {
        public Match9999SearchByIdSpec(Guid id)
        {
            Query.Where(m => m.Id == id);
            Query.AsSplitQuery();
        }
    }

}
