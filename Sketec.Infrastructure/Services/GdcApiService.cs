using Microsoft.Extensions.Logging;
using Sketec.Core.Exceptions;
using Sketec.Core.Interfaces;
using Sketec.Core.Resources.Gdc;
using Sketec.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Sketec.Infrastructure.Services
{
    public class GdcApiService : IGdcApiService
    {
        GdcApiOptions option;
        ILogger<GdcApiService> logger;


        public GdcApiService(
            GdcApiOptions option
            , ILogger<GdcApiService> logger
            )
        {
            this.option = option;
            this.logger = logger;
        }

        public async Task<string> GetAccessToken()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(option.Uri);
                var postData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type","password")
                };
                using (var content = new FormUrlEncodedContent(postData)) 
                {
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    content.Headers.Add("applicationId", option.ApplicationId);
                    content.Headers.Add("secretkey", option.SecretKey);

                    var resp = await client.PostAsync(option.AccessTokenPath, content);
                    var respContent = await resp.Content.ReadAsStringAsync();
                    logger.LogInformation(LogEvents.GdcApi_Response_Token, "respStatus: {status} | {respContent}", resp.StatusCode, respContent);
                    if (resp.StatusCode == HttpStatusCode.OK)
                    {
                        var jsonOption = new JsonSerializerOptions()
                        {
                            PropertyNameCaseInsensitive = true,
                        };
                        var respObj = JsonSerializer.Deserialize<AccessTokenResponse>(respContent, jsonOption);
                        logger.LogInformation(LogEvents.GdcApi_Response_Token_PraseJson, JsonSerializer.Serialize(respObj));

                        if (string.IsNullOrEmpty(respObj.access_token))
                            throw new InfrastructureException($"Error when get access_token : {respContent}");
                        return respObj.access_token;
                    }
                    else
                    {
                        throw new InfrastructureException($"Error when get access_token : {respContent}");
                    }
                }
                    
            }
        }

        public async Task<TResponse> Post<TRequest, TResponse>(string path, TRequest obj)
            where TResponse : class
            where TRequest : class
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(option.ApiUri);
                //var token = await GetAccessToken();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var jsonSerializerOption = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                };

                var resp = await client.PostAsJsonAsync(path, obj, jsonSerializerOption);
                var respContent = await resp.Content.ReadAsStringAsync();
                logger.LogInformation(LogEvents.GdcApi_Response_Post, "Status: {status} | {respContent}", resp.StatusCode, respContent);

                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    var jsonDeserializeOption = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var respObj = JsonSerializer.Deserialize<TResponse>(respContent, jsonDeserializeOption);

                    logger.LogInformation(LogEvents.GdcApi_Response_Post_PraseJson, JsonSerializer.Serialize(respObj));

                    return respObj;
                }
                else
                {
                    throw new InfrastructureException($"Error when post request to : {resp.RequestMessage.RequestUri}  > {respContent} \n | headers: {resp.RequestMessage.Headers}");
                }

            }
        }

        
    }
}
