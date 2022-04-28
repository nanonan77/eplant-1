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

namespace Sketec.FileWriter.Pdf
{
    public class NewRegistPdf
    {
        PdfFont font;
        AssumptionPdfDto data;
        public NewRegistPdf()
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

                        doc.Add(TableDetail());
                        doc.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                        doc.Add(TableImage());

                        doc.Close();

                        bytes = st.ToArray();
                    }
                }
            }
            return bytes;
        }

        private Table TableImage()
        {
            var table = new Table(new float[] { 1 })
                    .SetFixedLayout()
                    .SetWidth(UnitValue.CreatePercentValue(100));

            table.AddCellNoBorder()
                .Add(Util.P("เอกสารแนบ 1", align: "right"));

            table.AddCellNoBorder()
                .Add(Util.P("แผนภาพลักษณะพื้นที่เช่า", align: "center").SetBold().SetUnderline());

            table.AddCellNoBorder()
                .Add(Util.P("\n"));


            foreach(var item in data.NewRegist.NewRegistImagePaths.Where(x => x.IsSelectedStep2))
            {
                if (item.Base64 != null)
                {
                    ImageData imgData = ImageDataFactory.Create(item.Base64);
                    Image img = new Image(imgData);
                    table.AddCellNoBorder().SetPaddingTop(10).SetHorizontalAlignment(HorizontalAlignment.CENTER)
                    .Add(img.SetMaxWidth(UnitValue.CreatePercentValue(100)).SetMaxHeight(UnitValue.CreatePointValue(200f)).SetHorizontalAlignment(HorizontalAlignment.CENTER));
                }
            }

            return table;
        }

        private Table TableDetail()
        {
            var table = new Table(new float[] { 14, 1, 30 })
                    .SetFixedLayout()
                    .SetWidth(UnitValue.CreatePercentValue(100));


            table.AddCellNoBorder(colSpan: 3)
                .Add(Util.P("เอกสารแนบ 1", align: "right"));

            table.AddCellNoBorder(colSpan: 3)
                .Add(Util.P("รายละเอียดโครงการ", align: "center").SetBold().SetUnderline());

            #region 1
            table.AddCellNoBorder()
                .Add(Util.P("1. กำลังพลส่วนเพิ่ม"));
            table.AddCellNoBorder()
                .Add(Util.P(":"));
            table.AddCellNoBorder()
                .Add(Util.P("ไม่เพิ่ม"));
            #endregion 1

            #region 2
            table.AddCellNoBorder()
                .Add(Util.P("2. สถานที่ตั้ง"));
            table.AddCellNoBorder()
                .Add(Util.P(":"));
            table.AddCellNoBorder()
                .Add(Util.P("จังหวัด " + data.NewRegist.Province + " อำเภอ " + data.NewRegist.District + " ตำบล " + data.NewRegist.SubDistrict).SetTextAlignment(TextAlignment.JUSTIFIED));

            table.AddCellNoBorder(colSpan: 2);
            table.AddCellNoBorder()
                .Add(Util.P("ระยะทางจากแปลงเช่าถึง "+ data.Mill + " " + string.Format("{0:#,0}", data.DistanceToPlant) + " กิโลเมตร"));

            table.AddCellNoBorder(colSpan: 2);
            table.AddCellNoBorder()
                .Add(Util.P("พื้นที่รวม " + string.Format("{0:#,0.00}", data.RentalArea) + " ไร่"));

            table.AddCellNoBorder(colSpan: 2);
            table.AddCellNoBorder()
                .Add(Util.P("พื้นที่ใช้ประโยชน์ได้จริง " + string.Format("{0:#,0.00}", data.ProductiveArea) + " ไร่"));
            #endregion 2

            #region 3
            table.AddCellNoBorder()
                .Add(Util.P("3. ระยะสัญญาและค่าเช่า"));
            table.AddCellNoBorder()
                .Add(Util.P(":"));
            table.AddCellNoBorder()
                .Add(Util.P("สัญญาเช่า " + data.ContractYear.ToString() + " ปี (" + data.NewRegist.ContractStart.GetValueOrDefault().ToString("dd/MM/yyyy") + " - " + data.NewRegist.ContractEnd.GetValueOrDefault().ToString("dd/MM/yyyy") + ")"));

            foreach (var item in data.AssumptionYield)
            {
                table.AddCellNoBorder(colSpan: 2);
                table.AddCellNoBorder()
                    .Add(Util.P("ค่าเช่าเฉลี่ย " + item.YearStart.ToString() + "-" + item.YearEnd.ToString() + " ปี  " + string.Format("{0:#,0.00}", item.RentalFee) + " บาทต่อไร่ต่อปี"));
            }
            #endregion 3

            #region 4
            table.AddCellNoBorder()
                .Add(Util.P("4. ลักษณะทางกายภาพของพื้นที่"));
            table.AddCellNoBorder()
                .Add(Util.P(":"));
            table.AddCellNoBorder()
                .Add(Util.P("ชุดดิน "+ data.SoilType + " และปริมาณน้ำฝน " + data.Rainfall + " มิลลิลิตร"));

            table.AddCellNoBorder(colSpan: 2);
            table.AddCellNoBorder()
                .Add(Util.P(data.NewRegist.PhysicalArea));

            #endregion 4

            #region 5
            table.AddCellNoBorder()
                .Add(Util.P("5. ปริมาณไม้ที่จะได้จากโครงการ"));
            table.AddCellNoBorder()
                .Add(Util.P(":"));
            table.AddCellNoBorder()
                .Add(Util.P(string.Format("{0:#,0}", data.AssumptionYield.Sum(x => x.Yield ?? 0)) + " ตัน แบ่งเป็น " + data.CuttingRound.ToString() + " รอบตัดฟัน ดังนี้"));

            foreach(var item in data.AssumptionYield.OrderBy(x => x.Round))
            {

                table.AddCellNoBorder(colSpan: 2);
                table.AddCellNoBorder()
                    .Add(Util.P("ปริมาณไม้ที่จะได้จากรอบตัดฟันครั้งที่ " + item.Round.ToString() + " (ปี "+(data.NewRegist.ContractStart?.Year +  item.YearEnd)+") " + string.Format("{0:#,0}", item.Yield) + " ตัน"));
            }
            #endregion 5

            #region 6
            table.AddCellNoBorder()
                .Add(Util.P("6. ผลกระทบต่อสิ่งแวดล้อม"));
            table.AddCellNoBorder()
                .Add(Util.P(":"));
            table.AddCellNoBorder()
                .Add(Util.P("ไม่มีผลกระทบต่อสิ่งแวดล้อม"));
            #endregion 6

            #region 7
            table.AddCellNoBorder()
                .Add(Util.P("7. ผลกระทบด้านความปลอดภัย"));
            table.AddCellNoBorder()
                .Add(Util.P(":"));
            table.AddCellNoBorder()
                .Add(Util.P("ไม่มีผลกระทบด้านความปลอดภัย"));
            #endregion 7

            return table;
        }
    }
}
