using Sketec.Infrastructure.Data.WebCreditStaging;
using Sketec.Infrastructure.Interfaces;

namespace Sketec.Infrastructure.UnitOfWorks
{
    public class WCSUnitOfWork : UnitOfWork, IWCSUnitOfWork
    {
        public WCSUnitOfWork(WebCreditStagingContext db) : base(db)
        {

        }
    }
}
