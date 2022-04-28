using System;
using System.Collections.Generic;

namespace Sketec.Core.Abstracts
{
    public abstract class DapperSpecification<T> where T : class
    {
        public string Query { get; protected set; }
        public object Param { get; protected set; }

        public Func<IEnumerable<T>, IEnumerable<T>> ProcessAfterQuery { get; protected set; }
    }
}
