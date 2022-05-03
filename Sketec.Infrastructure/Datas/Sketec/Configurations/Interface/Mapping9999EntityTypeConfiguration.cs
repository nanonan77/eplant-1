using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sketec.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Infrastructure.Datas.Configurations
{
    public class Mapping9999EntityTypeConfiguration : IEntityTypeConfiguration<Mapping9999>
    {
        public void Configure(EntityTypeBuilder<Mapping9999> builder)
        {
            builder.ConfigEntityBaseTypeTrans();

            builder.Property(e => e.CostCenter)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.CostElement)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.PurchaseOrderText)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.RefDocumentNumber)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.RefCompanyCode)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.ValCOAreaCrcy).HasPrecision(22, 2);

        }
    }
}
