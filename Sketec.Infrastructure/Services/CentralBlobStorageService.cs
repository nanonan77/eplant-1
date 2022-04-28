using EnsureThat;
using Sketec.Core.Exceptions;
using Sketec.Core.Interfaces;
using Sketec.Core.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Infrastructure.Services
{
    public class CentralBlobStorageService : ICentralBlobStorageService
    {
        private CentralBlobStorageOptions options;
        public string AccessToken { get; set; }

        public CentralBlobStorageService(CentralBlobStorageOptions options)
        {
            this.options = options;
        }

        public async Task<CentralBlobStorageAccessTokenResponse> Connect()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(options.BaseUrl);
                var jsonContent = JsonContent.Create(new CentralBlobStorageAccessTokenRequest
                {
                    Username = options.Username,
                    Password = options.Password
                });

                var resp = await client.PostAsync("/api/Auth/Login", jsonContent);

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var tokenResponse = await resp.Content.ReadFromJsonAsync<CentralBlobStorageAccessTokenResponse>();

                    return tokenResponse;
                }
                else
                {
                    throw new InfrastructureException($"Fail to get access token for Central Blob Storage >> Status Code : {resp.StatusCode}");
                }
            }
        }

        private async Task<TResponse> Get<TResponse>(string url)
        {
            EnsureArg.IsNotNullOrEmpty(AccessToken, nameof(AccessToken));

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(options.BaseUrl);

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");

                var resp = await client.GetAsync(url);

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResponse = await resp.Content.ReadFromJsonAsync<TResponse>();
                    return jsonResponse;
                }
                else
                {
                    throw new InfrastructureException($"Fail to request from url {url} >> Status Code {resp.StatusCode}");
                }
            }
        }

        public Task Delete(string path)
        {
            throw new NotImplementedException();
        }

        public async Task<Stream> Download(string path)
        {
            var url = await GetDownloadUrl(path);
            EnsureArg.IsNotNullOrWhiteSpace(url);
            using (var downloadClient = new HttpClient())
            {
                var downloadStream = await downloadClient.GetStreamAsync(url);

                return downloadStream;
            }
        }

        public async Task Upload(string path, Stream stream)
        {
            EnsureArg.IsNotNullOrEmpty(AccessToken, nameof(AccessToken));
            EnsureArg.IsNotNullOrWhiteSpace(path, nameof(path));

            var folder = Path.GetDirectoryName(path).Replace("\\", "/");
            var fileName = Path.GetFileName(path);

            EnsureArg.IsNotNullOrWhiteSpace(folder, nameof(folder));
            EnsureArg.IsNotNullOrWhiteSpace(fileName, nameof(fileName));

            EnsureArg.IsTrue(stream.CanSeek, "Seek Stream");
            EnsureArg.IsTrue(stream.CanRead, "Read Stream");


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(options.BaseUrl);
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");

                var formContent = new MultipartFormDataContent();

                var folderNameContent = new StringContent(folder);
                formContent.Add(folderNameContent, "folderName");

                stream.Seek(0, SeekOrigin.Begin);
                var fileContent = new StreamContent(stream);
                formContent.Add(fileContent, "formFile", fileName);

                var resp = await client.PostAsync("/api/Blob/UploadFile", formContent);

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var respContent = await resp.Content.ReadFromJsonAsync<CentralBlobStorageUploadFileResponse>();
                    if (respContent.StatusCode != 200)
                    {
                        throw new InfrastructureException($"Fail To upload {fileName}, message {respContent.Message} >> Status Code {respContent.StatusCode}");
                    }
                }
                else
                {
                    throw new InfrastructureException($"Fail To upload file {fileName} to folder {folder} >> Status Code {resp.StatusCode}");
                }
            }
        }

        public Task<CentralBlobStorageGetFolderResponse> GetFolder()
        {
            return Get<CentralBlobStorageGetFolderResponse>("/api/Blob/Folder");
        }

        public async Task<string> GetDownloadUrl(string path)
        {
            EnsureArg.IsNotNullOrEmpty(AccessToken, nameof(AccessToken));
            EnsureArg.IsNotNullOrWhiteSpace(path, nameof(path));

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(options.BaseUrl);
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");

                var request = new CentralBlobStorageDownloadFileRequest
                {
                    FilePath = path
                };
                var resp = await client.PostAsJsonAsync("/api/Blob/DownloadFile", request);

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contentResp = await resp.Content.ReadFromJsonAsync<CentralBlobStorageDownloadFileResponse>();
                    if (contentResp.StatusCode != 200)
                    {
                        throw new InfrastructureException($"Fail To download file {path}, message {contentResp.Message} >> Status Code {contentResp.StatusCode}");
                    }
                    return contentResp.Data.Url;
                }
                else
                {
                    throw new InfrastructureException($"Fail To download file {path} >> Status Code {resp.StatusCode}");
                }
            }
        }

        public async Task Upload(string path, byte[] bytes)
        {
            EnsureArg.IsNotNullOrEmpty(AccessToken, nameof(AccessToken));
            EnsureArg.IsNotNullOrWhiteSpace(path, nameof(path));
            EnsureArg.IsNotNull(bytes, nameof(bytes));

            var folder = Path.GetDirectoryName(path).Replace("\\", "/");
            var fileName = Path.GetFileName(path);

            EnsureArg.IsNotNullOrWhiteSpace(folder, nameof(folder));
            EnsureArg.IsNotNullOrWhiteSpace(fileName, nameof(fileName));


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(options.BaseUrl);
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");

                var formContent = new MultipartFormDataContent();

                var folderNameContent = new StringContent(folder);
                formContent.Add(folderNameContent, "folderName");

                var fileContent = new ByteArrayContent(bytes);
                formContent.Add(fileContent, "formFile", fileName);

                var resp = await client.PostAsync("/api/Blob/UploadFile", formContent);

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var respContent = await resp.Content.ReadFromJsonAsync<CentralBlobStorageUploadFileResponse>();
                    if (respContent.StatusCode != 200)
                    {
                        throw new InfrastructureException($"Fail To upload {fileName}, message {respContent.Message} >> Status Code {respContent.StatusCode}");
                    }
                }
                else
                {
                    var strResp = await resp.Content.ReadAsStringAsync();
                    throw new InfrastructureException($"Fail To upload file {fileName} to folder {folder} >> Status Code {resp.StatusCode} >> {strResp}");
                }
            }
        }

        public Task<IEnumerable<string>> List(string path)
        {
            throw new NotImplementedException();
        }
    }
}
