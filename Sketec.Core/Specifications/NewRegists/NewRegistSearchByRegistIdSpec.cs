using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{
    public class NewRegistSearchByRegistIdSpec : NewRegistBaseSpec
    {
        public NewRegistSearchByRegistIdSpec(string regisNoId) 
        {
            Query.Where(f => f.RegistId == regisNoId);
            Query.AsSplitQuery();
        }
    }
    public class NewRegistSearchBySubRegistIdSpec : NewRegistBaseSpec
    {
        public NewRegistSearchBySubRegistIdSpec(string subRegisId)
        {
            Query.Where(f => f.SubNewRegists.Any(o => o.SubRegistId == subRegisId));
            Query.AsSplitQuery();
        }
    }
}
