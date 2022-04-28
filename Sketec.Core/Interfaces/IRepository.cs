using Ardalis.Specification;

namespace Sketec.Core.Interfaces
{
    public interface IRepository<TEntity> : IRepositoryBase<TEntity>, IReadRepository<TEntity> where TEntity : class, IEntity, IAggregateRoot
    {
        public TEntity Add(TEntity entity);
        public void Delete(TEntity entity);
        public void Update(TEntity entity);
    }

    public interface IReadRepository<TEntity> : IReadRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        public void Detached(TEntity entity);
        public void DetachedAll();
    }
}
