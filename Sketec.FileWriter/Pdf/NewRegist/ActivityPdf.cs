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
    public class ActivityPdf
    {
        PdfFont font;
        AssumptionPdfDto data;
        Color myColor = new DeviceRgb(189, 214, 238);
        Color colorHeader = new DeviceRgb(213, 213, 213);
        Color whiteColor = new DeviceRgb(255, 255, 255);


        public ActivityPdf()
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
                        pdf.SetDefaultPageSize(PageSize.A4.Rotate());
                        pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new PdfEventHandler());

                        var doc = new Document(pdf);
                        doc.SetFont(font);
                        doc.SetFontSize(10);

                        doc.Add(TableMain());
                        doc.Add(TableDetail());


                        doc.Close();

                        bytes = st.ToArray();
                    }
                }
            }
            return bytes;
        }

        private Table TableMain()
        {
            var table = new Table(new float[] { 1, 20, 10, 2, 50 })
                    .SetFixedLayout()
                    .SetWidth(UnitValue.CreatePercentValue(100));

            table.AddCellNoBorder(colSpan: 5)
                .Add(Util.P("เอกสารแนบ 2", align: "right"));

            table.AddCellNoBorder(colSpan: 5)
                .Add(Util.P("แผนการดำเนินงานระยะยาวทั้งโครงการ", align: "center").SetBold().SetUnderline());

            table.AddCellNoBorder(colSpan: 5)
                .Add(Util.P("1. พื้นที่เช่าปลูกสวนไม้ยูคาลิปตัส"));

            #region 1
            table.AddCellNoBorder()
                .Add(P(""));

            table.AddCellNoBorder()
                .Add(Util.P("1.1 พื้นที่เช่า"));

            table.AddCellNoBorder()
                .Add(Util.P(string.Format("{0:#,0.00}", data.RentalArea), align: "right"));

            table.AddCellNoBorder()
                .Add(Util.P("ไร่", align: "right"));

            table.AddCellNoBorder()
                .Add(P(""));
            #endregion 1

            #region 2
            table.AddCellNoBorder()
                .Add(P(""));

            table.AddCellNoBorder()
                .Add(Util.P("1.2 พื้นที่ปลูก (" + data.ProductiveAreaPercent.ToString() + "% ของพื้นที่ทั้งหมด)"));

            table.AddCellNoBorder()
                .Add(Util.P(string.Format("{0:#,0.00}", data.ProductiveArea), align: "right"));

            table.AddCellNoBorder()
                .Add(Util.P(" ไร่", align: "right"));

            table.AddCellNoBorder()
                .Add(P(""));
            #endregion 2

            return table;
        }


        private Table TableDetail()
        {

            var widthTitle = 20;
            var widthYear = 10;
            var txtRai = "บาทต่อไร่";

            if (data.ContractYear < 10)
            {
                widthYear = 7;
            }
            else if (data.ContractYear > 10)
            {
                widthTitle = 30;
                txtRai = "บาท\nต่อไร่";
            }

            var col = new List<float>(new float[] { 1, 1, widthTitle });

            for (var i = 0; i <= data.ContractYear; i++)
            {
                col.Add(widthYear);
            }

            var table = new Table(col.ToArray())
                    .SetFixedLayout()
                    .SetWidth(UnitValue.CreatePercentValue(100))
                    .SetMarginTop(7);


            Cell cell = new Cell(1, 3);
            cell.Add(P("2. ค่าใช้จ่ายในการปลูก (บาทต่อไร่)"));
            table.AddHeaderCell(cell).SetBackgroundColor(colorHeader);
            table.AddHeaderCell(P(txtRai).SetBackgroundColor(colorHeader).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE));
            for(var i=1; i<=data.ContractYear; i++)
            {
                table.AddHeaderCell(P("ปีที่ " +i.ToString()).SetBackgroundColor(colorHeader).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE));
            }

            var cnt = 1;
            foreach (var item in data.Expense.GroupBy(x => new { x.ActivityGroup, x.ActivityTypeId, x.ActivityTypeName }))
            {
                table.AddCell().SetBackgroundColor(myColor)
                    .Add(P(""));

                table.AddCell(1, 2).SetBackgroundColor(myColor)
                    .Add(P("2." + cnt.ToString() + " " + item.Key.ActivityTypeName).SetVerticalAlignment(VerticalAlignment.MIDDLE));

                table.AddCell().SetBackgroundColor(myColor)
                    .Add(P(string.Format("{0:#,0}", item.Sum(x => x.BahtPerRai)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                if (1 <= data.ContractYear)
                    table.AddCell().SetBackgroundColor(myColor)
                        .Add(P(string.Format("{0:#,0}", item.Sum(x => x.YearCost1)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                if (2 <= data.ContractYear)
                    table.AddCell().SetBackgroundColor(myColor)
                        .Add(P(string.Format("{0:#,0}", item.Sum(x => x.YearCost2)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                if (3 <= data.ContractYear)
                    table.AddCell().SetBackgroundColor(myColor)
                        .Add(P(string.Format("{0:#,0}", item.Sum(x => x.YearCost3)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                if (4 <= data.ContractYear)
                    table.AddCell().SetBackgroundColor(myColor)
                        .Add(P(string.Format("{0:#,0}", item.Sum(x => x.YearCost4)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                if (5 <= data.ContractYear)
                    table.AddCell().SetBackgroundColor(myColor)
                        .Add(P(string.Format("{0:#,0}", item.Sum(x => x.YearCost5)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                if (6 <= data.ContractYear)
                    table.AddCell().SetBackgroundColor(myColor)
                        .Add(P(string.Format("{0:#,0}", item.Sum(x => x.YearCost6)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                if (7 <= data.ContractYear)
                    table.AddCell().SetBackgroundColor(myColor)
                        .Add(P(string.Format("{0:#,0}", item.Sum(x => x.YearCost7)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                if (8 <= data.ContractYear)
                    table.AddCell().SetBackgroundColor(myColor)
                        .Add(P(string.Format("{0:#,0}", item.Sum(x => x.YearCost8)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                if (9 <= data.ContractYear)
                    table.AddCell().SetBackgroundColor(myColor)
                        .Add(P(string.Format("{0:#,0}", item.Sum(x => x.YearCost9)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                if (10 <= data.ContractYear)
                    table.AddCell().SetBackgroundColor(myColor)
                        .Add(P(string.Format("{0:#,0}", item.Sum(x => x.YearCost10)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                if (11 <= data.ContractYear)
                    table.AddCell().SetBackgroundColor(myColor)
                        .Add(P(string.Format("{0:#,0}", item.Sum(x => x.YearCost11)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                if (12 <= data.ContractYear)
                    table.AddCell().SetBackgroundColor(myColor)
                        .Add(P(string.Format("{0:#,0}", item.Sum(x => x.YearCost12)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                if (13 <= data.ContractYear)
                    table.AddCell().SetBackgroundColor(myColor)
                        .Add(P(string.Format("{0:#,0}", item.Sum(x => x.YearCost13)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                if (14 <= data.ContractYear)
                    table.AddCell().SetBackgroundColor(myColor)
                        .Add(P(string.Format("{0:#,0}", item.Sum(x => x.YearCost14)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                if (15 <= data.ContractYear)
                    table.AddCell().SetBackgroundColor(myColor)
                        .Add(P(string.Format("{0:#,0}", item.Sum(x => x.YearCost15)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                var cntDetail = 1;
                foreach (var detail in item)
                {
                    table.AddCell().SetBackgroundColor(whiteColor)
                        .Add(P(""));
                    
                    table.AddCell().SetBackgroundColor(whiteColor)
                        .Add(P(""));

                    table.AddCell().SetBackgroundColor(whiteColor)
                        .Add(P("2." + cnt.ToString() + "." + cntDetail.ToString() + " " + detail.ActivityName).SetVerticalAlignment(VerticalAlignment.MIDDLE));

                    table.AddCell().SetBackgroundColor(whiteColor)
                        .Add(P(string.Format("{0:#,0}", detail.BahtPerRai), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                    if (1 <= data.ContractYear)
                        table.AddCell().SetBackgroundColor(whiteColor)
                            .Add(P(string.Format("{0:#,0}", detail.YearCost1), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                    if (2 <= data.ContractYear)
                        table.AddCell().SetBackgroundColor(whiteColor)
                            .Add(P(string.Format("{0:#,0}", detail.YearCost2), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                    if (3 <= data.ContractYear)
                        table.AddCell().SetBackgroundColor(whiteColor)
                            .Add(P(string.Format("{0:#,0}", detail.YearCost3), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                    if (4 <= data.ContractYear)
                        table.AddCell().SetBackgroundColor(whiteColor)
                            .Add(P(string.Format("{0:#,0}", detail.YearCost4), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                    if (5 <= data.ContractYear)
                        table.AddCell().SetBackgroundColor(whiteColor)
                            .Add(P(string.Format("{0:#,0}", detail.YearCost5), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                    if (6 <= data.ContractYear)
                        table.AddCell().SetBackgroundColor(whiteColor)
                            .Add(P(string.Format("{0:#,0}", detail.YearCost6), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                    if (7 <= data.ContractYear)
                        table.AddCell().SetBackgroundColor(whiteColor)
                            .Add(P(string.Format("{0:#,0}", detail.YearCost7), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                    if (8 <= data.ContractYear)
                        table.AddCell().SetBackgroundColor(whiteColor)
                            .Add(P(string.Format("{0:#,0}", detail.YearCost8), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                    if (9 <= data.ContractYear)
                        table.AddCell().SetBackgroundColor(whiteColor)
                            .Add(P(string.Format("{0:#,0}", detail.YearCost9), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                    if (10 <= data.ContractYear)
                        table.AddCell().SetBackgroundColor(whiteColor)
                            .Add(P(string.Format("{0:#,0}", detail.YearCost10), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                    if (11 <= data.ContractYear)
                        table.AddCell().SetBackgroundColor(whiteColor)
                            .Add(P(string.Format("{0:#,0}", detail.YearCost11), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                    if (12 <= data.ContractYear)
                        table.AddCell().SetBackgroundColor(whiteColor)
                            .Add(P(string.Format("{0:#,0}", detail.YearCost12), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                    if (13 <= data.ContractYear)
                        table.AddCell().SetBackgroundColor(whiteColor)
                            .Add(P(string.Format("{0:#,0}", detail.YearCost13), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                    if (14 <= data.ContractYear)
                        table.AddCell().SetBackgroundColor(whiteColor)
                            .Add(P(string.Format("{0:#,0}", detail.YearCost14), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                    if (15 <= data.ContractYear)
                        table.AddCell().SetBackgroundColor(whiteColor)
                            .Add(P(string.Format("{0:#,0}", detail.YearCost15), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

                    cntDetail++;
                }
                cnt++;
            }

            table.AddCell(1, 3).SetBackgroundColor(colorHeader)
                .Add(P("รวมค่าใช้จ่ายค่าบริหารจัดการ").SetVerticalAlignment(VerticalAlignment.MIDDLE));

            table.AddCell().SetBackgroundColor(colorHeader)
                .Add(P(string.Format("{0:#,0}", data.Expense.Sum(x => x.BahtPerRai)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

            if (1 <= data.ContractYear)
                table.AddCell().SetBackgroundColor(colorHeader)
                    .Add(P(string.Format("{0:#,0}", data.Expense.Sum(x => x.YearCost1)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

            if (2 <= data.ContractYear)
                table.AddCell().SetBackgroundColor(colorHeader)
                    .Add(P(string.Format("{0:#,0}", data.Expense.Sum(x => x.YearCost2)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

            if (3 <= data.ContractYear)
                table.AddCell().SetBackgroundColor(colorHeader)
                    .Add(P(string.Format("{0:#,0}", data.Expense.Sum(x => x.YearCost3)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

            if (4 <= data.ContractYear)
                table.AddCell().SetBackgroundColor(colorHeader)
                    .Add(P(string.Format("{0:#,0}", data.Expense.Sum(x => x.YearCost4)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

            if (5 <= data.ContractYear)
                table.AddCell().SetBackgroundColor(colorHeader)
                    .Add(P(string.Format("{0:#,0}", data.Expense.Sum(x => x.YearCost5)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

            if (6 <= data.ContractYear)
                table.AddCell().SetBackgroundColor(colorHeader)
                    .Add(P(string.Format("{0:#,0}", data.Expense.Sum(x => x.YearCost6)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

            if (7 <= data.ContractYear)
                table.AddCell().SetBackgroundColor(colorHeader)
                    .Add(P(string.Format("{0:#,0}", data.Expense.Sum(x => x.YearCost7)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

            if (8 <= data.ContractYear)
                table.AddCell().SetBackgroundColor(colorHeader)
                    .Add(P(string.Format("{0:#,0}", data.Expense.Sum(x => x.YearCost8)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

            if (9 <= data.ContractYear)
                table.AddCell().SetBackgroundColor(colorHeader)
                    .Add(P(string.Format("{0:#,0}", data.Expense.Sum(x => x.YearCost9)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

            if (10 <= data.ContractYear)
                table.AddCell().SetBackgroundColor(colorHeader)
                    .Add(P(string.Format("{0:#,0}", data.Expense.Sum(x => x.YearCost10)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

            if (11 <= data.ContractYear)
                table.AddCell().SetBackgroundColor(colorHeader)
                    .Add(P(string.Format("{0:#,0}", data.Expense.Sum(x => x.YearCost11)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

            if (12 <= data.ContractYear)
                table.AddCell().SetBackgroundColor(colorHeader)
                    .Add(P(string.Format("{0:#,0}", data.Expense.Sum(x => x.YearCost12)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

            if (13 <= data.ContractYear)
                table.AddCell().SetBackgroundColor(colorHeader)
                    .Add(P(string.Format("{0:#,0}", data.Expense.Sum(x => x.YearCost13)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

            if (14 <= data.ContractYear)
                table.AddCell().SetBackgroundColor(colorHeader)
                    .Add(P(string.Format("{0:#,0}", data.Expense.Sum(x => x.YearCost14)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

            if (15 <= data.ContractYear)
                table.AddCell().SetBackgroundColor(colorHeader)
                    .Add(P(string.Format("{0:#,0}", data.Expense.Sum(x => x.YearCost15)), align: "right").SetVerticalAlignment(VerticalAlignment.MIDDLE));

            return table;
        }

        public static Paragraph P(string txt, int fontSize = 9, string align = "left")
        {
            return new Paragraph(txt ?? "\n")
                .SetFontSize(fontSize)
                .SetTextAlignment(align == "center" ? TextAlignment.CENTER : align == "right" ? TextAlignment.RIGHT : TextAlignment.LEFT);
            //.SetMultipliedLeading(1f);
        }
    }
}
