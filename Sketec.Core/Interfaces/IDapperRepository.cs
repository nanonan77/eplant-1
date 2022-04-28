using Sketec.Core.Abstracts;
using System.Collections.Generic;

namespace Sketec.Core.Interfaces
{
    public interface IDapperRepository
    {
        IEnumerable<T> Query<T>(DapperSpecification<T> specification) where T : class;
        T QueryMultiple<T>(DapperMultipleQuerySpecification<T> specification) where T : class;
    }
}
