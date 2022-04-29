using AutoMapper;
using Microsoft.Extensions.Options;
using Sketec.Application.Interfaces;
using Sketec.Application.Shared;
using Sketec.Core.Domains;
using Sketec.Core.Interfaces;
using Sketec.Core.Specifications;
using Sketec.FileReader.Excels;
using Sketec.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Services
{
    public class JobsService : ApplicationService, IJobsService
    {
        IMapper mapper;
        IWCUnitOfWork uow;
        IWCDapperRepository dapper;
        IWCQueryRepository queryRepo;
        IWCRepository<NewRegist> newRegistRepo;
        ISharePointService sharePointService;
        INewRegistService newRegistService;
        IEmailService emailService;
        IMasterConfigurationService configService;
        IMasterActivityService activityService;
        ApplicationSettings applicationSettings;

        IRabbitMQService mqApiService;
        public JobsService(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            IWCRepository<NewRegist> newRegistRepo,
            IWCQueryRepository queryRepo,
            ISharePointService sharePointService,
            INewRegistService newRegistService,
            IEmailService emailService,
            IOptions<ApplicationSettings> appOptions,
            IMasterConfigurationService configService,
            IMasterActivityService activityService,
            IRabbitMQService mqApiService)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.dapper = dapper;
            this.queryRepo = queryRepo;
            this.newRegistRepo = newRegistRepo;
            this.sharePointService = sharePointService;
            this.newRegistService = newRegistService;
            this.configService = configService;
            this.activityService = activityService;
            this.emailService = emailService;
            applicationSettings = appOptions.Value;
            this.mqApiService = mqApiService;
        }

        public async Task ExportMasterActivityToSharepoint()
        {
            var data = await activityService.GetMasterActivitys(new MasterActivityFilter { IsExport = false });
            if (data.Any())
            {
                var byteArray = sharePointService.GetMasterActivityFile();
                if (byteArray == null)
                {
                    return;
                }

                var result = MasterActivityFileReader.WriteMasterActivity(byteArray, data);
                sharePointService.ReplaceMasterActivityFile(result);
                await activityService.UpdateIsExportMasterActivity(data);
            }
        }

        public async Task ImportNewRegistrationFromSharepoint() 
        {
            var byteArray = sharePointService.GetNewRegistFile();
            if (byteArray == null)
            {
                return;
            }
            var newRegistData = NewRegistFileReader.GetNewRegistDetail(byteArray);
            if(newRegistData == null)
            {
                return;
            }

            if (newRegistData.NewRegist.Any()) 
            {
                await newRegistService.ImportNewRegist(newRegistData.NewRegist);
            }
            if (newRegistData.SubNewRegist.Any())
            {
                await newRegistService.ImportSubNewRegist(newRegistData.SubNewRegist);
            }
            if (newRegistData.SubNewRegistTestPlot.Any())
            {
                await newRegistService.ImportSubNewRegistTestPlot(newRegistData.SubNewRegistTestPlot);
            }
            if (newRegistData.NewRegistImagePath.Any())
            {
                await newRegistService.ImportNewRegistImagePath(newRegistData.NewRegistImagePath);
            }

            sharePointService.ReplaceNewRegistFile();
            return;
        }
    
        public async Task NotiNewRegist()
        {
            var config = await configService.GetMasterConfiguration(new MasterConfigurationFilter { ConfigurationKey = "Day" });
            if (config.Any())
            {
                var days = Convert.ToInt32(config.FirstOrDefault().Value);

                var spec = new NewRegistNotiSpec(days);
                var data = dapper.Query(spec);
                if (data.Any())
                {
                    foreach (var item in data)
                    {
                        var content = $"เรียน {item.Verifier}<br /><br />";
                        content += $"แจ้งเตือนงาน <b><span style='color: red'>Delayed</span></b> พิจารณาแปลงสวนไม้ {item.ContractType} {item.Title}<br />";
                        content += $"ล่าช้ามาแล้ว <b><span style='color: red'>{item.Days.ToString()}</span></b> วัน<br /><br />";
                        content += $"<a href='{applicationSettings.BaseUrl}/new-regist/rental/{item.NewRegistId.ToString()}'>>>> Click <<<</a><br /><br />";
                        content += $"Best regards,<br />";
                        content += $"e-Plantation Admin";


                        await emailService.SendEmailAsync(new Core.Resources.Email.SendEmailRequest
                        {
                            Subject = $"[New Registration] Verify {item.ContractType} {item.Title}",
                            EmailsTo = new string[] { item.VerifierEmail },
                            EmailsCC = new string[] { item.PIC },
                            Content = content
                        });
                    }
                }
            }
        }
        public void CeatePRQ()
        {
            mqApiService.CeatePRQ();
        }

        public void CeateGR()
        {
            mqApiService.CeateGR();
        }
    }
}
