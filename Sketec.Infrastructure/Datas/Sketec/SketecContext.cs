using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sketec.Core.Domains;
using Sketec.Infrastructure.Datas.Configurations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sketec.Infrastructure.Datas
{
    public class SketecContext : IdentityDbContext
    {

        public SketecContext([NotNull] DbContextOptions<SketecContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.UseCollation("Thai_CI_AS");
            #region Master
            builder.ApplyConfiguration(new MasterActivityTypeEntityTypeConfiguration());
            builder.ApplyConfiguration(new MasterActivityEntityTypeConfiguration());
            builder.ApplyConfiguration(new MasterTransportationHeaderEntityTypeConfiguration());
            builder.ApplyConfiguration(new MasterTransportationDetailEntityTypeConfiguration());
            builder.ApplyConfiguration(new MasterConfigurationEntityTypeConfiguration());

            builder.ApplyConfiguration(new FeasibilityYieldEntityTypeConfiguration());
            builder.ApplyConfiguration(new FeasibilityPriceEntityTypeConfiguration());

            builder.ApplyConfiguration(new DistrictEntityTypeConfiguration());
            builder.ApplyConfiguration(new SubDistrictEntityTypeConfiguration());
            builder.ApplyConfiguration(new ProvinceEntityTypeConfiguration());

            builder.ApplyConfiguration(new UserEntityTypeConfiguration());
            builder.ApplyConfiguration(new MasterCostCenterEntityTypeConfiguration());
            builder.ApplyConfiguration(new MasterRunningNumberEntityTypeConfiguration());
            builder.ApplyConfiguration(new RunningNumberEntityTypeConfiguration());
            builder.ApplyConfiguration(new RoleActivityEntityTypeConfiguration());

            #endregion Master

            #region Management
            builder.ApplyConfiguration(new NewRegistEntityTypeConfiguration());
            builder.ApplyConfiguration(new SubNewRegistEntityTypeConfiguration());
            builder.ApplyConfiguration(new SubNewRegistTestPlotEntityTypeConfiguration());
            builder.ApplyConfiguration(new NewRegistImagePathEntityTypeConfiguration());
            builder.ApplyConfiguration(new NewRegistStatusLogEntityTypeConfiguration());
            builder.ApplyConfiguration(new AssumptionEntityTypeConfiguration());
            builder.ApplyConfiguration(new AssumptionYieldEntityTypeConfiguration());
            builder.ApplyConfiguration(new AssumptionCloneEntityTypeConfiguration());
            builder.ApplyConfiguration(new ExpenseEntityTypeConfiguration());

            builder.ApplyConfiguration(new PlantationEntityTypeConfiguration());
            builder.ApplyConfiguration(new SubPlantationEntityTypeConfiguration());

            builder.ApplyConfiguration(new RollingPlanEntityTypeConfiguration());

            builder.ApplyConfiguration(new PlantationAmortizedEntityTypeConfiguration());
            #endregion Management

            #region Files
            builder.ApplyConfiguration(new FileInfoEntityTypeConfiguration());
            #endregion Files

            #region Interface
            builder.ApplyConfiguration(new Mapping9999EntityTypeConfiguration());
            builder.ApplyConfiguration(new Match9999EntityTypeConfiguration());
            builder.ApplyConfiguration(new MatchDataEntityTypeConfiguration());
            builder.ApplyConfiguration(new MatchPlantationEntityTypeConfiguration());
            builder.ApplyConfiguration(new MappingTransEntityTypeConfiguration());
            
            #endregion Interface

            Seed(builder);
        }

        private void Seed(ModelBuilder builder)
        {
            //builder.Entity<>(e =>
            //{
            //    e.HasData(

            //        );
            //});
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
