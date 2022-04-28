using Sketec.Core.Interfaces;
using Sketec.FileReader.Sap.Resources;
using Sketec.FileReader.Utils;
using System.Collections.Generic;
using System.IO;

namespace Sketec.FileReader.Sap
{
    public class ArOutstandingFileReader : IFileReader<ArOutstanding>
    {
        public IEnumerable<ArOutstanding> Read(Stream stream)
        {
            return FileReaderUtils.ReadSapTextFile<ArOutstanding>(stream);
        }
    }
}
