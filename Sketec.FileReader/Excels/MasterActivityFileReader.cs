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
    public static class MasterActivityFileReader
    {
        public static byte[] WriteMasterActivity(byte[] byteArray, IEnumerable<MasterActivityResultDto> data)
        {
            byte[] result = null;
            using (var st = new MemoryStream())
            {
                using (var stream = new MemoryStream(byteArray))
                {
                    using (var package = new ExcelPackage(st, stream))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        var ws = package.Workbook.Worksheets["Activity Master"];
                        if (ws == null)
                        {
                            return null;
                        }

                        var row = 1;
                        for (var i = 1; i <= ws.Dimension.End.Row; i++)
                        {
                            if (ws.Cells[i, 1].Value == null || ws.Cells[i, 1].Value.ToString() == "")
                            {
                                row = i;
                                break;
                            }
                        }

                        foreach (var item in data)
                        {
                            var c = 1;
                            ws.Cells[row, c++].Value = item.TitleEN;
                            ws.Cells[row, c++].Value = item.TitleTH;
                            ws.Cells[row, c++].Value = item.ActivityGroup;
                            ws.Cells[row, c++].Value = item.ActivityTH;
                            ws.Cells[row, c++].Value = item.ActivityEN;
                            ws.Cells[row, c++].Value = item.ActivityCode;
                            ws.Cells[row, c++].Value = item.IsActive ? "1" : "0";
                            ws.Cells[row, c++].Value = item.CreatedBy;
                            ws.Cells[row, c++].Value = item.CreatedDate?.ToString("dd/MM/yyyy HH:mm");
                            ws.Cells[row, c++].Value = item.UpdatedBy;
                            ws.Cells[row, c++].Value = item.UpdatedDate?.ToString("dd/MM/yyyy HH:mm");
                            row++;
                        }
                        package.Save();
                        result = st.ToArray();
                    }
                }
            }
            return result;
        }
    }
}
