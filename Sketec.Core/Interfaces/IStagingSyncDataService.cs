using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sketec.Core.Interfaces
{
    public interface IStagingSyncDataService
    {
        Task SyncData(DateTime dataDate, CancellationToken? cancellationToken = null);
    }
}
