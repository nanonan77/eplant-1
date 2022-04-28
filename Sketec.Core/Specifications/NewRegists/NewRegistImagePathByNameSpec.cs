using Ardalis.Specification;
using Sketec.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{
    public class NewRegistImagePathByNameSpec : Specification<NewRegistImagePath>, ISingleResultSpecification
    {
        public NewRegistImagePathByNameSpec(string name)
        {
            Query.Where(f => f.Name == name);
        }
    }
}
