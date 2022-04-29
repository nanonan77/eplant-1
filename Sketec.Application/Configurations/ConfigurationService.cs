using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sketec.Application.Interfaces;
using Sketec.Application.Interfaces.Management;
using Sketec.Application.Interfaces.Plantation;
using Sketec.Application.Services;
using Sketec.Application.Shared;
using Sketec.Core.Interfaces;
using Sketec.Core.Resources;
using Sketec.Core.Resources.Email;
using Sketec.Core.Resources.Gdc;
using Sketec.FileWriter.Textfile;
using Sketec.Infrastructure.Abstracts;
using Sketec.Infrastructure.Datas;
using Sketec.Infrastructure.Interfaces;
using Sketec.Infrastructure.Repositories;
using Sketec.Infrastructure.Services;
using Sketec.Infrastructure.UnitOfWorks;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using SftpService = Sketec.Infrastructure.Abstracts.SftpService;

namespace Sketec.Application.Configurations
{
    public static class ConfigurationService
    {
        public static Type[] GetAutoMapperAssembly()
        {
            return new[] { typeof(ConfigurationService), typeof(IAggregateRoot) };
        }

        public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {

            #region Auto Mapper

            services.AddAutoMapper(GetAutoMapperAssembly());

            #endregion

            #region DB Context
            services.AddDbContext<SketecContext>(o =>
                o.UseSqlServer(configuration.GetConnectionString("MainConnectionString"), b =>
                {
                    b.MigrationsAssembly("Sketec.Application");
                    b.CommandTimeout(180);
                    b.UseRelationalNulls(true);
                })
                );

            //services.AddDbContext<WebCreditStagingContext>(o =>
            //    o.UseSqlServer(configuration.GetConnectionString("WebCreditStagingConnectionString"), b =>
            //    {
            //        b.MigrationsAssembly("Sketec.Application");
            //        b.CommandTimeout(1000);
            //    })
            //    );

            //services.AddDbContext<WebCreditLogContext>(o =>
            //    o.UseSqlServer(configuration.GetConnectionString("WebCreditLogConnectionString"), b =>
            //    {
            //        b.MigrationsAssembly("Sketec.Application");
            //        b.CommandTimeout(180);
            //    })
            //    );
            #endregion

            #region Data Access Service

            services.AddScoped(typeof(IWCRepository<>), typeof(WCRepository<>));
            services.AddScoped(typeof(IWCReadRepository<>), typeof(WCReadRepository<>));

            services.AddScoped<IWCDapperRepository, WCDapperRepository>();

            services.AddScoped<IWCUnitOfWork, WCUnitOfWork>();
            services.AddScoped<IWCQueryRepository, WCQueryRepository>();

            #endregion

            #region Identity Core

            services.AddIdentity<IdentityUser, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequiredLength = 8;
                o.Password.RequireNonAlphanumeric = true;
                o.Password.RequireLowercase = true;
                o.Password.RequireUppercase = true;

                o.User.RequireUniqueEmail = true;

                o.SignIn.RequireConfirmedEmail = true;
            })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<SketecContext>();

            services.ConfigureApplicationCookie(o =>
            {
                o.LoginPath = "/login";
            });

            #endregion

            #region Application Service

            #region Master
            services.AddScoped<IMasterActivityTypeService, MasterActivityTypeService>();
            services.AddScoped<IMasterConfigurationService, MasterConfigurationService>();
            services.AddScoped<IMasterTransportationService, MasterTransportationService>();
            services.AddScoped<IMasterActivityService, MasterActivityService>();
            #endregion Master


            #region NewRegist
            services.AddScoped<IStatusTrackingService, StatusTrackingService>();
            #endregion NewRegist

            #region Assumption

            services.AddScoped<IAssumptionService, AssumptionService>();
            #endregion

            services.AddScoped<IAccountService, AccountService>();
            //services.AddScoped<IConfigurationService, Services.ConfigurationService>();
            services.AddScoped<IRunningNumberService, RunningNumberService>();
            services.AddScoped<IUserService, UserService>();
            //services.AddScoped<ISftpService, FileWriter.Textfile.SftpService>();
            services.AddScoped<ICentralBlobStorageService, CentralBlobStorageService>();
            //services.AddScoped<IMasterCCAAndBusinessPlaceService, MasterCCAAndBusinessPlaceService>();
            services.AddScoped<ITestNewRegistService, TestNewRegistService>();
            services.AddScoped<ITestSubNewRegistService, TestSubNewRegistService>();
            services.AddScoped<ITestSubNewRegistPhysicalService, TestSubNewRegistPhysicalService>();
            //services.AddScoped<IRelationService, RelationService>();
            services.AddScoped<IGdcService, GdcService>();

            services.AddScoped<INewRegistService, NewRegistService>();
            services.AddScoped<ISharePointService, SharePointService>();
            services.AddScoped<IJobsService, JobsService>();

            services.AddScoped<ITestNewRegistStatusLogService, TestNewRegistStatusLogService>();
            
            services.AddScoped<IFileInfoService, FileInfoService>();
            #endregion

            #region Plantation
            services.AddScoped<IPlantationService, PlantationService>();
            services.AddScoped<INewPlantationService, NewPlantationService>();
            services.AddScoped<ISubNewPlantationService, SubNewPlantationService>();
            services.AddScoped<IUnplanService, UnplanService>();
            #endregion Plantation

            #region RollingPlan
            services.AddScoped<IRollingPlanService, RollingPlanService>();
            #endregion RollingPlan

            #region Interface
            services.AddScoped<IMapping9999Service, Mapping9999Service>();
            #endregion Interface

            #region Infra Service

            var gdcOptions = configuration.GetSection("GdcApiSettings").Get<GdcApiOptions>();
            services.AddSingleton(gdcOptions);

            var rabbitMQOptions = configuration.GetSection("RabbitMQSettings").Get<RabbitMQOptions>();
            services.AddSingleton(rabbitMQOptions);

            var centralBlobStorageOptions = configuration.GetSection("CentralBlobStorageSettings").Get<CentralBlobStorageOptions>();
            services.AddSingleton(centralBlobStorageOptions);

            var wcAzureBlob = configuration.GetSection("AzureBlobStorageSettings").Get<AzureBlobStorageOptions>();
            services.AddSingleton(wcAzureBlob);

            var sharePointOptions = configuration.GetSection("SharePointSettings").Get<SharePointOptions>();
            services.AddSingleton(sharePointOptions);

            var emailOptions = configuration.GetSection(EmailSettings.Key).Get<EmailSettings>();
            services.AddSingleton(emailOptions);

            services.AddScoped<IEmailService, ExchangeEmailService>();
            services.AddScoped<IWCAzureBlobStorageService, WCAzureBlobStorageService>();
            services.AddScoped<IGdcApiService, GdcApiService>();
            services.AddScoped<IRabbitMQService, RabbitMQService>();

            var sftpOptions = configuration.GetSection("SftpConfig").Get<SftpSettings>();
            services.AddSingleton(sftpOptions);

            services.AddScoped<IWCSftpService>(service =>
            {
                var options = (SftpSettings)service.GetService(typeof(SftpSettings));
                var logger = service.GetService<ILogger<SftpService>>();
                return new WCSftpService(new FtpOptions
                {
                    Host = options.Host,
                    Password = options.Password,
                    Port = options.Port,
                    Username = options.UserName
                }, logger);
            });

            #endregion

            #region Config
            services.Configure<EmailSettings>(configuration.GetSection(EmailSettings.Key));
            services.Configure<ApplicationSettings>(configuration.GetSection(ApplicationSettings.Key));
            #endregion
        }
    }
}
