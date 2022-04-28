using Sketec.Infrastructure.Datas;
using Sketec.Infrastructure.Interfaces;

namespace Sketec.Infrastructure.UnitOfWorks
{
    public class WCUnitOfWork : UnitOfWork, IWCUnitOfWork
    {
        public WCUnitOfWork(SketecContext db) : base(db)
        {
        }
    }
}
