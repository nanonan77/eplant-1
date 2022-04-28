using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Resources
{
    public class CentralBlobStorageOptions
    {
        public string BaseUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class CentralBlobStorageAccessTokenResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }

    public class CentralBlobStorageAccessTokenRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class CentralBlobStorageGetFolderResponse
    {
        public IEnumerable<CentralBlobStorageGetFolderResponseData> Data { get; set; }
        public int StatusCode { get; set; }

        public class CentralBlobStorageGetFolderResponseData
        {
            public string Title { get; set; }
            public IEnumerable<CentralBlobStorageGetFolderResponseData> Children { get; set; }
        }
    }

    public class CentralBlobStorageUploadFileResponse
    {
        public string Message { get; set; }
        public string Data { get; set; }
        public int StatusCode { get; set; }
    }

    public class CentralBlobStorageDownloadFileRequest
    {
        public string FilePath { get; set; }
    }

    public class CentralBlobStorageDownloadFileResponse
    {
        public string Message { get; set; }
        public CentralBlobStorageDownloadFileDataResponse Data { get; set; }
        public int StatusCode { get; set; }

        public class CentralBlobStorageDownloadFileDataResponse
        {
            public string FileName { get; set; }
            public string Url { get; set; }
        }

    }

}
