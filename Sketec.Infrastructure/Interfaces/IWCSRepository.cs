using Sketec.Core.Interfaces;

namespace Sketec.Infrastructure.Interfaces
{
    public interface IWCSRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, IAggregateRoot
    {

    }
}
