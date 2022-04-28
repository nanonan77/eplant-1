using Hangfire;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Sketec.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sketec.IdentityServer.Hangfires
{
    public class HangfireConfiguration
    {
        public static void RegisterJob(IWebHostEnvironment env, IConfiguration configuration)
        {
            var settings = new ApplicationSettings();
            configuration
                .GetSection(ApplicationSettings.Key)
                .Bind(settings);

            HangfireJobProvider.ApplicationSettings = settings;

            if (env.IsDevelopment())
            {
                RegisterDevJob();
            }
            else if(env.IsProduction())
            {
                RegisterProductionJob();
            }
            else
            {
                RegisterStagingJob();
            }
        }

        private static void RegisterDevJob()
        {

        }

        private static void RegisterStagingJob()
        {
            RecurringJob.AddOrUpdate("Import NewRegist", () => HangfireJobProvider.ImportNewRegist(), "15,45 * * * *", TimeZoneInfo.Utc);
            RecurringJob.AddOrUpdate("Export Activity", () => HangfireJobProvider.ExportMasterActivity(), "0 16 * * *", TimeZoneInfo.Utc);
            RecurringJob.AddOrUpdate("Update User Info", () => HangfireJobProvider.UpdateUserInfo(), "0 22 * * *", TimeZoneInfo.Utc);
            RecurringJob.AddOrUpdate("Notification NewRegist", () => HangfireJobProvider.NotiNewRegist(), "30 0 * * *", TimeZoneInfo.Utc);
        }

        private static void RegisterProductionJob()
        {
            //RecurringJob.AddOrUpdate("Staging Sync", () => HangfireJobProvider.StagingSync(), Cron.Daily(2, 30), TimeZoneInfo.Utc);
        }
    }
}
