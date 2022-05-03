using Ardalis.Specification;
using Sketec.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{
    public class Match9999BaseSpec : Specification<Match9999>, ISingleResultSpecification
    {
        public Match9999BaseSpec NoTracking()
        {
            Query.AsNoTracking();
            return this;
        }
        public Match9999BaseSpec IncludeAll ()
        {
            return IncludeMatchData();
        }
        public Match9999BaseSpec IncludeMatchData()
        {
            Query.Include(b => b.MatchDatas).ThenInclude(b => b.Mapping9999);
            return this;
        }
    }
}
