using Sketec.Core.Interfaces;
using Sketec.Core.Resources;
using Sketec.Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Infrastructure.Services
{
    public class WCAzureBlobStorageService : AzureBlobStorageService, IWCAzureBlobStorageService
    {
        public WCAzureBlobStorageService(AzureBlobStorageOptions storageOptions) : base(new AzureBlobStorageOptions()
        {
            StorageUrl = storageOptions.StorageUrl
        })
        {

        }
    }
}
