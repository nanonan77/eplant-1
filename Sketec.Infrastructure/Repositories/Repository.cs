using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sketec.Core.Abstracts;
using Sketec.Core.Exceptions;
using Sketec.Core.Extensions;
using Sketec.Core.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sketec.Infrastructure.Repositories
{
    abstract public class ReadRepository<TEntity> : RepositoryBase<TEntity>, IReadRepository<TEntity> where TEntity : class, IEntity
    {
        protected DbContext db;
        public ReadRepository(DbContext dbContext) : base(dbContext)
        {
            db = dbContext;
        }

        public override Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new InfrastructureException("Action for this method is denied from ReadRepository.");
        }
        public override Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new InfrastructureException("Action for this method is denied from ReadRepository.");
        }

        public override Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            throw new InfrastructureException("Action for this method is denied from ReadRepository.");
        }

        public override Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new InfrastructureException("Action for this method is denied from ReadRepository.");
        }
        public override Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new InfrastructureException("Action for this method is denied from ReadRepository.");
        }

        public void Detached(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Detached;
        }

        public void DetachedAll()
        {
            foreach (var entity in db.ChangeTracker.Entries())
            {
                entity.State = EntityState.Detached;
            }
        }
    }

    abstract public class Repository<TEntity> : ReadRepository<TEntity>, IRepository<TEntity> where TEntity : class, IEntity, IAggregateRoot
    {
        public Repository(DbContext dbContext) : base(dbContext)
        {
            db = dbContext;
        }

        public TEntity Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            return entity;
        }

        public override async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await db.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
        }

        public override Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            db.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        public override Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            db.Set<TEntity>().RemoveRange(entities);
            return Task.CompletedTask;
        }

        public override Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new InfrastructureException("Do not use Savechgange in repository, please use this method in UnitOfWork instead.");
        }

        public void Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public override Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            db.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }

    abstract public class QueryRepository : IQueryRepository
    {
        DbContext db;
        public QueryRepository(DbContext db)
        {
            this.db = db;
        }

        public Task<TResult> FirstAsync<TResult>(QuerySpecification<TResult> specification) where TResult : class
        {
            specification.SetDbContext(db);
            var query = specification.OnQuery();
            return query.FirstOrDefaultAsync();
        }

        public Task<List<TResult>> ListAsync<TResult>(QuerySpecification<TResult> specification) where TResult : class
        {
            specification.SetDbContext(db);
            var query = specification.OnQuery();
            return query.ToListAsync();
        }
    }
}
