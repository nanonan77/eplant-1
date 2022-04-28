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

namespace Sketec.FileWriter.Pdf
{
    //public class BillingPdf
    //{
    //    BillingPdfDto data;
    //    PdfFont font;
    //    public BillingPdf()
    //    {
    //        font = Util.GetAngsFont();
    //    }

    //    public byte[] Pdf(BillingPdfDto data)
    //    {

    //        this.data = data;
    //        byte[] bytes;
    //        using (var st = new MemoryStream())
    //        {
    //            using (var writer = new PdfWriter(st))
    //            {
    //                using (var pdf = new PdfDocument(writer))
    //                {
    //                    pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new BillingPdfEventHandler(data));
    //                    pdf.AddEventHandler(PdfDocumentEvent.START_PAGE, new BillingAddressPdfEventHandler(data));
    //                    //pdf.AddEventHandler(PdfDocumentEvent.START_PAGE, new AccountingSummaryPostPdfEventHandler(data));
    //                    pdf.SetDefaultPageSize(PageSize.A4.Rotate());

    //                    var doc = new Document(pdf);
    //                    doc.SetFont(font);
    //                    doc.SetFontSize(14);
    //                    doc.SetLeftMargin(20);
    //                    doc.SetRightMargin(20);
    //                    doc.SetTopMargin(175);
    //                    doc.SetBottomMargin(185);

    //                    doc.Add(TableDetail());
    //                    doc.Close();

    //                    bytes = st.ToArray();
    //                }
    //            }
    //        }
    //        return bytes;
    //    }


    //    private Table TableDetail()
    //    {
    //        var table = new Table(new float[] { 1, 2, 2, 2, 3, 2 })
    //                .SetFixedLayout()
    //                .SetWidth(UnitValue.CreatePercentValue(100));


    //        var cnt = 1;
    //        foreach (var item in data.BillPresentmentDocumentControlItems)
    //        {
    //            table.AddCellNoBorder()
    //                .Add(Util.P(cnt.ToString(), align: "center"));

    //            table.AddCellNoBorder()
    //                .Add(Util.P(Util.GetBillingNo(item.BillingNo, data.BU), align: "center"));

    //            table.AddCellNoBorder()
    //                .Add(Util.P(item.PoNo, align: "center"));

    //            table.AddCellNoBorder()
    //                .Add(Util.P(item.BillingDate?.ToString("dd.MM.yyyy"), align: "center"));

    //            table.AddCellNoBorder()
    //                .Add(Util.P(item.Duedate?.ToString("dd.MM.yyyy"), align: "center"));

    //            table.AddCellNoBorder(space: 5)
    //                .Add(Util.P(string.Format("{0:#,0.00}", item.BillingAmount ?? 0), align: "right"));

    //            cnt++;
    //        }

    //        return table;
    //    }

    //    //private Paragraph PGroup(string txt)
    //    //{
    //    //    return new Paragraph(txt ?? "\n")
    //    //        .SetMultipliedLeading(0.8f)
    //    //        .SetBold()
    //    //        .SetTextAlignment(TextAlignment.LEFT);
    //    //}

    //    //private Paragraph PHeader(string txt)
    //    //{
    //    //    return new Paragraph(txt ?? "\n")
    //    //        .SetMultipliedLeading(0.8f)
    //    //        .SetBold()
    //    //        .SetTextAlignment(TextAlignment.CENTER);
    //    //}

    //    //private Paragraph P(string txt)
    //    //{
    //    //    return new Paragraph(txt ?? "\n")
    //    //        .SetMultipliedLeading(0.8f);
    //    //}

    //    //private Paragraph PCenter(string txt)
    //    //{
    //    //    return new Paragraph(txt ?? "\n")
    //    //        .SetMultipliedLeading(0.8f)
    //    //        .SetTextAlignment(TextAlignment.CENTER);
    //    //}

    //    //private Paragraph PRight(string txt)
    //    //{
    //    //    return new Paragraph(txt ?? "\n")
    //    //        .SetMultipliedLeading(0.8f)
    //    //        .SetTextAlignment(TextAlignment.RIGHT);
    //    //}
    //}

    //internal class BillingPdfEventHandler : IEventHandler
    //{
    //    PdfDocument pdf;
    //    PdfPage page;
    //    BillingPdfDto data;
    //    PdfCanvas pdfCanvas;
    //    Canvas canvas;
    //    int fontSize = 14;

    //    internal BillingPdfEventHandler(BillingPdfDto data)
    //    {
    //        this.data = data;
    //    }

