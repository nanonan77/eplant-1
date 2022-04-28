using static Dapper.SqlMapper;

namespace Sketec.Core.Abstracts
{
    public abstract class DapperMultipleQuerySpecification<T> : DapperSpecification<T> where T : class
    {
        abstract public T ProcessQuery(GridReader reader);
    }
}
