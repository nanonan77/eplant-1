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
    public class PlantationAmortizedEntityTypeConfiguration : IEntityTypeConfiguration<PlantationAmortized>
    {
        public void Configure(EntityTypeBuilder<PlantationAmortized> builder)
        {
            builder.ConfigEntityBaseTypeTrans();
            builder.Property(e => e.CashPaid).HasPrecision(22, 2);
            builder.Property(e => e.MonthlyRental).HasPrecision(22, 2);
            builder.Property(e => e.Interest).HasPrecision(22, 2);
            builder.Property(e => e.Depreciation).HasPrecision(22, 2);
        }
    }
}
