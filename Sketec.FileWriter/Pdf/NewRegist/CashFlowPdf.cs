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
    public class CashFlowPdf
    {
        PdfFont font;
        AssumptionPdfDto data;
        Color myColor = new DeviceRgb(189, 214, 238);
        public CashFlowPdf()
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

                        var cnt = 0;

                        if ((data.AveragePrice ?? 0) != 0)
                        {
                            doc.Add(TableCurrent("Current"));
                            cnt++;
                        }
                        if ((data.MtpPrice ?? 0) != 0)
                        {
                            doc.Add(TableCurrent("MTP"));
                            cnt++;
                        }

                        if(cnt == 2 && (data.FcPrice ?? 0) != 0)
                            doc.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                        if ((data.FcPrice ?? 0) != 0)
                        {
                            doc.Add(TableCurrent("FC"));
                        }


                        doc.Close();

                        bytes = st.ToArray();
                    }
                }
            }
            return bytes;
        }

        private List<int> getCutRound()
        {
            List<int> round = new List<int>();
            if (data.CuttingRound == 1)
                round.Add(data.ContractYear);
            else
                round.Add(5);

            if (data.CuttingRound > 1)
                round.Add(10);

            if (data.CuttingRound > 2)
                round.Add(15);

            return round;
        }

        private List<decimal> getSFT()
        {
            List<decimal> sft = new List<decimal>();

            List<string> activityGroup = new List<string>(new string[] { "B", "C", "D", "F" });

            sft.Add((-1) * (((data.Expense.Where(x => x.ActivityGroup == "A").Sum(x => x.YearCost1) ?? 0) * (data.RentalArea ?? 0))
                        + ((data.Expense.Where(x => activityGroup.Contains(x.ActivityGroup)).Sum(x => x.YearCost1) ?? 0) * (data.ProductiveArea ?? 0))));

            sft.Add((-1) * (((data.Expense.Where(x => x.ActivityGroup == "A").Sum(x => x.YearCost2) ?? 0) * (data.RentalArea ?? 0))
                        + ((data.Expense.Where(x => activityGroup.Contains(x.ActivityGroup)).Sum(x => x.YearCost2) ?? 0) * (data.ProductiveArea ?? 0))));

            sft.Add((-1) * (((data.Expense.Where(x => x.ActivityGroup == "A").Sum(x => x.YearCost3) ?? 0) * (data.RentalArea ?? 0))
                        + ((data.Expense.Where(x => activityGroup.Contains(x.ActivityGroup)).Sum(x => x.YearCost3) ?? 0) * (data.ProductiveArea ?? 0))));

            sft.Add((-1) * (((data.Expense.Where(x => x.ActivityGroup == "A").Sum(x => x.YearCost4) ?? 0) * (data.RentalArea ?? 0))
                        + ((data.Expense.Where(x => activityGroup.Contains(x.ActivityGroup)).Sum(x => x.YearCost4) ?? 0) * (data.ProductiveArea ?? 0))));

            sft.Add((-1) * (((data.Expense.Where(x => x.ActivityGroup == "A").Sum(x => x.YearCost5) ?? 0) * (data.RentalArea ?? 0))
                        + ((data.Expense.Where(x => activityGroup.Contains(x.ActivityGroup)).Sum(x => x.YearCost5) ?? 0) * (data.ProductiveArea ?? 0))));

            sft.Add((-1) * (((data.Expense.Where(x => x.ActivityGroup == "A").Sum(x => x.YearCost6) ?? 0) * (data.RentalArea ?? 0))
                        + ((data.Expense.Where(x => activityGroup.Contains(x.ActivityGroup)).Sum(x => x.YearCost6) ?? 0) * (data.ProductiveArea ?? 0))));

            sft.Add((-1) * (((data.Expense.Where(x => x.ActivityGroup == "A").Sum(x => x.YearCost7) ?? 0) * (data.RentalArea ?? 0))
                        + ((data.Expense.Where(x => activityGroup.Contains(x.ActivityGroup)).Sum(x => x.YearCost7) ?? 0) * (data.ProductiveArea ?? 0))));

            sft.Add((-1) * (((data.Expense.Where(x => x.ActivityGroup == "A").Sum(x => x.YearCost8) ?? 0) * (data.RentalArea ?? 0))
                        + ((data.Expense.Where(x => activityGroup.Contains(x.ActivityGroup)).Sum(x => x.YearCost8) ?? 0) * (data.ProductiveArea ?? 0))));

            sft.Add((-1) * (((data.Expense.Where(x => x.ActivityGroup == "A").Sum(x => x.YearCost9) ?? 0) * (data.RentalArea ?? 0))
                        + ((data.Expense.Where(x => activityGroup.Contains(x.ActivityGroup)).Sum(x => x.YearCost9) ?? 0) * (data.ProductiveArea ?? 0))));

            sft.Add((-1) * (((data.Expense.Where(x => x.ActivityGroup == "A").Sum(x => x.YearCost10) ?? 0) * (data.RentalArea ?? 0))
                        + ((data.Expense.Where(x => activityGroup.Contains(x.ActivityGroup)).Sum(x => x.YearCost10) ?? 0) * (data.ProductiveArea ?? 0))));

            sft.Add((-1) * (((data.Expense.Where(x => x.ActivityGroup == "A").Sum(x => x.YearCost11) ?? 0) * (data.RentalArea ?? 0))
                        + ((data.Expense.Where(x => activityGroup.Contains(x.ActivityGroup)).Sum(x => x.YearCost11) ?? 0) * (data.ProductiveArea ?? 0))));

            sft.Add((-1) * (((data.Expense.Where(x => x.ActivityGroup == "A").Sum(x => x.YearCost12) ?? 0) * (data.RentalArea ?? 0))
                        + ((data.Expense.Where(x => activityGroup.Contains(x.ActivityGroup)).Sum(x => x.YearCost12) ?? 0) * (data.ProductiveArea ?? 0))));

            sft.Add((-1) * (((data.Expense.Where(x => x.ActivityGroup == "A").Sum(x => x.YearCost13) ?? 0) * (data.RentalArea ?? 0))
                        + ((data.Expense.Where(x => activityGroup.Contains(x.ActivityGroup)).Sum(x => x.YearCost13) ?? 0) * (data.ProductiveArea ?? 0))));

            sft.Add((-1) * (((data.Expense.Where(x => x.ActivityGroup == "A").Sum(x => x.YearCost14) ?? 0) * (data.RentalArea ?? 0))
                        + ((data.Expense.Where(x => activityGroup.Contains(x.ActivityGroup)).Sum(x => x.YearCost14) ?? 0) * (data.ProductiveArea ?? 0))));

            sft.Add((-1) * (((data.Expense.Where(x => x.ActivityGroup == "A").Sum(x => x.YearCost15) ?? 0) * (data.RentalArea ?? 0))
                        + ((data.Expense.Where(x => activityGroup.Contains(x.ActivityGroup)).Sum(x => x.YearCost15) ?? 0) * (data.ProductiveArea ?? 0))));


            return sft;
        }

        private List<decimal> getCutting()
        {
            List<decimal> cutting = new List<decimal>();

            foreach (var item in data.AssumptionYield)
            {
                cutting.Add(((data.CuttingCost ?? 0) + (data.Freight ?? 0)) * ((data.ProductiveArea ?? 0) * (item.Yield ?? 0)) * (-1));
            }
            return cutting;
        }


        private List<decimal> getCurrent(string type = "Current")
        {
            List<decimal> current = new List<decimal>();

            foreach (var item in data.AssumptionYield)
            {
                if (type == "Current")
                    current.Add(((data.AveragePrice ?? 0) - (data.PriceAtPlant ?? 0) - (data.Freight ?? 0)) * ((data.ProductiveArea ?? 0) * (item.Yield ?? 0)) * (-1) * (0.2M));
                else if (type == "MTP")
                    current.Add(((data.MtpPrice ?? 0) - (data.PriceAtPlant ?? 0) - (data.Freight ?? 0)) * ((data.ProductiveArea ?? 0) * (item.Yield ?? 0)) * (-1) * (0.2M));
                else if (type == "FC")
                    current.Add(((data.FcPrice ?? 0) - (data.PriceAtPlant ?? 0) - (data.Freight ?? 0)) * ((data.ProductiveArea ?? 0) * (item.Yield ?? 0)) * (-1) * (0.2M));
            }
            return current;
        }
        private List<decimal> getCurrentWood(string type = "Current")
        {
            List<decimal> current = new List<decimal>();

            foreach (var item in data.AssumptionYield)
            {
                if (type == "Current")
                    current.Add((data.AveragePrice ?? 0) * ((data.ProductiveArea ?? 0) * (item.Yield ?? 0)));
                else if (type == "MTP")
                    current.Add((data.MtpPrice ?? 0) * ((data.ProductiveArea ?? 0) * (item.Yield ?? 0)));
                else if (type == "FC")
                    current.Add((data.FcPrice ?? 0) * ((data.ProductiveArea ?? 0) * (item.Yield ?? 0)));
            }
            return current;
        }

        private Table TableSummary(double percent, double[] amountForIRR)
        {
            var table = new Table(new float[] { 1, 1, 1 })
                    .SetFixedLayout()
                    .SetWidth(UnitValue.CreatePercentValue(30))
                    .SetMarginTop(10)
                    ;

            double irr = 0;
            try
            {
                irr = Microsoft.VisualBasic.Financial.IRR(ref amountForIRR);
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Cannot calculate IRR.");
            }
            double npv = 0;

            try
            {
                npv = Microsoft.VisualBasic.Financial.NPV(percent, ref amountForIRR) / 1000000;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Cannot calculate NPV.");
            }
            

            table.AddCellNoBorder()
                .Add(Util.P("NPV @ " + (percent*100).ToString() + " %").SetMultipliedLeading(0.9f));

            table.AddCellNoBorder()
                .Add(Util.P(string.Format("{0:#,0.0}", npv), align: "right").SetFontColor(ColorConstants.BLUE).SetMultipliedLeading(0.9f));

            table.AddCellNoBorder()
                .Add(Util.P("MB").SetPaddingLeft(15).SetMultipliedLeading(0.9f));


            table.AddCellNoBorder()
                .Add(Util.P("IRR").SetMultipliedLeading(0.9f));

            table.AddCellNoBorder()
                .Add(Util.P(string.Format("{0:#,0.0}", irr*100) + "%", align: "right").SetFontColor(ColorConstants.BLUE).SetMultipliedLeading(0.9f));

            return table;
        }

        public static Paragraph PFormat(decimal amount)
        {
            amount = amount / 1000000;
            var format = string.Format("{0:#,0.0}", Math.Abs(amount));
            if (amount < 0)
                format = "(" + format + ")";

            return new Paragraph(format)
                .SetFontSize(11)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontColor(amount < 0 ? ColorConstants.RED : ColorConstants.BLACK);
        }

        private Table TableCurrent(string type = "Current")
        {
            var topic = "ราคาเฉลี่ยหน้าโรงงานปัจจุบัน";
            if(type == "MTP")
                topic = "ราคา MTP Agent หน้าโรงงาน";
            else if (type == "FC")
                topic = "ราคา FC Target";

            var cutRound = getCutRound();
            var widthYear = 10;
            var col = new List<float>(new float[] { 30 });

            for (var i = 1; i <= data.ContractYear; i++)
            {
                col.Add(widthYear);
            }
            var table = new Table(col.ToArray())
                    .SetFixedLayout()
                    .SetWidth(UnitValue.CreatePercentValue(100))
                    .SetMarginTop(7)
                    .SetMarginBottom(7);

            table.AddCellNoBorder(1, 6)
                .Add(Util.P(topic).SetBold());
            table.AddCellNoBorder(1, data.ContractYear - 5)
                .Add(Util.P("Unit: Million Baht", align: "right"));

            #region 1
            table.AddCell().SetBorderRight(new SolidBorder(1))
                .Add(Util.P("Description").SetBold().SetMultipliedLeading(0.8f));

            for (var i = 1; i <= data.ContractYear; i++)
            {
                if (cutRound.Contains(i))
                    table.AddCell().SetBorderLeft(new DottedBorder(1))
                    .Add(Util.P("Yr " + i.ToString(), align: "center").SetBold().SetMultipliedLeading(0.8f));
                else
                    table.AddCell().SetBorderLeft(new DottedBorder(1)).SetBorderRight(new DottedBorder(1))
                        .Add(Util.P("Yr " + i.ToString(), align: "center").SetBold().SetMultipliedLeading(0.8f));
            }
            #endregion 1

            #region 2
            table.AddCell().SetBorderBottom(Border.NO_BORDER).SetBorderRight(new SolidBorder(1))
                .Add(Util.P("Cash Outflows :").SetBold().SetMultipliedLeading(0.8f));


            for (var i = 1; i <= data.ContractYear; i++)
            {
                if (cutRound.Contains(i))
                    table.AddCell().SetBorderLeft(new DottedBorder(1)).SetBorderBottom(Border.NO_BORDER)
                    .Add(Util.P("", align: "center").SetBold().SetMultipliedLeading(0.8f));
                else
                    table.AddCell().SetBorderLeft(new DottedBorder(1)).SetBorderRight(new DottedBorder(1)).SetBorderBottom(Border.NO_BORDER)
                        .Add(Util.P("", align: "center").SetBold().SetMultipliedLeading(0.8f));
            }
            #endregion 2

            #region 3
            table.AddCell().SetBorderTop(Border.NO_BORDER).SetBorderBottom(Border.NO_BORDER).SetBorderRight(new SolidBorder(1))
                .Add(Util.P(" - SFT Operating Expenses").SetMultipliedLeading(0.8f));

            var sft = getSFT();
            for (var i = 1; i <= data.ContractYear; i++)
            {
                if (cutRound.Contains(i))
                    table.AddCell().SetBorderLeft(new DottedBorder(1)).SetBorderTop(Border.NO_BORDER).SetBorderBottom(Border.NO_BORDER)
                    .Add(PFormat(sft[i - 1]).SetMultipliedLeading(0.8f));
                else
                    table.AddCell().SetBorderLeft(new DottedBorder(1)).SetBorderRight(new DottedBorder(1)).SetBorderTop(Border.NO_BORDER).SetBorderBottom(Border.NO_BORDER)
                    .Add(PFormat(sft[i - 1]).SetMultipliedLeading(0.8f));
            }
            #endregion 3

            #region 4
            table.AddCell().SetBorderTop(Border.NO_BORDER).SetBorderBottom(Border.NO_BORDER).SetBorderRight(new SolidBorder(1))
                .Add(Util.P(" - Cutting and Transportation").SetMultipliedLeading(0.8f));

            var cutting = getCutting();
            var cnt = 0;
            for (var i = 1; i <= data.ContractYear; i++)
            {
                if (cutRound.Contains(i))
                {
                    table.AddCell().SetBorderLeft(new DottedBorder(1)).SetBorderTop(Border.NO_BORDER).SetBorderBottom(Border.NO_BORDER)
                    .Add(PFormat(cutting[cnt]).SetMultipliedLeading(0.8f));
                    cnt++;
                }
                else
                    table.AddCell().SetBorderLeft(new DottedBorder(1)).SetBorderRight(new DottedBorder(1)).SetBorderTop(Border.NO_BORDER).SetBorderBottom(Border.NO_BORDER)
                        .Add(Util.P("", align: "center").SetMultipliedLeading(0.8f));
            }
            #endregion 4

            #region 5
            table.AddCell().SetBorderTop(Border.NO_BORDER).SetBorderBottom(Border.NO_BORDER).SetBorderRight(new SolidBorder(1))
                .Add(Util.P(" - Incremental Tax").SetMultipliedLeading(0.8f));
            var current = getCurrent(type);
            cnt = 0;
            for (var i = 1; i <= data.ContractYear; i++)
            {
                if (cutRound.Contains(i))
                {
                    table.AddCell().SetBorderLeft(new DottedBorder(1)).SetBorderTop(Border.NO_BORDER).SetBorderBottom(Border.NO_BORDER)
                    .Add(PFormat(current[cnt]).SetMultipliedLeading(0.8f));
                    cnt++;
                }
                else
                    table.AddCell().SetBorderLeft(new DottedBorder(1)).SetBorderRight(new DottedBorder(1)).SetBorderTop(Border.NO_BORDER).SetBorderBottom(Border.NO_BORDER)
                        .Add(Util.P("", align: "center").SetMultipliedLeading(0.8f));
            }
            #endregion 5

            #region 6
            table.AddCell().SetBorderTop(Border.NO_BORDER).SetBorderRight(new SolidBorder(1))
                .Add(Util.P("Total Cash Outflows").SetBold().SetMultipliedLeading(0.8f));

            cnt = 0;
            for (var i = 1; i <= data.ContractYear; i++)
            {
                if (cutRound.Contains(i))
                {
                    table.AddCell().SetBorderLeft(new DottedBorder(1)).SetBorderTop(new DottedBorder(1))
                        .Add(PFormat(sft[i - 1] + cutting[cnt] + current[cnt]).SetBold().SetMultipliedLeading(0.8f));
                    cnt++;
                }
                else
                    table.AddCell().SetBorderLeft(new DottedBorder(1)).SetBorderRight(new DottedBorder(1)).SetBorderTop(new DottedBorder(1))
                        .Add(PFormat(sft[i - 1]).SetBold().SetMultipliedLeading(0.8f));
            }
            #endregion 6

            #region 7
            table.AddCell().SetBorderBottom(Border.NO_BORDER).SetBorderRight(new SolidBorder(1))
                .Add(Util.P("Cash Inflows :").SetBold().SetMultipliedLeading(0.8f));


            for (var i = 1; i <= data.ContractYear; i++)
            {
                if (cutRound.Contains(i))
                    table.AddCell().SetBorderLeft(new DottedBorder(1)).SetBorderBottom(Border.NO_BORDER)
                    .Add(Util.P("", align: "center").SetBold().SetMultipliedLeading(0.8f));
                else
                    table.AddCell().SetBorderLeft(new DottedBorder(1)).SetBorderRight(new DottedBorder(1)).SetBorderBottom(Border.NO_BORDER)
                        .Add(Util.P("", align: "center").SetBold().SetMultipliedLeading(0.8f));
            }
            #endregion 7

            #region 8
            table.AddCell().SetBorderTop(Border.NO_BORDER).SetBorderBottom(Border.NO_BORDER).SetBorderRight(new SolidBorder(1))
                .Add(Util.P(" - Wood (at Market Price)").SetMultipliedLeading(0.8f));

            var currentWood = getCurrentWood(type);
            cnt = 0;
            for (var i = 1; i <= data.ContractYear; i++)
            {
                if (cutRound.Contains(i))
                {
                    table.AddCell().SetBorderLeft(new DottedBorder(1)).SetBorderTop(Border.NO_BORDER).SetBorderBottom(Border.NO_BORDER)
                    .Add(PFormat(currentWood[cnt]).SetMultipliedLeading(0.8f));
                    cnt++;
                }
                else
                    table.AddCell().SetBorderLeft(new DottedBorder(1)).SetBorderRight(new DottedBorder(1)).SetBorderTop(Border.NO_BORDER).SetBorderBottom(Border.NO_BORDER)
                        .Add(Util.P("", align: "center").SetMultipliedLeading(0.8f));
            }
            #endregion 8

            #region 9
            table.AddCell().SetBorderTop(Border.NO_BORDER).SetBorderRight(new SolidBorder(1))
                .Add(Util.P("Total Cash Inflows").SetBold().SetMultipliedLeading(0.8f));

            cnt = 0;
            for (var i = 1; i <= data.ContractYear; i++)
            {
                if (cutRound.Contains(i))
                {
                    table.AddCell().SetBorderLeft(new DottedBorder(1)).SetBorderTop(new DottedBorder(1))
                        .Add(PFormat(currentWood[cnt]).SetBold().SetMultipliedLeading(0.8f));
                    cnt++;
                }
                else
                    table.AddCell().SetBorderLeft(new DottedBorder(1)).SetBorderRight(new DottedBorder(1)).SetBorderTop(new DottedBorder(1))
                        .Add(Util.P("").SetBold().SetMultipliedLeading(0.8f));
            }
            #endregion 9

            #region 10
            table.AddCell().SetBorderTop(Border.NO_BORDER).SetBorderRight(new SolidBorder(1))
                .Add(Util.P("Net Cashflow for IRR").SetBold().SetMultipliedLeading(0.8f));

            List<double> amountForIRR = new List<double>();
            cnt = 0;
            for (var i = 1; i <= data.ContractYear; i++)
            {
                if (cutRound.Contains(i))
                {
                    amountForIRR.Add( Decimal.ToDouble(sft[i - 1] + cutting[cnt] + current[cnt] + currentWood[cnt]));
                    table.AddCell().SetBorderLeft(new DottedBorder(1)).SetBorderTop(new DottedBorder(1))
                        .Add(PFormat(sft[i - 1] + cutting[cnt] + current[cnt] + currentWood[cnt]).SetBold().SetMultipliedLeading(0.8f));
                    cnt++;
                }
                else
                {
                    amountForIRR.Add(Decimal.ToDouble(sft[i - 1]));
                    table.AddCell().SetBorderLeft(new DottedBorder(1)).SetBorderRight(new DottedBorder(1)).SetBorderTop(new DottedBorder(1))
                        .Add(PFormat(sft[i - 1]).SetBold().SetMultipliedLeading(0.8f));
                }
            }
            #endregion 10

            double percent = 2;
            if (type == "Current")
                percent = Decimal.ToDouble((data.AverageRate ?? 0) / 100);
            else if (type == "MTP")
                percent = Decimal.ToDouble((data.MtpRate ?? 0) / 100);
            else if (type == "FC")
                percent = Decimal.ToDouble((data.FcRate ?? 0)/ 100);

            table.AddCellNoBorder(1, data.ContractYear + 1).SetHorizontalAlignment(HorizontalAlignment.CENTER)
                .Add(TableSummary(percent, amountForIRR.ToArray()).SetHorizontalAlignment(HorizontalAlignment.CENTER));

            return table;
        }


        private Table TableMain()
        {
            var table = new Table(new float[] { 1 })
                    .SetFixedLayout()
                    .SetWidth(UnitValue.CreatePercentValue(100));

            table.AddCellNoBorder()
                .Add(Util.P("เอกสารแนบ 4", align: "right"));

            table.AddCellNoBorder()
                .Add(Util.P("คำนวณผลตอบแทนการลงทุน", align: "center").SetBold().SetUnderline());

            return table;
        }

    }
}
