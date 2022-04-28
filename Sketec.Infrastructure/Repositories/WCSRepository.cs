using Microsoft.EntityFrameworkCore;
using Sketec.Core.Interfaces;
using Sketec.Infrastructure.Interfaces;

namespace Sketec.Infrastructure.Repositories
{
    public class WCSRepository<TEntity> : Repository<TEntity>, IWCSRepository<TEntity> where TEntity : class, IEntity, IAggregateRoot
    {
        public WCSRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