    //    public void HandleEvent(Event @event)
    //    {
    //        PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
    //        pdf = docEvent.GetDocument();
    //        page = docEvent.GetPage();
    //        var size = page.GetPageSize();
    //        var marginTop = 20;
    //        var marginLeft = 20;
    //        var marginRight = 20;
    //        var marginBottom = 20;
    //        pdfCanvas = new PdfCanvas(page);
    //        canvas = new Canvas(pdfCanvas,
    //            new Rectangle(
    //                marginBottom
    //                , marginLeft
    //                , size.GetWidth() - marginLeft - marginRight
    //                , size.GetHeight() - marginTop - marginBottom)
    //            );
    //        canvas.SetFont(Util.GetAngsFont());
    //        canvas.SetFontSize(14);
    //        var lastPage = Math.Ceiling(data.BillPresentmentDocumentControlItems.Count() / 20.00);
    //        string pageStr = pdf.GetPageNumber(docEvent.GetPage()).ToString() + "/" + lastPage.ToString();
    //        AddHeader(pageStr);
    //        AddAddress();
    //        AddCustomerBillerPaymentTerm();
    //        AddTableDetail(pdf.GetPageNumber(docEvent.GetPage()) == lastPage);
    //        AddFooter();
    //    }


    //    #region Header

    //    private void AddHeader(string page)
    //    {
    //        var table = new Table(new float[] { 4, 2, 2, 2 })
    //            .SetFixedLayout()
    //            .SetWidth(UnitValue.CreatePercentValue(100));

    //        // Row 1
    //        table.AddCellNoBorder()
    //            .Add(Util.P("B:" + data.BillingRule));

    //        table.AddCellNoBorder()
    //            .Add(Util.P("ใบแจ้งหนี้/ใบรับวางบิล", 18, "center")
    //            .SetBold());

    //        table.AddCellNoBorder()
    //            .Add(Util.P("เลขที่: " + data.BillPresentmentNo, fontSize, "center"));

    //        table.AddCellNoBorder()
    //            .Add(Util.P("หน้า " + page , fontSize, "right"));

    //        // Row2
    //        table.AddCellNoBorder()
    //            .Add(Util.P("P:" + data.PaymentRule));

    //        table.AddCellNoBorder()
    //            .Add(Util.P("BILL", 18, "center")
    //            .SetBold());

    //        table.AddCellNoBorder();

    //        table.AddCellNoBorder()
    //            .Add(Util.P("Page", fontSize, "right"));

    //        canvas.Add(table);
    //    }
    //    #endregion

    //    #region Address
    //    private void AddAddress()
    //    {
    //        var table = new Table(new float[] { 1, 5, 1, 5 })
    //            .SetFixedLayout()
    //            .SetWidth(UnitValue.CreatePercentValue(100));

    //        // Row 1
    //        table.AddCellNoBorder()
    //            .Add(Util.P("ชื่อ/ที่อยู่ลูกค้า\nSold to"));

    //        //if (data.IsUseShipTo)
    //        //{
    //        //    table.AddCellNoBorder()
    //        //        .Add(Util.P(data.ShipToName
    //        //        + "\n" + data.ShipToStreet
    //        //        + "\n" + data.ShipToDistrict
    //        //        + "\n" + data.ShipToCity + " " + data.ShipToPostcode
    //        //        + "\nเลขประจำตัวผู้เสียภาษี " + data.ShipToTaxNo
    //        //        + "\nสถานประกอบการ " + data.ShipToTaxNo));
    //        //}
    //        //else
    //        //{
    //        //    table.AddCellNoBorder()
    //        //        .Add(Util.P(data.SoldToOrBillToCode + " " + data.SoldToOrBillToName
    //        //        + "\n" + data.SoldToOrBillToStreet
    //        //        + "\n" + data.SoldToOrBillToDistrict
    //        //        + "\n" + data.SoldToOrBillToCity + " " + data.SoldToOrBillToPostcode
    //        //        + "\nเลขประจำตัวผู้เสียภาษี " + data.SoldToOrBillToTaxNo
    //        //        + "\nสถานประกอบการ " + data.SoldToOrBillToTaxNo));
    //        //}
    //        table.AddCellNoBorder()
    //            .Add(Util.P("_").SetFontColor(ColorConstants.WHITE));

    //        table.AddCellNoBorder()
    //            .Add(Util.P("จัดจำหน่ายโดย\nSold by"));

