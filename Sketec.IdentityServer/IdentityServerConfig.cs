using IdentityServer4;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sketec.Infrastructure.Datas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sketec.IdentityServer
{
    public class IdentityServerConfig
    {
        public const string MicrosoftOpenIdScheme = "MicrosoftOpenId";
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientName="E-Plant",
                    ClientUri="http://localhost:3111",
                    AllowOfflineAccess=true,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    RedirectUris={"http://localhost:3111/auth/login-cb","http://localhost:3111/auth/login-popup-cb","http://localhost:3111/auth/login-silent-cb",},
                    PostLogoutRedirectUris={ "http://localhost:3111" },
                    FrontChannelLogoutUri="http://localhost:3111/logout-backchannel",

                    // scopes that client has access to
                    AllowedScopes = {
                        "ep-api"
                        ,"role"
                        ,IdentityServerConstants.StandardScopes.OpenId
                        ,IdentityServerConstants.StandardScopes.Profile
                        ,IdentityServerConstants.StandardScopes.Email
                        ,IdentityServerConstants.StandardScopes.OfflineAccess
                    },
                }
            };
        public static IEnumerable<ApiScope> ApiScopes =>
                new List<ApiScope>
                {
                    new ApiScope("ep-api", "EPlant-Api",new string[] { "preferred_username" })
                    {
                        UserClaims = { "preferred_username","role","name","team", "isForceChangePassword", "section", "department", "role_activity" }
                    }
                };

        public static IEnumerable<IdentityResource> IdentityResources =>
                new List<IdentityResource>
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile(),
                    new IdentityResources.Email(),
                    new IdentityResource("role","User roles",new string[]{ "role"})
                };

        public static IEnumerable<ApiResource> ApiResources =>
                new List<ApiResource>
                {

                };

        public static void SeedDatabaseConfiguration(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var wc = serviceScope.ServiceProvider.GetRequiredService<SketecContext>();
                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                 context.Database.Migrate();

                if (!context.Clients.Any())
                {
                    foreach (var client in IdentityServerConfig.Clients)
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in IdentityServerConfig.IdentityResources)
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiScopes.Any())
                {
                    foreach (var resource in IdentityServerConfig.ApiScopes)
                    {
                        context.ApiScopes.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiResources.Any())
                {
                    foreach (var resource in IdentityServerConfig.ApiResources)
                    {
                        context.ApiResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
