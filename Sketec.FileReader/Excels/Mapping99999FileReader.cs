using OfficeOpenXml;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using Sketec.Core.Specifications;
using Sketec.FileReader.Resources;
using Sketec.FileReader.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.FileReader.Excels
{
    public static class Mapping99999FileReader
    {
        public static IEnumerable<Mapping9999> ReadMapping9999(byte[] byteArray)
        {
            var result = new List<Mapping9999>();
            using (Stream stream = new MemoryStream(byteArray))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage package = new ExcelPackage(stream);

                ExcelWorksheet ws = package.Workbook.Worksheets.FirstOrDefault();

                for (var i = 1; i <= ws.Dimension.End.Row; i++)
                {
                    if ( ws.Cells[i, Mapping99999Columns.ColumnCostCenter].Value != null)
                    {
                        if (i < Mapping99999Columns.RowDetailStart)
                        {
                            continue;
                        }

                        var data = new Mapping9999
                        {
                            CostCenter = ws.Cells[i, Mapping99999Columns.ColumnCostCenter].Value?.ToString(),
                            CostElement = ws.Cells[i, Mapping99999Columns.ColumnCostElement].Value?.ToString(),
                            Name = ws.Cells[i, Mapping99999Columns.ColumnName].Value?.ToString(),
                            PurchaseOrderText = ws.Cells[i, Mapping99999Columns.ColumnPurchaseOrderText].Value?.ToString(),
                            RefDocumentNumber = ws.Cells[i, Mapping99999Columns.ColumnRefDocumentNumber].Value?.ToString(),
                            PostingRow = ws.Cells[i, Mapping99999Columns.ColumnPostingRow].GetInt() ?? 0,
                            ValCOAreaCrcy = ws.Cells[i, Mapping99999Columns.ColumnValCOAreaCrcy].GetDecimal() ?? 0,
                            RefCompanyCode = ws.Cells[i, Mapping99999Columns.ColumnRefComanyCode].Value?.ToString(),
                            FiscalYear = ws.Cells[i, Mapping99999Columns.ColumnFiscalYear].GetInt() ?? 0
                        };
                        result.Add(data);
                    }
                }
                return result;
            }
        }
    }

    public static class Mapping99999Columns
    {
        public const int RowDetailStart = 2;

        public const int ColumnCostCenter = 1;
        public const int ColumnCostElement = 2;
        public const int ColumnName = 6;
        public const int ColumnPurchaseOrderText = 7;
        public const int ColumnRefDocumentNumber = 13;
        public const int ColumnPostingRow = 16;
        public const int ColumnValCOAreaCrcy = 29;
        public const int ColumnRefComanyCode = 31;
        public const int ColumnFiscalYear = 32;
    }
}
