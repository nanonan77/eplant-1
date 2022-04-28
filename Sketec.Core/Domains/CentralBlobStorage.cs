using EnsureThat;
using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class CentralBlobStorage : Entity, IAggregateRoot
    {
        public string Filename { get; set; }
        public string OriginalFilename { get; set; }
        public string DownloadUrl { get; set; }

        private CentralBlobStorage()
        {

        }

        public CentralBlobStorage(string fileName, string originalFilename, string downloadUrl)
        {
            EnsureArg.IsNotNullOrWhiteSpace(fileName, nameof(fileName));
            EnsureArg.IsNotNullOrWhiteSpace(originalFilename, nameof(originalFilename));
            EnsureArg.IsNotNullOrWhiteSpace(downloadUrl, nameof(downloadUrl));

            Filename = fileName;
            OriginalFilename = originalFilename;
            DownloadUrl = downloadUrl;
        }
    }
}
