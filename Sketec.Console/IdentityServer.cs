using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Sketec.ConsoleApp
{
    class IdentityServer
    {
        static ConfigurationDbContext CreateConfigurationContext()
        {
            var option = SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<ConfigurationDbContext>(), "Data Source=tcp:scgp-it-centraldb-dev.02808e68e5dd.database.windows.net;Initial Catalog=OneCredit;User Id=azsqlmi_sketec_dev;Password=C4ol@&Gr*H%72@g01#u*").Options;
            var db = new ConfigurationDbContext(option, new IdentityServer4.EntityFramework.Options.ConfigurationStoreOptions()
            {
                DefaultSchema = "IdentityServer_Configuration"
            });
            return db;
        }

        public static void CrateClient()
        {
            using (var db = CreateConfigurationContext())
            {

                var client = new Client
                {
                    ClientId = Guid.NewGuid().ToString(),
                    ClientName = "RPA",
                    AllowedGrantTypes = { GrantType.ClientCredentials },
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("NF#xn&cmzTc6re7mfW-A+kg2Sz*u3tvtcfL4".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = {
                        "ep-api",
                        "rpa"
                    },
                };

                var entity = client.ToEntity();

                db.Clients.Add(entity);
                db.SaveChanges();
            }
        }

        public static void CreateApiScope()
        {
            using (var db = CreateConfigurationContext())
            {
                var scope = new ApiScope("rpa", "Tigger RAP Job");
                var scopeEntity = scope.ToEntity();
                db.ApiScopes.Add(scopeEntity);

                //var apiResource = new ApiResource("rpa","RPA Job")
                //{
                //    Scopes = { "rpa.write" }
                //};
                //var apiResourceEntity = apiResource.ToEntity();
                //db.ApiResources.Add(apiResourceEntity);
                db.SaveChanges();
            }
        }
    }
}
