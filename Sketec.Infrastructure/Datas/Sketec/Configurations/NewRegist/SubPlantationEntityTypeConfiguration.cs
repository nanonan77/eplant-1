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
    public class SubPlantationEntityTypeConfiguration : IEntityTypeConfiguration<SubPlantation>
    {
        public void Configure(EntityTypeBuilder<SubPlantation> builder)
        {
            builder.ConfigEntityBaseTypeTrans();
            builder.Property(e => e.Title).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.PlantationNo).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.SubPlantationNo).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.Latitude).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.Longitude).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.Area).HasPrecision(22, 2);
            //builder.Property(e => e.SoilType).HasMaxLength(500).IsUnicode(true);
            //builder.Property(e => e.LandUse).HasMaxLength(50).IsUnicode(true);
            //builder.Property(e => e.Accessibility).HasMaxLength(50).IsUnicode(true);
            //builder.Property(e => e.Water).HasMaxLength(50).IsUnicode(true);
            //builder.Property(e => e.Rainfall).HasPrecision(22, 2);
            //builder.Property(e => e.DeedArea).HasPrecision(22, 2);
            //builder.Property(e => e.ItemType).HasMaxLength(50).IsUnicode(true);
            //builder.Property(e => e.Path).HasMaxLength(500).IsUnicode(true);
            builder.Property(e => e.Volume).HasPrecision(22, 2);
            builder.Property(e => e.VipPrice).HasPrecision(22, 2);
            builder.Property(e => e.ActualVolume).HasPrecision(22, 2);
            builder.Property(e => e.ActualVipPrice).HasPrecision(22, 2);
            builder.Property(e => e.Remark).HasMaxLength(2000).IsUnicode(true);
        }
    }
}
