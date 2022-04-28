using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Sketec.Core.Interfaces
{
    public interface IUnitOfWork
    {
        int Save();
        Task<int> SaveAsync();
        int SaveNoStampDate();
        Task<int> SaveAsyncNoStampDate();
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        void Commit();
        Task CommitAsync();
        void Rollback();
        Task RollbackAsync();
        string Username { get; set; }
    }
}
