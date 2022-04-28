using Microsoft.EntityFrameworkCore;
using Sketec.Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Extensions
{
    public static class QuerySpecificationExtension
    {
        public static void SetDbContext<TResult>(this QuerySpecification<TResult> spec, DbContext db) where TResult : class
        {
            spec.db = db;
        }
    }
}