    //        // Row2
    //            //table.AddCellNoBorder()
    //            //    .Add(Util.P(data.CompanyName
    //            //    + "\n" + ""
    //            //    + "\n" + ""
    //            //    + "\n" + ""
    //            //    + "\nเลขประจำตัวผู้เสียภาษี " + ""
    //            //    + "\nสถานประกอบการ " + ""));

    //        canvas.Add(table);
    //    }
    //    #endregion

    //    #region Payment Term
    //    private void AddCustomerBillerPaymentTerm()
    //    {
    //        var table = new Table(new float[] { 1, 2, 2, 2 })
    //                .SetFixedLayout()
    //                .SetMarginTop(54)
    //                .SetWidth(UnitValue.CreatePercentValue(100));
    //        // Row1
    //        table.AddCellNoBorder()
    //            .Add(Util.P($"วันที่วางบิล: {data.BillPresentmentDate?.ToString("dd.MM.yyyy")}"))
    //            .Add(Util.P($"Bill Presentment Date"));

    //        table.AddCellNoBorder()
    //            .Add(Util.P($"เงื่อนไขการชำระเงิน: {data.CreditTerm}"))
    //            .Add(Util.P($"Payment Term"));

    //        table.AddCellNoBorder()
    //            .Add(Util.P($"วันครบกำหนดชำระเงิน: {data.DueDate?.ToString("dd.MM.yyyy")}"))
    //            .Add(Util.P($"Due Date"));

    //        table.AddCellNoBorder()
    //            .Add(Util.P($"วันที่ออกเอกสาร: {data.IssueDate?.ToString("dd.MM.yyyy")}"))
    //            .Add(Util.P($"Issue Date"));

    //        canvas.Add(table);

    //    }
    //    #endregion

    //    private static readonly string[][] header = new string[][]
    //    {
    //        new string[]{ "ลำดับ","No."},
    //        new string[]{ "เลขที่ใบกำกับ","Tax Invoice No."},
    //        new string[]{ "เลขที่ใบสั่งซื้อ","Purchase Order No."},
    //        new string[]{ "วันส่งของ","Delivery Date"},
    //        new string[]{ "วันที่ครบกำหนดชำระตามเงื่อนไข", "Due Date by Term"},
    //        new string[]{ "รวมเงินทั้งสิ้น", "Amount with VAT"},
    //    };

    //    private void AddTableDetail(bool IsLastPage)
    //    {
    //        var table = new Table(new float[] { 1, 2, 2, 2, 3, 2 })
    //                .SetFixedLayout()
    //                .SetWidth(UnitValue.CreatePercentValue(100));

    //        foreach (var txt in header)
    //        {
    //            table.AddCell(Util.P($"{txt[0]}\n{txt[1]}", fontSize, "center"));
    //        }

    //        var cnt = 19;
    //        for (var i = 1; i <= cnt; i++)
    //        {
    //            table.AddCellTable(space: 0).Add(Util.P("_").SetFontColor(ColorConstants.WHITE));
    //            table.AddCellTable(space: 0).Add(Util.P("_").SetFontColor(ColorConstants.WHITE));
    //            table.AddCellTable(space: 0).Add(Util.P("_").SetFontColor(ColorConstants.WHITE));
    //            table.AddCellTable(space: 0).Add(Util.P("_").SetFontColor(ColorConstants.WHITE));
    //            table.AddCellTable(space: 0).Add(Util.P("_").SetFontColor(ColorConstants.WHITE));
    //            table.AddCellTable(space: 0).Add(Util.P("_").SetFontColor(ColorConstants.WHITE));
    //        }
    //        table.AddCellTable(true, space: 0).Add(Util.P("_").SetFontColor(ColorConstants.WHITE));
    //        table.AddCellTable(true, space: 0).Add(Util.P("_").SetFontColor(ColorConstants.WHITE));
    //        table.AddCellTable(true, space: 0).Add(Util.P("_").SetFontColor(ColorConstants.WHITE));
    //        table.AddCellTable(true, space: 0).Add(Util.P("_").SetFontColor(ColorConstants.WHITE));
    //        table.AddCellTable(true, space: 0).Add(Util.P("_").SetFontColor(ColorConstants.WHITE));
    //        table.AddCellTable(true, space: 0).Add(Util.P("_").SetFontColor(ColorConstants.WHITE));



