using Ardalis.Specification;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using System;
using Sketec.Core.Abstracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{
    public class Mapping9999QuerySpec : DapperSpecification<Mapping9999SearchDto>
    {

        public Mapping9999QuerySpec(Mapping9999Filter filter)
        {

            var queryStr = @$"SELECT m.Id Mapping9999Id, m.Year, m.Month, m.CostCenter, m.CostElement, m.Name, m.PurchaseOrderText, m.RefDocumentNumber,
                            m.PostingRow, m.ValCOAreaCrcy, m.RefCompanyCode, m.FiscalYear, d.CreatedBy, d.CreatedDate, d.UpdatedBy, d.UpdatedDate,
                            h.Id Match9999Id, 
                            t.Id MappingTransId, t.TransactionNo, t.TransactionDate, t.Status
                    FROM dbo.Mapping9999 m WITH(NOLOCK)
                        LEFT JOIN dbo.MatchData d WITH(NOLOCK) ON m.Id = d.Mapping9999Id
                        LEFT JOIN dbo.Match9999 h WITH(NOLOCK) ON d.Match9999Id = h.Id
                        LEFT JOIN dbo.MappingTrans t WITH(NOLOCK) ON h.MappingTransId = t.Id
                                                                AND t.Status <> 'Rejected'
                    WHERE m.Year = {filter.Year}
                    AND m.Month = {filter.Month}
                    AND t.Id IS NULL";

            if (!string.IsNullOrWhiteSpace(filter.CostCenter))
                queryStr += $" AND m.CostCenter like '%{filter.CostCenter}%'";
            if (!string.IsNullOrWhiteSpace(filter.CostElement))
                queryStr += $" AND m.CostElement like '%{filter.CostElement}%'";
            if (!string.IsNullOrWhiteSpace(filter.RefDocumentNumber))
                queryStr += $" AND m.RefDocumentNumber like '%{filter.RefDocumentNumber}%'";
            if (!string.IsNullOrWhiteSpace(filter.PurchaseOrderText))
                queryStr += $" AND m.PurchaseOrderText like '%{filter.PurchaseOrderText}%'";
            if (!string.IsNullOrWhiteSpace(filter.Name))
                queryStr += $" AND m.Name like '%{filter.Name}%'";

            queryStr += $" ORDER BY m.Year, m.Month, m.CostCenter, m.CostElement, m.RefCompanyCode, m.RefDocumentNumber";

            Query = queryStr;
        }
    }
    public class Mapping9999SearchDto
    {
        public string Key { get; set; }
        public string KeyGroup { get; set; }
        public Guid Mapping9999Id { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public string CostCenter { get; set; }
        public string CostElement { get; set; }
        public string Name { get; set; }
        public string PurchaseOrderText { get; set; }
        public string RefDocumentNumber { get; set; }
        public int? PostingRow { get; set; }
        public decimal? ValCOAreaCrcy { get; set; }
        public string RefCompanyCode { get; set; }
        public int? FiscalYear { get; set; }


        public Guid? MappingTransId { get; set; }
        public string TransactionNo { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string Status { get; set; }

        public Guid? Match9999Id { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public IEnumerable<Mapping9999SearchDto> Children { get; set; }
    }

    public class Mapping9999Filter
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string CostCenter { get; set; }
        public string CostElement { get; set; }
        public string Status { get; set; }
        public string TransactionNo { get; set; }
        public string RefCompanyCode { get; set; }
        public string RefDocumentNumber { get; set; }
        public string PurchaseOrderText { get; set; }
        public string Name { get; set; }
        public int? FiscalYear { get; set; }
        public int? PostingRow { get; set; }
    }
    public class Mapping9999ForCreate
    {
        public Guid Id { get; set; }
    }

    public class Mapping99999UploadExcel
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public byte[] Data { get; set; }
    }
}
