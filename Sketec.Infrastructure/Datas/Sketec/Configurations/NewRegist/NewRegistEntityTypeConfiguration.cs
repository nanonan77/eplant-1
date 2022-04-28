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
    public class NewRegistEntityTypeConfiguration : IEntityTypeConfiguration<NewRegist>
    {
        public void Configure(EntityTypeBuilder<NewRegist> builder)
        {
            builder.ConfigEntityBaseTypeTrans();
            builder.Property(e => e.Title).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.RegistId).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.Status).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.OwnerName).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.OwnerLastname).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.OwnerTel).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.Province).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.District).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.SubDistrict).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.Village).HasMaxLength(50).IsUnicode(true);

            builder.Property(e => e.Plot).HasPrecision(22, 2);
            builder.Property(e => e.Rai).HasPrecision(22, 2);
            builder.Property(e => e.Ngan).HasPrecision(22, 2);
            builder.Property(e => e.Meter).HasPrecision(22, 2);
            builder.Property(e => e.Latitude).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.Longitude).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.Clearing1).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.Clearing1Area).HasPrecision(22, 2);
            builder.Property(e => e.Clearing2).HasMaxLength(50).IsUnicode(true);

            builder.Property(e => e.PIC).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.ItemType).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.Path).HasMaxLength(500).IsUnicode(true);
            builder.Property(e => e.Zone).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.Verifier).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.MOUType).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.HarvestingMonth2).HasPrecision(22, 2);
            builder.Property(e => e.MOUPrice).HasPrecision(22, 2);
            builder.Property(e => e.Remark).HasMaxLength(2000).IsUnicode(true);
            builder.Property(e => e.ContractType).HasMaxLength(20).IsUnicode(true);
            builder.Property(e => e.Team).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.PriceAtPlant).HasPrecision(22, 2);
            
            builder.Property(e => e.PlanVolume).HasPrecision(22, 2);
            builder.Property(e => e.TotalArea).HasPrecision(22, 2);
        }
    }
}
