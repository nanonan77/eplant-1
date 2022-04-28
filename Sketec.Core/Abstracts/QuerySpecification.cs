using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Abstracts
{
    public abstract class QuerySpecification<TResult> where TResult : class
    {
        internal DbContext db { get; set; }

        protected IQueryable<TEntity> Set<TEntity>() where TEntity : class
        {
            return db.Set<TEntity>().AsNoTracking();
        }

        public abstract IQueryable<TResult> OnQuery();
    }
}
