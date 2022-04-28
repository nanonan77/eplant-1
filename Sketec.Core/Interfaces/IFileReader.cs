using System.Collections.Generic;
using System.IO;

namespace Sketec.Core.Interfaces
{
    public interface IFileReader<T> where T : class
    {
        IEnumerable<T> Read(Stream stream);
    }
}
