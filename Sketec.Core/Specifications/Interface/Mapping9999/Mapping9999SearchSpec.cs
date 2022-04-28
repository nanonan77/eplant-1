using Ardalis.Specification;
using Sketec.Core.Abstracts;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sketec.Core.Specifications
{
    public class Mapping9999SearchSpec : Specification<Mapping9999>, ISingleResultSpecification
    {
        public Mapping9999SearchSpec(Mapping9999Filter filter)
        {
            Query.Where(m => m.IsActive == true);
            Query.Where(m => m.IsDelete == false);

            if (!string.IsNullOrWhiteSpace(filter.CostCenter))
                Query.Where(m => m.CostCenter == filter.CostCenter);
            if (!string.IsNullOrWhiteSpace(filter.CostElement))
                Query.Where(m => m.CostElement == filter.CostElement);
            if (!string.IsNullOrWhiteSpace(filter.RefCompanyCode))
                Query.Where(m => m.RefCompanyCode == filter.RefCompanyCode);
            if (!string.IsNullOrWhiteSpace(filter.RefDocumentNumber))
                Query.Where(m => m.RefDocumentNumber == filter.RefDocumentNumber);
            if (filter.PostingRow != null)
                Query.Where(m => m.PostingRow == filter.PostingRow);
            if (filter.FiscalYear != null)
                Query.Where(m => m.FiscalYear == filter.FiscalYear);
        }
    }

}
