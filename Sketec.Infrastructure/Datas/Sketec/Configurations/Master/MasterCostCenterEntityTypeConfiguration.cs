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
    public class MasterCostCenterEntityTypeConfiguration : IEntityTypeConfiguration<MasterCostCenter>
    {
        public void Configure(EntityTypeBuilder<MasterCostCenter> builder)
        {
            builder.ConfigEntityBaseType();

            builder.Property(e => e.ContractType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasConversion(type => type.GetStringValue(), str => EnumStringValueExtension.GetEnumFromStringValue<ContractType>(str, "Rental"));

            builder.Property(e => e.Zone)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(e => e.Plant)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(e => e.CostCenter)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.HasData(
                new MasterCostCenter { Id = 1, ContractType = ContractType.Rental, Zone = "West", Plant = "7611", CostCenter = "0760-99999", IsActive = true, IsDelete = false },
                new MasterCostCenter { Id = 2, ContractType = ContractType.Rental, Zone = "North", Plant = "7611", CostCenter = "0760-99999", IsActive = true, IsDelete = false },
                new MasterCostCenter { Id = 3, ContractType = ContractType.Rental, Zone = "Northeast", Plant = "7612", CostCenter = "0762-99999", IsActive = true, IsDelete = false },
                new MasterCostCenter { Id = 4, ContractType = ContractType.MOU, Zone = "West", Plant = "7611", CostCenter = "0761-99999", IsActive = true, IsDelete = false },
                new MasterCostCenter { Id = 5, ContractType = ContractType.MOU, Zone = "North", Plant = "7611", CostCenter = "0761-99999", IsActive = true, IsDelete = false },
                new MasterCostCenter { Id = 6, ContractType = ContractType.MOU, Zone = "Northeast", Plant = "7612", CostCenter = "0761-99999", IsActive = true, IsDelete = false }
             );
        }
    }
}
