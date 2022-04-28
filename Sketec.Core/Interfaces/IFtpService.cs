using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Sketec.Core.Interfaces
{
    public interface IFtpService
    {
        void Connect();
        bool Exists(string path);
        IEnumerable<string> ListDirectory(string path);
        byte[] GetFile(string path);
        Task Upload(string path, byte[] file, bool canOverwrite);
        Task Upload(string path, Stream file, bool canOverwrite);
    }

    public interface IWCSftpService : IFtpService
    {

    }
}
