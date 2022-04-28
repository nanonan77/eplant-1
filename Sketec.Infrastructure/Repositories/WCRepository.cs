using Sketec.Core.Interfaces;
using Sketec.Infrastructure.Datas;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sketec.Infrastructure.Repositories
{
    public class WCRepository<TEntity> : Repository<TEntity>, IWCRepository<TEntity> where TEntity : class, IEntity, IAggregateRoot
    {
        public WCRepository(SketecContext db) : base(db)
        {

        }
    }

    public class WCReadRepository<TEntity> : ReadRepository<TEntity>, IWCReadRepository<TEntity> where TEntity : class, IEntity
    {
        public WCReadRepository(SketecContext db) : base(db)
        {

        }
    }

    public class WCDapperRepository : DapperRepository, IWCDapperRepository
    {
        public WCDapperRepository(SketecContext db) : base(db)
        {
        }
    }

    public class WCQueryRepository : QueryRepository, IWCQueryRepository
    {
        public WCQueryRepository(SketecContext db) : base(db)
        {

        }
    }

}
