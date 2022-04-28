using iText.IO.Font;
using iText.Kernel.Font;
using Microsoft.Extensions.FileProviders;
using Sketec.Core.Interfaces;
using System;
using System.IO;

namespace Sketec.FileWriter
{
    public abstract class FileWriter : IFileWriter
    {
        public void Write(Stream stream)
        {
            Generate(stream);
        }

        public void Write(string path)
        {
            using (var writer = new FileStream(path, FileMode.CreateNew))
            {
                Write(writer);
            }
        }

        protected abstract void Generate(Stream stream);

        private static PdfFont GetFront(string fontFileName)
        {
            var embeddedFileProvider = new EmbeddedFileProvider(typeof(FileWriter).Assembly);
            var file = embeddedFileProvider.GetFileInfo($@"Fonts\{fontFileName}");
            byte[] fontByte = new byte[file.Length];
            using (var stream = file.CreateReadStream())
            {
                stream.Read(fontByte, 0, fontByte.Length);
            }
            return PdfFontFactory.CreateFont(fontByte, PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);
        }

        public static PdfFont GetAngsFont()
        {
            return GetFront("Angsana New.ttf");
        }
    }
}