    //        if(IsLastPage)
    //        {
    //            var amount = data.BillPresentmentDocumentControlItems.Sum(x => x.BillingAmount);
    //            table.AddCell(new Cell(1, 5)
    //            .Add(Util.P("จำนวนเงินทั้งสิ้น").Add(new Tab()).AddTabStops(new TabStop(20)).Add(Util.ThaiBahtText(String.Format("{0:#,0.00}", (amount ?? 0)))))
    //            .Add(Util.P("Total Amount")));

    //            table.AddCellNoBorder(border: true, space: 5)
    //                    .Add(Util.P(string.Format("{0:#,0.00}", Math.Abs(amount ?? 0)), align: "right"));
    //        }
    //        else
    //        {
    //            table.AddCell(new Cell(1, 5).Add(Util.P("_").SetFontColor(ColorConstants.WHITE).Add(new Tab()).AddTabStops(new TabStop(20)).Add(Util.P("_").SetFontColor(ColorConstants.WHITE)))
    //            .Add(Util.P("_").SetFontColor(ColorConstants.WHITE)));


    //            table.AddCellNoBorder(border: true, space: 5)
    //                    .Add(Util.P("_").SetFontColor(ColorConstants.WHITE));
    //        }

    //        canvas.Add(table);
    //    }

    //    private void AddFooter()
    //    {
    //        var table = new Table(new float[] { 1, 3, 3, 2, 2, 2 })
    //               .SetFixedLayout()
    //               .SetWidth(UnitValue.CreatePercentValue(100));

    //        table.AddCell(new Cell(1, 3)
    //                .Add(Util.P("ได้รับต้นฉบับใบแจ้งหนี้/ใบรับวางบิล พร้อมต้นฉบับใบจ่ายสินค้าที่มีลายเซ็นผู้รับสินค้าครบตามจำนวนเงินที่ระบุในใบแจ้งหนี้/ใบรับวางบิลฉบับนี้ถูกต้องแล้ว").SetFontSize(13))
    //                .Add(Util.P("ผู้รับใบแจ้งหนี้/ใบรับวางบิล").SetMarginTop(30).SetFontSize(13)
    //                    .Add(new Tab())
    //                    .AddTabStops(new TabStop(180, TabAlignment.RIGHT, new SolidLine(0.5f)))
    //                    .Add("วันที่").SetFontSize(13)
    //                    .Add(new Tab())
    //                    .AddTabStops(new TabStop(300, TabAlignment.RIGHT, new SolidLine(0.5f)))
    //                    .Add("นัดชำระวันที่").SetFontSize(13)
    //                    .Add(new Tab())
    //                    .AddTabStops(new TabStop(380, TabAlignment.RIGHT, new SolidLine(0.5f)))

    //                    .SetVerticalAlignment(VerticalAlignment.BOTTOM))
    //                .Add(Util.P("Receiver").SetFontSize(13)
    //                .Add(new Tab())
    //                    .AddTabStops(new TabStop(180, TabAlignment.RIGHT))
    //                    .Add("Date").SetFontSize(13)
    //                    .Add(new Tab())
    //                    .AddTabStops(new TabStop(305, TabAlignment.RIGHT))
    //                    .Add("Collection Date").SetFontSize(13)
    //                    ));;

    //        table.AddCell(new Cell(1, 3)
    //                .Add(Util.P("คำเตือน : โปรดชำระเงินด้วยเช็คขีดคร่อมสั่งจ่ายในนามบริษัทหรือวิธีการโอนเงินเข้าบัญชีบริษัท การชำระเงินด้วยเช็คการโอนหรือวิธีการอื่นใดและใบเสร็จจะสมบูรณ์เมื่อบริษัทได้รับเงิน ค่าสินค้าตามรายการข้างต้นครบถ้วนเท่านั้น หากลูกค้าผิดนัดไม่ชำระหนี้ค่าสินค้าภายในกำหนดเวลา ลูกค้าตกลงยอมชำระเงินค่าล่าช้าให้บริษัทในอัตราร้อยละ 2 ต่อเดือน")
    //                .SetFontSize(13).SetMarginBottom(15))
    //                .Add(Util.P("ผู้มีอำนาจลงนาม").SetFontSize(13)
    //                .SetTextAlignment(TextAlignment.CENTER)
    //                .Add(new Tab())
    //                .AddTabStops(new TabStop(150, TabAlignment.RIGHT, new SolidLine(0.5f))))

    //                .Add(Util.P("Authorized Signature").SetFontSize(13)
    //                .SetTextAlignment(TextAlignment.CENTER)
    //                .Add(new Tab())
    //                .AddTabStops(new TabStop(150, TabAlignment.RIGHT)))

