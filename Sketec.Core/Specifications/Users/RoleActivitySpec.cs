using Ardalis.Specification;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications.Users
{

    public class RoleActivitySpec : Specification<RoleActivity>, ISingleResultSpecification
    {

        public RoleActivitySpec(string role)
        {
            Query.Where(m => m.Role == role);
            Query.Where(m => m.IsActive == true);
        }


    }

}
