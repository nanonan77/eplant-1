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
    public  class UserBaseSpec:Specification<User>,ISingleResultSpecification
    {

    }

    public class UserByUsernameSpec : UserBaseSpec
    {

        public UserByUsernameSpec(string username)
        {
            Query.Where(m => m.Username == username);
        }


    }

}
