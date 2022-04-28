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
    public class FeasibilityPriceEntityTypeConfiguration : IEntityTypeConfiguration<FeasibilityPrice>
    {
        public void Configure(EntityTypeBuilder<FeasibilityPrice> builder)
        {
            builder.ConfigEntityBaseType();

            builder.Property(e => e.Mill)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.PriceType)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Price).HasPrecision(22, 2);


            builder.HasData(
                new FeasibilityPrice { Id = 1, Mill = "โรงงานวังศาลา", PriceType = "FC Target", Price = 1220, IsActive = true, IsDelete = false },
                new FeasibilityPrice { Id = 2, Mill = "โรงสับกำแพงเพชร", PriceType = "FC Target", Price = 1070, IsActive = true, IsDelete = false },
                new FeasibilityPrice { Id = 3, Mill = "โรงสับชุมพวง", PriceType = "FC Target", Price = 1070, IsActive = true, IsDelete = false },
                new FeasibilityPrice { Id = 4, Mill = "โรงงานน้ำพอง", PriceType = "FC Target", Price = 1101, IsActive = true, IsDelete = false },
                new FeasibilityPrice { Id = 5, Mill = "โรงสับพระยืน", PriceType = "FC Target", Price = 1061, IsActive = true, IsDelete = false },
                new FeasibilityPrice { Id = 6, Mill = "โรงงานวังศาลา", PriceType = "MTP Agent", Price = 1500, IsActive = true, IsDelete = false },
                new FeasibilityPrice { Id = 7, Mill = "โรงสับกำแพงเพชร", PriceType = "MTP Agent", Price = 1245, IsActive = true, IsDelete = false },
                new FeasibilityPrice { Id = 8, Mill = "โรงสับชุมพวง", PriceType = "MTP Agent", Price = 1261, IsActive = true, IsDelete = false },
                new FeasibilityPrice { Id = 9, Mill = "โรงงานน้ำพอง", PriceType = "MTP Agent", Price = 1405, IsActive = true, IsDelete = false },
                new FeasibilityPrice { Id = 10, Mill = "โรงสับพระยืน", PriceType = "MTP Agent", Price = 1264, IsActive = true, IsDelete = false },
                new FeasibilityPrice { Id = 11, Mill = "โรงงานวังศาลา", PriceType = "Current", Price = 1326, IsActive = true, IsDelete = false },
                new FeasibilityPrice { Id = 12, Mill = "โรงสับกำแพงเพชร", PriceType = "Current", Price = 1184, IsActive = true, IsDelete = false },
                new FeasibilityPrice { Id = 13, Mill = "โรงสับชุมพวง", PriceType = "Current", Price = 1146, IsActive = true, IsDelete = false },
                new FeasibilityPrice { Id = 14, Mill = "โรงงานน้ำพอง", PriceType = "Current", Price = 1202, IsActive = true, IsDelete = false },
                new FeasibilityPrice { Id = 15, Mill = "โรงสับพระยืน", PriceType = "Current", Price = 1132, IsActive = true, IsDelete = false },
                new FeasibilityPrice { Id = 16, Mill = "โรงสับพันธมิตร (บริษัท ที.แอล.เอส.ยูคาลิปตัส 2005 จำกัด)", PriceType = "MTP Agent", Price = 1397, IsActive = true, IsDelete = false }
            );
        }
    }
}
