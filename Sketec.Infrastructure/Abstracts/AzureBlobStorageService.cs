using Azure.Identity;
using Azure.Storage.Blobs;
using EnsureThat;
using Sketec.Core.Exceptions;
using Sketec.Core.Interfaces;
using Sketec.Core.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Infrastructure.Abstracts
{
    public abstract class AzureBlobStorageService : IStorageService
    {
        protected readonly AzureBlobStorageOptions storageOptions;
        protected readonly BlobServiceClient serviceClient;
        public AzureBlobStorageService(AzureBlobStorageOptions storageOptions)
        {
            EnsureArg.IsNotNull(storageOptions, nameof(storageOptions));
            EnsureArg.IsNotNullOrWhiteSpace(storageOptions.StorageUrl, nameof(storageOptions.StorageUrl));

            this.storageOptions = storageOptions;

            serviceClient = new BlobServiceClient(new Uri(storageOptions.StorageUrl), new DefaultAzureCredential(true));
        }

        private string GetContainerName(string path)
        {
            EnsureArg.IsNotNullOrWhiteSpace(path, nameof(path));

            if (path.StartsWith("/"))
            {
                path = path.Substring(1);
            }

            return path.Split('/')[0];
        }

        private string GetFileName(string path)
        {
            EnsureArg.IsNotNullOrWhiteSpace(path, nameof(path));
            var fileName = Path.GetFileName(path);
            EnsureArg.IsNotNullOrWhiteSpace(fileName, nameof(fileName));

            if (path.StartsWith("/"))
            {
                path = path.Substring(1);
            }

            var subString = path.Split('/');

            return string.Join('/', subString.Skip(1));
        }

        public virtual Task Delete(string path)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Stream> Download(string path)
        {
            var containerName = GetContainerName(path);
            var filename = GetFileName(path);
            EnsureArg.IsNotNullOrWhiteSpace(filename, nameof(filename));

            var container = serviceClient.GetBlobContainerClient(containerName);
            var containerExist = await container.ExistsAsync();
            if (!containerExist)
            {
                throw new InfrastructureException($"Fail to download Blob {path} , container not exist in storage");
            }


            var blob = container.GetBlobClient(filename);
            var existing = await blob.ExistsAsync();
            if (!existing)
            {
                throw new InfrastructureException($"Fail to download Blob {path} , blob not exist in storage");
            }

            var resp = await blob.DownloadStreamingAsync();
            var rawResp = resp.GetRawResponse();
            if (rawResp.Status != 200)
            {
                throw new InfrastructureException($"Fail to download Blob {path} , download error status code {rawResp.Status}");
            }

            return resp.Value.Content;
        }

        public virtual async Task Upload(string path, Stream stream)
        {
            EnsureArg.IsNotNull(stream, nameof(stream));
            EnsureArg.IsTrue(stream.CanRead);

            var containerName = GetContainerName(path);
            var filename = GetFileName(path);
            EnsureArg.IsNotNullOrWhiteSpace(filename, nameof(filename));

            var container = serviceClient.GetBlobContainerClient(containerName);
            await container.CreateIfNotExistsAsync();

            var blob = container.GetBlobClient(filename);

            var resp = await blob.UploadAsync(stream, true);
            var rawResp = resp.GetRawResponse();
            if (rawResp.Status < 200 || rawResp.Status >= 300)
            {
                throw new InfrastructureException($"Upload file with status code {rawResp.Status}");
            }
        }

        public async Task Upload(string path, byte[] bytes)
        {
            EnsureArg.IsNotNull(bytes, nameof(bytes));

            var containerName = GetContainerName(path);
            var filename = GetFileName(path);
            EnsureArg.IsNotNullOrWhiteSpace(filename, nameof(filename));

            var container = serviceClient.GetBlobContainerClient(containerName);
            await container.CreateIfNotExistsAsync();

            var blob = container.GetBlobClient(filename);

            var resp = await blob.UploadAsync(new BinaryData(bytes), true);
            var rawResp = resp.GetRawResponse();
            if (rawResp.Status < 200 || rawResp.Status >= 300)
            {
                throw new InfrastructureException($"Upload file with status code {rawResp.Status}");
            }
        }

        public Task<IEnumerable<string>> List(string path)
        {
            var containerName = GetContainerName(path);
            var container = serviceClient.GetBlobContainerClient(containerName);

            var blobs = container.GetBlobs(prefix: path);
            var files = new List<string>();
            foreach (var blob in blobs)
            {
                files.Add(blob.Name);
            }

            return Task.FromResult(files.AsEnumerable());
        }
    }
}
