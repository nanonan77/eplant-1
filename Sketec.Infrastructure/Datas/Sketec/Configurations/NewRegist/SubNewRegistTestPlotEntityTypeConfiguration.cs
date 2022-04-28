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
    public class SubNewRegistTestPlotEntityTypeConfiguration : IEntityTypeConfiguration<SubNewRegistTestPlot>
    {
        public void Configure(EntityTypeBuilder<SubNewRegistTestPlot> builder)
        {
            builder.ConfigEntityBaseTypeTrans();
            builder.Property(e => e.SubRegistId).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.SubNewRegistTestId).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.Latitude).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.Longitude).HasMaxLength(50).IsUnicode(true);

            builder.Property(e => e.Depth).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.SoillFloorDepth).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.GravelDepth).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.PH30).HasPrecision(22, 2);
            builder.Property(e => e.PH60).HasPrecision(22, 2);
            builder.Property(e => e.EC30).HasPrecision(22, 2);
            builder.Property(e => e.EC60).HasPrecision(22, 2);
            builder.Property(e => e.Dot).HasMaxLength(50).IsUnicode(true);

            builder.Property(e => e.ItemType).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.Path).HasMaxLength(500).IsUnicode(true);

        }
    }
}