    //                .Add(Util.P("ผู้ออกเอกสาร : ").SetFontSize(13))
    //            );
    //        table.AddCell(new Cell(1, 6)
    //                .Add(Util.P("หมายเหตุ : หากไม่มีการทักท้วงรายการข้างต้นประการใดภายใน 7 วัน นับจากวันที่ท่านได้รับใบแจ้งหนี้/ใบรับวางบิลจากบริษัทฯ ทางบริษัทจะถือว่ารายการข้างต้นนี้ถูกต้องแล้ว")
    //                .SetMarginTop(2).SetMarginBottom(2).SetFontSize(13))
    //                );

    //        table.AddCellNoBorder(1,13)
    //           .Add(Util.P("บริษัทฯ มีการประกาศใช้นโยบายความเป็นส่วนตัว ท่านสามารถศึกษารายละเอียดเพิ่มเติมได้ที่ www.scgpackaging.com")
    //           .SetMarginTop(3)
    //           .SetFontSize(13)
    //           .SetTextAlignment(TextAlignment.RIGHT)
    //           );

    //        canvas.Add(table);

    //    }
    //}

    //internal class BillingAddressPdfEventHandler : IEventHandler
    //{
    //    PdfDocument pdf;
    //    PdfPage page;
    //    BillingPdfDto data;
    //    PdfCanvas pdfCanvas;
    //    Canvas canvas;

    //    internal BillingAddressPdfEventHandler(BillingPdfDto data)
    //    {
    //        this.data = data;
    //    }

    //    public void HandleEvent(Event @event)
    //    {
    //        var docEvent = (PdfDocumentEvent)@event;
    //        pdf = docEvent.GetDocument();
    //        page = docEvent.GetPage();
    //        var size = page.GetPageSize();
    //        var marginTop = 48;
    //        var marginLeft = 20;
    //        var marginRight = 20;
    //        var marginBottom = 20;
    //        pdfCanvas = new PdfCanvas(page);
    //        canvas = new Canvas(pdfCanvas,
    //            new Rectangle(
    //                marginBottom
    //                , marginLeft
    //                , size.GetWidth() - marginLeft - marginRight
    //                , size.GetHeight() - marginTop - marginBottom)
    //            );
    //        canvas.SetFont(Util.GetAngsFont());
    //        canvas.SetFontSize(14);


    //        AddAddress();
    //    }

    //    #region Address
    //    private void AddAddress()
    //    {
    //        var table = new Table(new float[] { 1, 5, 1, 5 })
    //            .SetFixedLayout()
    //            .SetWidth(UnitValue.CreatePercentValue(100));

    //        // Row 1

    //        table.AddCellNoBorder()
    //            .Add(Util.P("_").SetFontColor(ColorConstants.WHITE));

    //        if (data.IsUseShipTo)
    //        {
    //            table.AddCellNoBorder()
    //                .Add(Util.P(data.ShipToName
    //                + "\n" + data.ShipToStreet
    //                + "\n" + data.ShipToDistrict
    //                + "\n" + data.ShipToCity + " " + data.ShipToPostcode
    //                + Util.TaxNo(data.ShipToTaxNo)
    //                + Util.Branch(data.ShipToBranch)));
    //        }
    //        else
    //        {
    //            table.AddCellNoBorder()
    //                .Add(Util.P(data.SoldToOrBillToCode + " " + data.SoldToOrBillToName
    //                + "\n" + data.SoldToOrBillToStreet
    //                + "\n" + data.SoldToOrBillToDistrict
    //                + "\n" + data.SoldToOrBillToCity + " " + data.SoldToOrBillToPostcode
    //                + Util.TaxNo(data.SoldToOrBillToTaxNo)
    //                + Util.Branch(data.SoldToOrBillToBranch)));
    //        }

    //        table.AddCellNoBorder()
    //            .Add(Util.P("_").SetFontColor(ColorConstants.WHITE));

    //        // Row2
    //        table.AddCellNoBorder()
    //            .Add(Util.P(data.CompanyName
    //            + "\n" + data.CompanyStreet
    //            + "\n" + data.CompanyDistrict
    //            + "\n" + data.CompanyCity + " " + data.CompanyPostcode
    //            + "\nโทร. " + data.CompanyTel + " โทรสาร. " + data.CompanyFaxNo
    //            + Util.TaxNo(data.CompanyTaxNo)
    //            + Util.Branch(data.CompanyBranch)));

    //        canvas.Add(table);
    //    }
    //    #endregion
    //}
}
