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
    public class ReturnOfInvestmentPdf
    {
        PdfFont font;
        AssumptionPdfDto data;
        Color myColor = new DeviceRgb(189, 214, 238);
        public ReturnOfInvestmentPdf()
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
                .Add(Util.P("เอกสารแนบ 3", align: "right"));

            table.AddCellNoBorder()
                .Add(Util.P("ตารางสถิติผลผลิตเทียบปริมาณน้ำฝนและชุดดิน", align: "center").SetBold().SetUnderline());

            table.AddCellNoBorder().SetHorizontalAlignment(HorizontalAlignment.CENTER)
                .Add(TableClone().SetHorizontalAlignment(HorizontalAlignment.CENTER));

            foreach (var item in data.NewRegist.NewRegistImagePaths.Where(x => x.IsSelectedStep3))
            {
                if (item.Base64 != null)
                {
                    ImageData imgData = ImageDataFactory.Create(item.Base64);
                    Image img = new Image(imgData);
                    table.AddCellNoBorder().SetPaddingTop(10).SetHorizontalAlignment(HorizontalAlignment.CENTER)
                    .Add(img.SetMaxWidth(UnitValue.CreatePercentValue(100)).SetMaxHeight(UnitValue.CreatePointValue(200f)).SetHorizontalAlignment(HorizontalAlignment.CENTER));
                }
            }

            foreach (var item in data.NewRegist.NewRegistImageOther)
            {
                if (item.Base64 != null)
                {
                    ImageData imgData = ImageDataFactory.Create(item.Base64);
                    Image img = new Image(imgData);
                    table.AddCellNoBorder().SetPaddingTop(10).SetHorizontalAlignment(HorizontalAlignment.CENTER)
                    .Add(img.SetMaxWidth(UnitValue.CreatePercentValue(100)).SetMaxHeight(UnitValue.CreatePointValue(200f)).SetHorizontalAlignment(HorizontalAlignment.CENTER));
                }
            }

            table.AddCellNoBorder().SetPaddingTop(10)
                .Add(Util.P("4. ประมาณการค่าใช้จ่ายในการปลูกและดูแลสวนไม้"));

            table.AddCellNoBorder().SetHorizontalAlignment(HorizontalAlignment.CENTER)
                .Add(TableDetail().SetHorizontalAlignment(HorizontalAlignment.CENTER));

            return table;
        }

        private Table TableClone()
        {
            var table = new Table(new float[] { 1, 1, 1, 1 })
                    .SetFixedLayout()
                    .SetWidth(UnitValue.CreatePercentValue(50))
                    .SetMarginTop(10)
                    .SetMarginBottom(10);

            table.AddCell().SetBackgroundColor(myColor)
                .Add(Util.P("สายพันธุ์", align: "center").SetBold());
            table.AddCell().SetBackgroundColor(myColor)
                .Add(Util.P("Portion for\nplanting\n(%)", align: "center").SetBold());
            table.AddCell().SetBackgroundColor(myColor)
                .Add(Util.P("Area (ไร่)", align: "center").SetBold());
            table.AddCell().SetBackgroundColor(myColor)
                .Add(Util.P("ผลผลิต (ตัน)", align: "center").SetBold());

            foreach(var item in data.AssumptionClone)
            {
                table.AddCell()
                    .Add(Util.P(item.Clone, align: "center"));
                table.AddCell()
                    .Add(Util.P(string.Format("{0:#,0}", item.Portion) + "%", align: "center"));
                table.AddCell()
                    .Add(Util.P(string.Format("{0:#,0.00}", item.Area), align: "center"));
                table.AddCell()
                    .Add(Util.P(string.Format("{0:#,0.00}", item.ProductTon), align: "center"));
            }

            table.AddCell().SetBackgroundColor(myColor)
                .Add(Util.P("Total", align: "center").SetBold());
            table.AddCell().SetBackgroundColor(myColor)
                .Add(Util.P(string.Format("{0:#,0}", data.AssumptionClone.Sum(x => x.Portion ?? 0)) +"%", align: "center").SetBold());
            table.AddCell().SetBackgroundColor(myColor)
                .Add(Util.P(string.Format("{0:#,0.00}", data.AssumptionClone.Sum(x => x.Area)), align: "center").SetBold());
            table.AddCell().SetBackgroundColor(myColor)
                .Add(Util.P(string.Format("{0:#,0.00}", data.AssumptionClone.Sum(x => x.ProductTon)), align: "center").SetBold());

            return table;
        }

        private Table TableMill()
        {
            var table = new Table(new float[] { 2, 1, 1, 1 })
                    .SetFixedLayout()
                    .SetWidth(UnitValue.CreatePercentValue(85))
                    .SetMarginTop(7)
                    .SetMarginBottom(7);

            table.AddCellNoBorder();

            table.AddCell()
                .Add(Util.P("ต้นทุนไม้หน้าสวน\nรวมค่าตัดไม้\n(บาท/ตัน)").SetTextAlignment(TextAlignment.CENTER));

            table.AddCell()
                .Add(Util.P("ค่าขนส่งมายัง\nโรงงาน\n(บาท/ตัน)").SetTextAlignment(TextAlignment.CENTER));

            table.AddCell()
                .Add(Util.P("ต้นทุนไม้ถึงหน้า\n" + data.Mill + "\n(บาท/ตัน)").SetTextAlignment(TextAlignment.CENTER));

            table.AddCell()
                .Add(Util.P("ราคาหน้า" + data.Mill + "ปัจจุบัน"));

            table.AddCell();

            table.AddCell();

            table.AddCell()
                .Add(Util.P(string.Format("{0:#,0}", data.AveragePrice), align: "center"));

            table.AddCell()
                .Add(Util.P("ราคา MTP หน้า" + data.Mill));

            table.AddCell();

            table.AddCell();

            table.AddCell()
                .Add(Util.P(string.Format("{0:#,0}", data.MtpPrice), align: "center"));

            table.AddCell()
                .Add(Util.P("ราคาไม้ตาม MTP"));

            table.AddCell();

            table.AddCell();

            table.AddCell()
                .Add(Util.P(string.Format("{0:#,0}", data.FcPrice), align: "center"));

            table.AddCell()
                .Add(Util.P("ราคาไม้จากโครงการ"));

            table.AddCell()
                 .Add(Util.P(string.Format("{0:#,0}", data.PriceAtPlant), align: "center"));

            table.AddCell()
                .Add(Util.P(string.Format("{0:#,0}", data.Freight), align: "center"));

            table.AddCell()
                .Add(Util.P(string.Format("{0:#,0}", (data.PriceAtPlant ?? 0) + (data.Freight ?? 0)), align: "center"));

            return table;

        }
        private Table TableMain()
        {
            var table = new Table(new float[] { 1, 3, 17, 5, 5 })
                    .SetFixedLayout()
                    .SetWidth(UnitValue.CreatePercentValue(100));

            table.AddCellNoBorder(1, 5)
                .Add(Util.P("เอกสารแนบ 3", align: "right"));

            table.AddCellNoBorder(1, 5)
                .Add(Util.P("สมมติฐานในการคำนวณผลตอบแทนการลงทุน", align: "center").SetBold().SetUnderline());

            table.AddCellNoBorder(1, 5)
                .Add(Util.P("1. ประมาณการราคารับซื้อไม้ยูคาลิปตัส (บาทต่อตันไม้)"));

            table.AddCellNoBorder(1, 5).SetHorizontalAlignment(HorizontalAlignment.CENTER)
                .Add(TableMill().SetHorizontalAlignment(HorizontalAlignment.CENTER));

            table.AddCellNoBorder(1, 5)
                .Add(Util.P("2. สัญญาเช่าที่ดิน ค่าเช่า ค่าตัดไม้ และค่าขนส่ง"));

            #region 2.1
            table.AddCellNoBorder();

            table.AddCellNoBorder(1, 2)
                .Add(Util.P("2.1 พื้นที่เป้าหมายในการเช่าเพื่อปลูกไม้"));

            table.AddCellNoBorder()
                .Add(Util.P(string.Format("{0:#,0.00}", data.RentalArea) + " ", align: "right"));

            table.AddCellNoBorder()
                .Add(Util.P(" ไร่").SetPaddingLeft(15));
            #endregion 2.1

            #region 2.2
            table.AddCellNoBorder();

            table.AddCellNoBorder(1, 2)
                .Add(Util.P("2.2 พื้นที่ปลูกไม้จริง (ของพื้นที่เช่าทั้งหมด) " + data.ProductiveAreaPercent?.ToString() + "%"));

            table.AddCellNoBorder()
                .Add(Util.P(string.Format("{0:#,0.00}", data.ProductiveArea) + " ", align: "right"));

            table.AddCellNoBorder()
                .Add(Util.P(" ไร่").SetPaddingLeft(15));
            #endregion 2.2

            #region 2.3
            table.AddCellNoBorder();

            table.AddCellNoBorder(1, 2)
                .Add(Util.P("2.3 จำนวนกล้าไม้ต่อไร่"));

            table.AddCellNoBorder()
                .Add(Util.P("180 ", align: "right"));

            table.AddCellNoBorder()
                .Add(Util.P(" ต้นต่อไร่").SetPaddingLeft(15));
            #endregion 2.3

            #region 2.4
            table.AddCellNoBorder();

            table.AddCellNoBorder(1, 2)
                .Add(Util.P("2.4 รอบระยะตัดฟัน"));

            table.AddCellNoBorder()
                .Add(Util.P(data.ContractYear >= 10 ? "5" : data.ContractYear.ToString(), align: "right"));

            table.AddCellNoBorder()
                .Add(Util.P(" ปี").SetPaddingLeft(15));
            #endregion 2.4

            #region 2.5
            table.AddCellNoBorder();

            table.AddCellNoBorder(1, 2)
                .Add(Util.P("2.5 จำนวนรอบตัดฟัน"));

            table.AddCellNoBorder()
                .Add(Util.P(data.CuttingRound.ToString(), align: "right"));

            table.AddCellNoBorder()
                .Add(Util.P(" รอบ").SetPaddingLeft(15));
            #endregion 2.5

            #region 2.6
            decimal? sumFee = 0;
            for (var i = 1; i <= data.CuttingRound; i++)
            {
                sumFee += (data.AssumptionYield[i - 1].Year * data.AssumptionYield[i - 1].RentalFee * data.RentalArea) / 1000000;

                table.AddCellNoBorder();

                table.AddCellNoBorder()
                    .Add(Util.P(i == 1 ? "2.6 ค่าเช่า" : ""));

                table.AddCellNoBorder()
                    .Add(Util.P("ค่าเช่าเฉลี่ย " + data.AssumptionYield[i-1].YearStart.ToString() + "-" + data.AssumptionYield[i - 1].YearEnd.ToString() + " ปี " + string.Format("{0:#,0}", data.AssumptionYield[i - 1].RentalFee) + " บาทต่อไร่ต่อปี รวม " + data.AssumptionYield[i - 1].Year.ToString() + " ปี"));

                table.AddCellNoBorder()
                    .Add(Util.P(string.Format("{0:#,0.00}", (data.AssumptionYield[i - 1].Year * data.AssumptionYield[i - 1].RentalFee * data.RentalArea) / 1000000), align: "right"));

                table.AddCellNoBorder()
                    .Add(Util.P(" ล้านบาท").SetPaddingLeft(15));
            }
            table.AddCellNoBorder(1, 2);

            table.AddCellNoBorder()
                .Add(Util.P("รวมค่าเช่าทั้งโครงการ"));

            table.AddCellNoBorder()
                .Add(Util.P(string.Format("{0:#,0.00}", sumFee), align: "right").SetUnderline());

            table.AddCellNoBorder()
                .Add(Util.P(" ล้านบาท").SetPaddingLeft(15));

            #endregion 2.6

            #region 2.7
            table.AddCellNoBorder();

            table.AddCellNoBorder(1, 2)
                .Add(Util.P("2.7 ค่าตัดไม้ (แรงงานคน)"));

            table.AddCellNoBorder()
                .Add(Util.P(string.Format("{0:#,0}", data.CuttingCost), align: "right"));

            table.AddCellNoBorder()
                .Add(Util.P(" บาทต่อตัน").SetPaddingLeft(15));
            #endregion 2.7

            #region 2.8
            table.AddCellNoBorder();

            table.AddCellNoBorder(1, 2)
                .Add(Util.P("2.8 ค่าขนส่งไม้ท่อน"));

            table.AddCellNoBorder()
                .Add(Util.P(string.Format("{0:#,0}", data.Freight), align: "right"));

            table.AddCellNoBorder()
                .Add(Util.P(" บาทต่อตัน").SetPaddingLeft(15));
            #endregion 2.8


            table.AddCellNoBorder(1, 5)
                .Add(Util.P("3. ลักษณะทางกายภาพของพื้นที่ และ ผลผลิตที่ประเมินว่าจะได้จากโครงการ"));

            #region 3.1
            table.AddCellNoBorder();

            table.AddCellNoBorder(1, 4)
                .Add(Util.P("3.1 ชุดดิน " + data.SoilType));

            table.AddCellNoBorder();

            table.AddCellNoBorder(1, 4)
                .Add(Util.P(data.NewRegist.PhysicalArea));

            #endregion 3.1

            #region 3.2
            table.AddCellNoBorder();

            table.AddCellNoBorder(1, 4)
                .Add(Util.P("3.2 ปริมาณน้ำฝน " + data.Rainfall + " มิลลิลิตร"));
            #endregion 3.2

            #region 3.3
            table.AddCellNoBorder();

            table.AddCellNoBorder(1, 4)
                .Add(Util.P("3.3 ประมาณการผลผลิต"));


            table.AddCellNoBorder();

            table.AddCellNoBorder(1, 4)
                .Add(TableRound());

            #endregion 3.3

            return table;
        }

        private Table TableRound()
        {
            var table = new Table(new float[] { 20, 4, 4, 4, 4 })
                    .SetFixedLayout()
                    .SetWidth(UnitValue.CreatePercentValue(100));


            var round = 0;
            foreach (var item in data.AssumptionYield.OrderBy(x => x.Round))
            {
                table.AddCellNoBorder()
                    .Add(Util.P("ผลผลิตที่ได้รับเฉลี่ย - รอบตัดฟันที่ " + item.Round).SetPaddingLeft(10));

                table.AddCellNoBorder()
                    .Add(Util.P(string.Format("{0:#,0}", item.Yield * data.ProductiveArea), align: "right"));

                table.AddCellNoBorder()
                    .Add(Util.P("ตัน").SetPaddingLeft(10));

                table.AddCellNoBorder()
                    .Add(Util.P(string.Format("{0:#,0.0}", item.Yield), align: "right"));

                table.AddCellNoBorder()
                    .Add(Util.P("ตันต่อไร่").SetPaddingLeft(10));

                round++;
            }


            table.AddCellNoBorder()
                .Add(Util.P("รวมผลผลิตที่ได้รับจากโครงการ " + round.ToString() + " รอบตัดฟัน").SetPaddingLeft(10));

            table.AddCellNoBorder()
                .Add(Util.P(string.Format("{0:#,0}", Math.Round(data.AssumptionYield.Sum(x => x.Yield ?? 0) * (data.ProductiveArea ?? 0) / 10) * 10), align: "right").SetUnderline());

            table.AddCellNoBorder()
                .Add(Util.P("ตัน").SetPaddingLeft(10));

            table.AddCellNoBorder()
                .Add(Util.P(string.Format("{0:#,0.0}", data.AssumptionYield.Average(x => x.Yield)) + "*", align: "right").SetUnderline());

            table.AddCellNoBorder()
                .Add(Util.P("ตันต่อไร่").SetPaddingLeft(10));

            table.AddCellNoBorder(1, 2);

            table.AddCellNoBorder(1, 3)
                .Add(Util.P("* ผลผลิตวิเคราะห์โดยทีมสวนไม้ SFT"));

            return table;
        }


        private Table TableDetail()
        {
            var widthYear = 10;

            var col = new List<float>(new float[] { 30 });

            for (var i = 1; i <= data.ContractYear; i++)
            {
                col.Add(widthYear);
            }

            var table = new Table(col.ToArray())
                    .SetFixedLayout()
                    .SetWidth(UnitValue.CreatePercentValue(100))
                    .SetMarginTop(10);

            table.AddCellNoBorder();

            for (var i = 1; i <= data.ContractYear; i++)
            {
                table.AddCell()
                    .Add(Util.P("ปีที่ " + i.ToString(), align: "center"));
            }

            table.AddCell()
                    .Add(Util.P("ค่าใช้จ่ายรายปี (ล้านบาท)"));


            List<string> activityGroup = new List<string>(new string []{ "B", "C", "D", "F"});
            var amount = data.Expense.Where(x => activityGroup.Contains(x.ActivityGroup));


            if (1 <= data.ContractYear)
                table.AddCell()
                    .Add(Util.P(string.Format("{0:#,0.0}", (amount.Sum(x => x.YearCost1) * (data.ProductiveArea ?? 0)) / (decimal)1000000), align: "center"));

            if (2 <= data.ContractYear)
                table.AddCell()
                    .Add(Util.P(string.Format("{0:#,0.0}", (amount.Sum(x => x.YearCost2) * (data.ProductiveArea ?? 0)) / (decimal)1000000), align: "center"));

            if (3 <= data.ContractYear)
                table.AddCell()
                    .Add(Util.P(string.Format("{0:#,0.0}", (amount.Sum(x => x.YearCost3) * (data.ProductiveArea ?? 0)) / (decimal)1000000), align: "center"));

            if (4 <= data.ContractYear)
                table.AddCell()
                    .Add(Util.P(string.Format("{0:#,0.0}", (amount.Sum(x => x.YearCost4) * (data.ProductiveArea ?? 0)) / (decimal)1000000), align: "center"));

            if (5 <= data.ContractYear)
                table.AddCell()
                    .Add(Util.P(string.Format("{0:#,0.0}", (amount.Sum(x => x.YearCost5) * (data.ProductiveArea ?? 0)) / (decimal)1000000), align: "center"));

            if (6 <= data.ContractYear)
                table.AddCell()
                    .Add(Util.P(string.Format("{0:#,0.0}", (amount.Sum(x => x.YearCost6) * (data.ProductiveArea ?? 0)) / (decimal)1000000), align: "center"));

            if (7 <= data.ContractYear)
                table.AddCell()
                    .Add(Util.P(string.Format("{0:#,0.0}", (amount.Sum(x => x.YearCost7) * (data.ProductiveArea ?? 0)) / (decimal)1000000), align: "center"));

            if (8 <= data.ContractYear)
                table.AddCell()
                    .Add(Util.P(string.Format("{0:#,0.0}", (amount.Sum(x => x.YearCost8) * (data.ProductiveArea ?? 0)) / (decimal)1000000), align: "center"));

            if (9 <= data.ContractYear)
                table.AddCell()
                    .Add(Util.P(string.Format("{0:#,0.0}", (amount.Sum(x => x.YearCost9) * (data.ProductiveArea ?? 0)) / (decimal)1000000), align: "center"));

            if (10 <= data.ContractYear)
                table.AddCell()
                    .Add(Util.P(string.Format("{0:#,0.0}", (amount.Sum(x => x.YearCost10) * (data.ProductiveArea ?? 0)) / (decimal)1000000), align: "center"));

            if (11 <= data.ContractYear)
                table.AddCell()
                    .Add(Util.P(string.Format("{0:#,0.0}", (amount.Sum(x => x.YearCost11) * (data.ProductiveArea ?? 0)) / (decimal)1000000), align: "center"));

            if (12 <= data.ContractYear)
                table.AddCell()
                    .Add(Util.P(string.Format("{0:#,0.0}", (amount.Sum(x => x.YearCost12) * (data.ProductiveArea ?? 0)) / (decimal)1000000), align: "center"));

            if (13 <= data.ContractYear)
                table.AddCell()
                    .Add(Util.P(string.Format("{0:#,0.0}", (amount.Sum(x => x.YearCost13) * (data.ProductiveArea ?? 0)) / (decimal)1000000), align: "center"));

            if (14 <= data.ContractYear)
                table.AddCell()
                    .Add(Util.P(string.Format("{0:#,0.0}", (amount.Sum(x => x.YearCost14) * (data.ProductiveArea ?? 0)) / (decimal)1000000), align: "center"));

            if (15 <= data.ContractYear)
                table.AddCell()
                    .Add(Util.P(string.Format("{0:#,0.0}", (amount.Sum(x => x.YearCost15) * (data.ProductiveArea ?? 0)) / (decimal)1000000), align: "center"));


            table.AddCell()
                    .Add(Util.P("ค่าใช้จ่ายรายรอบตัด (ล้านบาท)"));

            var cnt = 1;
            foreach(var item in data.AssumptionYield)
            {
                decimal amt = 0;

                if (cnt == 1)
                {
                    amt = amount.Sum(x => (x.YearCost1 ?? 0) + (x.YearCost2 ?? 0) + (x.YearCost3 ?? 0) + (x.YearCost4 ?? 0) + (x.YearCost5 ?? 0));
                    if (data.ContractYear == 6)
                    {
                        amt = amount.Sum(x => (x.YearCost1 ?? 0) + (x.YearCost2 ?? 0) + (x.YearCost3 ?? 0) + (x.YearCost4 ?? 0) + (x.YearCost5 ?? 0) + (x.YearCost6 ?? 0));
                    }
                }
                else if (cnt == 2)
                {
                    amt = amount.Sum(x => (x.YearCost6 ?? 0) + (x.YearCost7 ?? 0) + (x.YearCost8 ?? 0) + (x.YearCost9 ?? 0) + (x.YearCost10 ?? 0));
                }
                else
                {
                    amt = amount.Sum(x => (x.YearCost11 ?? 0) + (x.YearCost12 ?? 0) + (x.YearCost13 ?? 0) + (x.YearCost14 ?? 0) + (x.YearCost15 ?? 0));
                }

                table.AddCell(1, item.Year)
                .Add(Util.P("ค่าใช้จ่ายรอบตัดฟันที่ " + cnt.ToString() + " " + string.Format("{0:#,0.0}", (amt * (data.ProductiveArea ?? 0)) / (decimal)1000000), align: "center"));

                cnt++;
            }

            return table;
        }
    }
}
