using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Sketec.Application.Configurations;
using Sketec.Application.Filters;
using Sketec.Application.Shared;
using Sketec.Core.Interfaces;
using Sketec.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Sketec.FileWriter.Textfile;
using Sketec.Core.Resources;
using Sketec.Core.Resources.Gdc;

namespace Sketec.Api
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
                o.Filters.Add(typeof(UpdateRequestInformationToApplicationServiceFilter));
            });


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "EPlant.Api", Version = "v1"});

                c.AddSecurityDefinition("JWT", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });


                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "JWT",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });

            services.AddAuthentication(o =>
                {
                    o.DefaultAuthenticateScheme = "Bearer";
                    o.DefaultChallengeScheme = "Bearer";
                    o.DefaultScheme = "Bearer";
                })
                .AddJwtBearer("Bearer", o =>
                {
                    var openIdSettings = Configuration.GetSection("OpenId").Get<OpenIdSettings>();

                    Console.WriteLine($"Open ID Authority: {openIdSettings.Authority}");
                    o.Authority = openIdSettings.Authority;
                    o.TokenValidationParameters.ValidateAudience = false;
                    o.TokenValidationParameters.NameClaimType = "preferred_username";
                    o.SaveToken = true;
                });

            services.AddAuthorization(o =>
            {
                o.AddPolicy("BaseAPIScope", p =>
                {
                    p.RequireAuthenticatedUser();
                    p.RequireClaim("scope", "ep-api");
                });
            });

            services.AddCors(o =>
            {
                o.AddDefaultPolicy(b =>
                    b.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .Build()
                );
            });

            services.AddApplicationInsightsTelemetry(o =>
            {
                var connectionString = Configuration.GetSection("ApplicationInsightConnectionString").Value;
                if (!string.IsNullOrEmpty(connectionString))
                    o.ConnectionString = connectionString;
            });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                // remove chekc known ip becuase app service proxy server host not use looback ipaddress
                options.KnownProxies.RemoveAt(0);
                options.KnownNetworks.RemoveAt(0);
            });

            ConfigAdditionSerivce(services);
        }

        void ConfigAdditionSerivce(IServiceCollection services)
        {
            //services.Configure<CrmApiOptions>(Configuration.GetSection("CrmApiSettings"));
            services.Configure<SftpConfig>(Configuration.GetSection("SftpConfig"));
            services.Configure<GdcApiOptions>(Configuration.GetSection("GdcApiSettings"));
            services.Configure<SharePointOptions>(Configuration.GetSection("SharePointSettings"));
            // services.AddScoped<ICrmApiService, CrmApiService>();

            services.AddScoped<TextFileWriter>();
            services.AddScoped<ISftpService, SftpService>();
            services.AddScoped<TextFileManager>();
            services.AddScoped<ExcelService>();

            #region Background Servicex

            //services.AddHostedService<StagingSyncDataBackgroundService>();

            #endregion

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            app.UseForwardedHeaders();
            app.Use((ctx, next) =>
            {
                logger.LogInformation(
                    $"Incomming Request : {ctx.Connection.RemoteIpAddress} | name: {ctx.User.Identity.Name} | path : {ctx.Request.Path}{ctx.Request.QueryString}");
                return next();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EPlant.Api v1"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseHsts();
                //app.UseHttpsRedirection();
            }

            app.Use((ctx, next) =>
            {
                if (ctx.Request.Path == "/")
                    return ctx.Response.WriteAsync("Wakanda Forever.");
                return next();
            });

            app.Map("/env", conf =>
            {
                conf.Run((ctx) =>
                {
                    var list = ctx.Request.Headers.Select(f => $"{f.Key}:${f.Value}");
                    return ctx.Response.WriteAsync(
                        $"ip: {ctx.Connection.RemoteIpAddress} ,env {env.EnvironmentName} , {ctx.Request.Scheme} , {string.Join('|', list)}");
                });
            });

            app.UseCors();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                .RequireAuthorization("BaseAPIScope");
            });
        }
    }
}