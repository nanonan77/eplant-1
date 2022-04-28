using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Infrastructure.Datas.Configurations
{
    public class AssumptionEntityTypeConfiguration : IEntityTypeConfiguration<Assumption>
    {
        public void Configure(EntityTypeBuilder<Assumption> builder)
        {
            builder.ConfigEntityBaseTypeTrans();

            builder.Property(e => e.NewRegistId).IsRequired();
            builder.Property(e => e.RentalArea).HasPrecision(22, 2);
            builder.Property(e => e.ProductiveArea).HasPrecision(22, 2);

            builder.Property(e => e.DistanceToPlant).HasPrecision(22, 2);
            builder.Property(e => e.Mill).HasMaxLength(100).IsUnicode(true);
            builder.Property(e => e.AveragePrice).HasPrecision(22, 2);
            builder.Property(e => e.MtpPrice).HasPrecision(22, 2);
            builder.Property(e => e.FcPrice).HasPrecision(22, 2);
            builder.Property(e => e.CuttingCost).HasPrecision(22, 2);
            builder.Property(e => e.Freight).HasPrecision(22, 2);

            builder.HasOne(e => e.NewRegist)
                    .WithMany()
                    .HasForeignKey(e => e.NewRegistId)
                    .HasPrincipalKey(e => e.Id)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.AssumptionYields)
                .WithOne(i => i.Assumption)
                .HasForeignKey(e => e.AssumptionId)
                .HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.AssumptionClones)
                .WithOne(i => i.Assumption)
                .HasForeignKey(e => e.AssumptionId)
                .HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.MasterCuttingCostType)
                    .WithMany()
                    .HasForeignKey(e => e.CuttingCostTypeId)
                    .HasPrincipalKey(e => e.Id)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.MasterFreightType)
                    .WithMany()
                    .HasForeignKey(e => e.FreightTypeId)
                    .HasPrincipalKey(e => e.Id)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.NoAction);


            builder.HasMany(e => e.Expenses)
                .WithOne(i => i.Assumption)
                .HasForeignKey(e => e.AssumptionId)
                .HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
