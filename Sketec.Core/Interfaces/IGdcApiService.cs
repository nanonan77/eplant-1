using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Interfaces
{
    public interface IGdcApiService
    {
        Task<string> GetAccessToken();
        Task<TResponse> Post<TRequest, TResponse>(string path, TRequest obj)
            where TResponse : class
            where TRequest : class;
    }
}
