using Ardalis.Specification;
using Sketec.Core.Domains;
using System;
using System.Linq;

namespace Sketec.Core.Specifications
{
    public class MappingTransSearchSpec : Specification<MappingTrans>
    {
        public MappingTransSearchSpec(MappingTransFilter filter)
        {
            if (!string.IsNullOrWhiteSpace(filter.TransactionNo))
                Query.Where(m => m.TransactionNo.Contains(filter.TransactionNo));

            if (!string.IsNullOrWhiteSpace(filter.Status))
            {
                var keyList = filter.Status.Split(",");
                Query.Where(m => keyList.Contains(m.Status));
            }

            if (!string.IsNullOrWhiteSpace(filter.Comment))
                Query.Where(m => m.Comment.Contains(filter.Comment));

            Query.Where(m => m.TransactionDate.Year == filter.Year);
            Query.Where(m => m.TransactionDate.Month == filter.Month);
        }
    }

    public class MappingTransFilter
    {

        public string TransactionNo { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
