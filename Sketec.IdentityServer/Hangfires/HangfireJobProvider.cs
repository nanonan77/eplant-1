using Sketec.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sketec.IdentityServer.Hangfires
{
    public class HangfireJobProvider
    {
        public static ApplicationSettings ApplicationSettings { get; set; }
        public static async Task ImportNewRegist()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApplicationSettings.ApiUrl);

                var path = $"/job/importnewregist";

                await client.GetAsync(path);
            }
        }

        public static async Task ExportMasterActivity()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApplicationSettings.ApiUrl);

                var path = $"/job/export-master-activity";

                await client.GetAsync(path);
            }
        }
        public static async Task UpdateUserInfo()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApplicationSettings.ApiUrl);

                var path = $"/user/update-info";

                await client.GetAsync(path);
            }
        }

        public static async Task NotiNewRegist()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApplicationSettings.ApiUrl);

                var path = $"/job/noti-new-regist";

                await client.GetAsync(path);
            }
        }
    }
}
