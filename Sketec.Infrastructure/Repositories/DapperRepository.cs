using Dapper;
using EnsureThat;
using Microsoft.EntityFrameworkCore;
using Sketec.Core.Abstracts;
using Sketec.Core.Interfaces;
using System.Collections.Generic;

namespace Sketec.Infrastructure.Repositories
{
    public abstract class DapperRepository : IDapperRepository
    {
        DbContext db;
        public DapperRepository(DbContext db)
        {
            this.db = db;
        }

        public IEnumerable<T> Query<T>(DapperSpecification<T> specification) where T : class
        {
            Ensure.String.IsNotNullOrWhiteSpace(specification.Query, nameof(specification.Query));

            var query = db.Database.GetDbConnection().Query<T>(specification.Query, specification.Param, commandTimeout: 180);

            if (specification.ProcessAfterQuery != null)
                query = specification.ProcessAfterQuery(query);

            return query;
        }

        public T QueryMultiple<T>(DapperMultipleQuerySpecification<T> specification) where T : class
        {
            Ensure.String.IsNotNullOrWhiteSpace(specification.Query, nameof(specification.Query));

            using (var multi = db.Database.GetDbConnection().QueryMultiple(specification.Query, commandTimeout: 180))
            {
                return specification.ProcessQuery(multi);
            }
        }
    }
}
