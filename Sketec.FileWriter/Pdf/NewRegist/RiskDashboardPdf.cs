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
    public class RiskDashboardPdf
    {
        PdfFont font;
        AssumptionPdfDto data;
        Color myColor = new DeviceRgb(189, 214, 238);
        public RiskDashboardPdf()
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


                        doc.Add(TableRisk());

                        doc.Close();

                        bytes = st.ToArray();
                    }
                }
            }
            return bytes;
        }


        private Table TableRisk()
        {
            var table = new Table(new float[] { 1 })
                    .SetFixedLayout()
                    .SetWidth(UnitValue.CreatePercentValue(100))
                    ;

            table.AddCellNoBorder()
                .Add(Util.P("เอกสารแนบ 6", align: "right"));

            table.AddCellNoBorder()
                .Add(Util.P("Risk Dashboard", align: "center").SetBold().SetUnderline());

            var embeddedFileProvider = new EmbeddedFileProvider(typeof(FileWriter).Assembly);
            var file = embeddedFileProvider.GetFileInfo($@"Resources\risk_dashboard.jpg");
            byte[] fileByes = new byte[file.Length];
            using (var stream = file.CreateReadStream())
            {
                stream.Read(fileByes, 0, fileByes.Length);

                ImageData imgData = ImageDataFactory.Create(fileByes);
                Image img = new Image(imgData);
                table.AddCellNoBorder().SetPaddingTop(10)
                .Add(img.SetMaxWidth(UnitValue.CreatePercentValue(55)).SetHorizontalAlignment(HorizontalAlignment.CENTER));

            }




            return table;
        }

    }
}
