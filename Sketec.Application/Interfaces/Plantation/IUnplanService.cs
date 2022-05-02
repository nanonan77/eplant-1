using Sketec.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces.Plantation
{
    public interface IUnplanService : IApplicationService
    {
        Task<List<UnplanSearchResult>> GetUnplan(UnplanSearchFilter filter);
    }
}
