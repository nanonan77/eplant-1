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
    public class PlantationEntityTypeConfiguration : IEntityTypeConfiguration<Plantation>
    {
        public void Configure(EntityTypeBuilder<Plantation> builder)
        {
            builder.ConfigEntityBaseTypeTrans();
            builder.Property(e => e.Title).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.NewRegistId).IsRequired();
            builder.Property(e => e.PlantationNo).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.Status).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.ContractMonth).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.ContractId).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.Province).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.District).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.SubDistrict).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.Village).HasMaxLength(50).IsUnicode(true);
            

           
            builder.Property(e => e.RentalArea).HasPrecision(22, 2);
            builder.Property(e => e.ProductiveArea).HasPrecision(22, 2);
            builder.Property(e => e.PotentialArea).HasPrecision(22, 2);
        
            builder.Property(e => e.Latitude).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.Longitude).HasMaxLength(50).IsUnicode(true);

            builder.Property(e => e.PIC).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.Zone).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.MOUType).HasMaxLength(50).IsUnicode(true);
            
            builder.Property(e => e.Remark).HasMaxLength(2000).IsUnicode(true);
            builder.Property(e => e.ContractType).HasMaxLength(20).IsUnicode(true);
        }
    }
}
