using Sketec.Core.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Interfaces
{
    public interface IStorageService
    {
        Task Upload(string path, Stream stream);
        Task Upload(string path, byte[] bytes);
        Task<Stream> Download(string path);
        Task Delete(string path);
        Task<IEnumerable<string>> List(string path);
    }

    public interface IWCAzureBlobStorageService : IStorageService
    {

    }

    public interface ICentralBlobStorageService : IStorageService
    {
        string AccessToken { get; set; }
        Task<CentralBlobStorageAccessTokenResponse> Connect();
        Task<CentralBlobStorageGetFolderResponse> GetFolder();
        Task<string> GetDownloadUrl(string path);
    }
}
