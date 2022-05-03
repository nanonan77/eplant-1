using Ardalis.Specification;
using Sketec.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{
    public class MappingTransBaseSpec : Specification<MappingTrans>, ISingleResultSpecification
    {
        public MappingTransBaseSpec NoTracking()
        {
            Query.AsNoTracking();

            return this;
        }
        public MappingTransBaseSpec IncludeAll ()
        {
            return IncludeMatch9999().IncludeMatchPlantation();
        }
        public MappingTransBaseSpec IncludeMatch9999()
        {
            Query.Include(b => b.Match9999s).ThenInclude(b => b.MatchDatas).ThenInclude(b => b.Mapping9999);

            return this;
        }
        public MappingTransBaseSpec IncludeMatchPlantation()
        {
            Query.Include(b => b.Match9999s).ThenInclude(b => b.MatchPlantations).ThenInclude(b => b.MasterActivity).ThenInclude(b => b.MasterActivityType);
            Query.Include(b => b.Match9999s).ThenInclude(b => b.MatchPlantations).ThenInclude(b => b.Plantation).ThenInclude(b => b.SubPlantations);

            return this;
        }
    }
}
