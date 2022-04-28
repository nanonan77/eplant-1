using Sketec.Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Interfaces
{
    public interface IQueryRepository
    {
        Task<List<TResult>> ListAsync<TResult>(QuerySpecification<TResult> specification) where TResult : class;
        Task<TResult> FirstAsync<TResult>(QuerySpecification<TResult> specification) where TResult : class;
    }
}
