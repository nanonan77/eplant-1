namespace Sketec.Core.Interfaces
{
    public interface IWCRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, IAggregateRoot
    {

    }

    public interface IWCReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : class, IEntity
    {

    }

    public interface IWCDapperRepository : IDapperRepository
    {

    }
}
