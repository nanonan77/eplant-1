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
    public class IntroductionPdf
    {
        PdfFont font;
        public IntroductionPdf()
        {
            font = Util.GetArial();
        }

        public byte[] Pdf()
        {
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
                        doc.Close();

                        bytes = st.ToArray();
                    }
                }
            }
            return bytes;
        }


        private Table TableDetail()
        {
            var table = new Table(new float[] { 1 })
                    .SetFixedLayout()
                    .SetWidth(UnitValue.CreatePercentValue(100));


            table.AddCellNoBorder()
                .Add(Util.P("รายการเอกสารแนบ", align: "center").SetBold());

            table.AddCellNoBorder()
                .Add(Util.P("เอกสารแนบ 1:	รายละเอียดโครงการ และ แผนภาพลักษณะพื้นที่เช่า"));

            table.AddCellNoBorder()
                .Add(Util.P("เอกสารแนบ 2:	แผนการดำเนินงานระยะยาวทั้งโครงการ"));

            table.AddCellNoBorder()
                .Add(Util.P("เอกสารแนบ 3:	สมมติฐานในการคำนวณผลตอบแทนการลงทุน"));

            table.AddCellNoBorder()
                .Add(Util.P("เอกสารแนบ 4:	คำนวณผลตอบแทนการลงทุน"));

            table.AddCellNoBorder()
                .Add(Util.P("เอกสารแนบ 5:	สรุปงบประมาณเงินลงทุน"));

            table.AddCellNoBorder()
                .Add(Util.P("เอกสารแนบ 6:	Risk Dashboard"));

            return table;
        }
    }

    internal class PdfEventHandler : IEventHandler
    {
        PdfDocument pdf;
        PdfPage page;
        PdfCanvas pdfCanvas;
        Canvas canvas;
        int fontSize = 14;
        internal PdfEventHandler()
        {

        }
        public void HandleEvent(Event @event)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
            pdf = docEvent.GetDocument();
            page = docEvent.GetPage();
            var size = page.GetPageSize();
            var marginTop = 20;
            var marginLeft = 20;
            var marginRight = 20;
            var marginBottom = 20;
            pdfCanvas = new PdfCanvas(page);
            canvas = new Canvas(pdfCanvas,
                new Rectangle(
                    marginBottom
                    , marginLeft
                    , size.GetWidth() - marginLeft - marginRight
                    , size.GetHeight() - marginTop - marginBottom)
                );

        }
    }
}
