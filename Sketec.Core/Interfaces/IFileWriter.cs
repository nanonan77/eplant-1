using System.IO;

namespace Sketec.Core.Interfaces
{
    public interface IFileWriter
    {
        void Write(Stream stream);
        void Write(string path);
    }
}
