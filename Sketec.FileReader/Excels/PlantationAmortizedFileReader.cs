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
    public static class PlantationAmortizedFileReader
    {
        public static IEnumerable<PlantationAmortized> GetNewPlantationAmortized(byte[] byteArray,Guid plantationId)
        {
            var result = new List<PlantationAmortized>();
            using (Stream stream = new MemoryStream(byteArray))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage package = new ExcelPackage(stream);

                var ws = package.Workbook.Worksheets["Amortized"];

                if (ws == null)
                {
                    return null;
                }

                for (var i = 1; i <= ws.Dimension.End.Row; i++)
                {
                    if (ws.Cells[i, 3].GetDate("dd/MM/yyyy HH:mm") != null) {
                        var data = new PlantationAmortized
                        {
                            DueDate = ws.Cells[i, 3].GetDate("dd/MM/yyyy HH:mm"),
                            CashPaid = ws.Cells[i, 4].GetDecimal(),
                            MonthlyRental = ws.Cells[i, 6].GetDecimal(),
                            Interest = ws.Cells[i, 7].GetDecimal(),
                            Depreciation = ws.Cells[i, 19].GetDecimal()
                        };
                        result.Add(data);
                    }
                }
                return result;
            }
        }
    }
}