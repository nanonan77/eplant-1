using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Sketec.FileWriter.Resources;
using System;
using System.IO;
using Sketec.FileWriter.Extensions;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Canvas.Draw;
using System.Collections.Generic;
using System.Linq;
using Sketec.FileWriter;
using iText.Kernel.Colors;
using iText.IO.Image;
using iText.Layout.Borders;
using Microsoft.Extensions.FileProviders;

namespace Sketec.FileWriter.Pdf
{
    public class SummaryPdf
    {
        PdfFont font;
        AssumptionPdfDto data;
        Color myColor = new DeviceRgb(189, 214, 238);
        public SummaryPdf()
        {
            font = Util.GetArial();

        }

        public byte[] Pdf(AssumptionPdfDto data)
        {
            this.data = data;
            byte[] bytes;
            using (var st = new MemoryStream())
            {
                using (var writer = new PdfWriter(st))
                {
                    using (var pdf = new PdfDocument(writer))
                    {
                        pdf.SetDefaultPageSize(PageSize.A4);
                        pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new PdfEventHandler());

                        var doc = new Document(pdf);
                        doc.SetFont(font);
                        doc.SetFontSize(10);


                        doc.Add(TableMain());

                        doc.Close();

                        bytes = st.ToArray();
                    }
                }
            }
            return bytes;
        }


        private Table TableMain()
        {
            var table = new Table(new float[] { 1, 15, 6, 4 })
                    .SetFixedLayout()
                    .SetWidth(UnitValue.CreatePercentValue(100))
                    ;

            table.AddCellNoBorder(1, 4)
                .Add(Util.P("เอกสารแนบ 5", align: "right"));

            table.AddCellNoBorder(1, 4)
                .Add(Util.P("สรุปงบประมาณเงินลงทุน", align: "center").SetBold().SetUnderline());

            #region 1
            var rentalFee = data.Expense.Where(x => x.ActivityGroup == "A").Sum(x => (x.YearCost1 ?? 0)
                                                                            + (x.YearCost2 ?? 0)
                                                                            + (x.YearCost3 ?? 0)
                                                                            + (x.YearCost4 ?? 0)
                                                                            + (x.YearCost5 ?? 0)
                                                                            + (x.YearCost6 ?? 0)
                                                                            + (x.YearCost7 ?? 0)
                                                                            + (x.YearCost8 ?? 0)
                                                                            + (x.YearCost9 ?? 0)
                                                                            + (x.YearCost10 ?? 0)
                                                                            + (x.YearCost11 ?? 0)
                                                                            + (x.YearCost12 ?? 0)
                                                                            + (x.YearCost13 ?? 0)
                                                                            + (x.YearCost14 ?? 0)
                                                                            + (x.YearCost15 ?? 0)
                                                                            ) * data.RentalArea / 1000000;
            table.AddCellNoBorder()
                .Add(Util.P("1."));
            table.AddCellNoBorder()
                .Add(Util.P("ค่าเช่าที่ดินตลอดทั้งโครงการ"));
            table.AddCellNoBorder()
                .Add(Util.P(string.Format("{0:#,0.00}", rentalFee), align: "right"));
            table.AddCellNoBorder()
                .Add(Util.P("ล้านบาท").SetPaddingLeft(10));
            #endregion 1

            #region 2
            List<string> activityGroup = new List<string>(new string[] { "B", "C", "D", "F" });
            var activity = data.Expense.Where(x => activityGroup.Contains(x.ActivityGroup)).Sum(x => (x.YearCost1 ?? 0)
                                                                            + (x.YearCost2 ?? 0)
                                                                            + (x.YearCost3 ?? 0)
                                                                            + (x.YearCost4 ?? 0)
                                                                            + (x.YearCost5 ?? 0)
                                                                            + (x.YearCost6 ?? 0)
                                                                            + (x.YearCost7 ?? 0)
                                                                            + (x.YearCost8 ?? 0)
                                                                            + (x.YearCost9 ?? 0)
                                                                            + (x.YearCost10 ?? 0)
                                                                            + (x.YearCost11 ?? 0)
                                                                            + (x.YearCost12 ?? 0)
                                                                            + (x.YearCost13 ?? 0)
                                                                            + (x.YearCost14 ?? 0)
                                                                            + (x.YearCost15 ?? 0)
                                                                            ) * data.ProductiveArea / 1000000;
            table.AddCellNoBorder()
                .Add(Util.P("2."));
            table.AddCellNoBorder()
                .Add(Util.P("ค่าใช้จ่ายการปรับพื้นที่ เตรียมพื้นที่ ปลูก และดูแลรักษา"));
            table.AddCellNoBorder()
                .Add(Util.P(string.Format("{0:#,0.00}", activity), align: "right"));
            table.AddCellNoBorder()
                .Add(Util.P("ล้านบาท").SetPaddingLeft(10));
            #endregion 2

            #region 3
            var product = data.CuttingCost * data.ProductiveArea * data.AssumptionYield.Sum(x => x.Yield) / 1000000;
            table.AddCellNoBorder()
                .Add(Util.P("3."));
            table.AddCellNoBorder()
                .Add(Util.P("ค่าใช้จ่ายในการเก็บเกี่ยว"));
            table.AddCellNoBorder()
                .Add(Util.P(string.Format("{0:#,0.00}", product), align: "right"));
            table.AddCellNoBorder()
                .Add(Util.P("ล้านบาท").SetPaddingLeft(10));
            #endregion 3

            #region 4
            var freight = data.Freight * data.ProductiveArea * data.AssumptionYield.Sum(x => x.Yield) / 1000000;
            table.AddCellNoBorder()
                .Add(Util.P("4."));
            table.AddCellNoBorder()
                .Add(Util.P("ค่าใช้จ่ายในการขนส่งไปที่โรงสับไม้"));
            table.AddCellNoBorder()
                .Add(Util.P(string.Format("{0:#,0.00}", freight), align: "right"));
            table.AddCellNoBorder()
                .Add(Util.P("ล้านบาท").SetPaddingLeft(10));
            #endregion 4

            #region 5
            var contingency = (rentalFee + activity + product + freight) * 0.02M;
            table.AddCellNoBorder()
                .Add(Util.P("5."));
            table.AddCellNoBorder()
                .Add(Util.P("Contingency 2%"));
            table.AddCellNoBorder()
                .Add(Util.P(string.Format("{0:#,0.00}", contingency), align: "right"));
            table.AddCellNoBorder()
                .Add(Util.P("ล้านบาท").SetPaddingLeft(10));
            #endregion 5

            #region End
            var summary = rentalFee + activity + product + freight + contingency;
            table.AddCellNoBorder()
                .Add(Util.P(""));
            table.AddCellNoBorder()
                .Add(Util.P("รวมค่าใช้จ่ายของโครงการที่ขออนุมัติ"));
            table.AddCellNoBorder()
                .Add(Util.P(string.Format("{0:#,0.00}", summary), align: "right").SetUnderline());
            table.AddCellNoBorder()
                .Add(Util.P("ล้านบาท").SetPaddingLeft(10));
            #endregion End

            return table;
        }

    }
}
