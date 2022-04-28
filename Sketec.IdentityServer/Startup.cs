using Hangfire;
using Hangfire.Annotations;
using Hangfire.Dashboard;
using IdentityServer4;
using IdentityServer4.AspNetIdentity;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using Sketec.Application.Configurations;
using Sketec.Application.Filters;
using Sketec.IdentityServer.Hangfires;
using Sketec.IdentityServer.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Sketec.IdentityServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddApplicationService(Configuration);

            services.AddControllersWithViews(o =>
            {
                o.Filters.Add(typeof(ExceptionHandlerFilter));
            });


            services.AddApplicationInsightsTelemetry(o =>
            {
                o.ConnectionString = Configuration["APPINSIGHTS_CONNECTIONSTRING"];
            });

            services.AddIdentityServer(o =>
            {
                o.UserInteraction.ErrorUrl = "/error";
                o.UserInteraction.LoginUrl = "/login";
                o.UserInteraction.LogoutUrl = "/logout";
            })
                .AddAspNetIdentity<IdentityUser>()
                .AddProfileService<SketecProfileService>()
                .AddDeveloperSigningCredential()
                .AddConfigurationStore(options =>
                {
                    options.DefaultSchema = "IdentityServer_Configuration";
                    options.ConfigureDbContext = db =>
                    {
                        db.UseSqlServer(Configuration.GetConnectionString("MainConnectionString"), b =>
                        {
                            b.MigrationsAssembly("Sketec.Application");
                        });
                    };
                })
                .AddOperationalStore(options =>
                {
                    options.DefaultSchema = "IdentityServer_PersistedGrant";
                    options.ConfigureDbContext = db =>
                    {
                        db.UseSqlServer(Configuration.GetConnectionString("MainConnectionString"), b => b.MigrationsAssembly("Sketec.Application"));
                    };
                });

            services.AddAuthentication()
                .AddMicrosoftIdentityWebApp(Configuration, openIdConnectScheme: IdentityServerConfig.MicrosoftOpenIdScheme, cookieScheme: null);

            services.Configure<MicrosoftIdentityOptions>(IdentityServerConfig.MicrosoftOpenIdScheme, o =>
             {
                 o.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                 o.SaveTokens = true;
                 o.SignOutScheme = IdentityConstants.ApplicationScheme;

                 o.Events.OnRemoteFailure = ctx =>
                {
                    ctx.HandleResponse();
                    ctx.Response.Redirect($"/errorMessage?error={WebUtility.UrlEncode(ctx.Failure.Message)}");
                    return Task.CompletedTask;
                };
             });



            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddCors(o =>
            {
                o.AddDefaultPolicy(b =>
                {
                    b.AllowAnyHeader();
                    b.AllowAnyOrigin();
                    b.AllowAnyMethod();
                });
            });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                // remove chekc known ip becuase app service proxy server host not use looback ipaddress
                options.KnownProxies.RemoveAt(0);
                options.KnownNetworks.RemoveAt(0);
            });

            // Hangfire
            services.AddHangfire(x => 
                x.UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnectionString"))
                );
            services.AddHangfireServer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            app.UseForwardedHeaders();
            if (env.IsDevelopment())
            {
                //Run this in deveopment env to seed data for  identity's config
                // IdentityServerConfig.SeedDatabaseConfiguration(app);
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.Map("/env", conf =>
            {
                conf.Run((ctx) =>
                {
                    var list = ctx.Request.Headers.Select(f => $"{f.Key}:${f.Value}");
                    return ctx.Response.WriteAsync($"ip: {ctx.Connection.RemoteIpAddress} ,env {env.EnvironmentName} , {ctx.Request.Scheme} , {string.Join('|', list)}");
                });
            });

            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseCors();

            app.UseRouting();

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                Secure = CookieSecurePolicy.Always,
            });


            app.UseIdentityServer();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");

                endpoints.MapHangfireDashboard("/monitor",new DashboardOptions
                {
                    Authorization = new List<IDashboardAuthorizationFilter>()
                    {
                        new DashboardAuthorizationFilter()
                    },
                    IgnoreAntiforgeryToken = true
                });
                HangfireConfiguration.RegisterJob(env, Configuration);
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }

    class DashboardAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }

}
