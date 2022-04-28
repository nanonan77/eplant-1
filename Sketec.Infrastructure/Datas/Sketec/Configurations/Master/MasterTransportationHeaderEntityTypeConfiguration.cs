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
    public class MasterTransportationHeaderEntityTypeConfiguration : IEntityTypeConfiguration<MasterTransportationHeader>
    {
        public void Configure(EntityTypeBuilder<MasterTransportationHeader> builder)
        {
            builder.ConfigEntityBaseType();

            builder.Property(e => e.TruckType)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.FreightMin).HasPrecision(22, 2);
            builder.Property(e => e.FreightMax).HasPrecision(22, 2);

            builder.HasData(new MasterTransportationHeader("Normal")
            {
                Id = 1,
                FreightMin = Convert.ToDecimal(110),
                // FreightMax = (decimal?)null,
                IsActive = true,
                IsDelete = false
            });
        }
    }
}
