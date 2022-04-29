using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Infrastructure.Datas.Configurations
{
    public class MasterRunningNumberEntityTypeConfiguration : IEntityTypeConfiguration<MasterRunningNumber>
    {
        public void Configure(EntityTypeBuilder<MasterRunningNumber> builder)
        {
            builder.ConfigEntityBaseType();

            builder.Property(e => e.Topic)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Template)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.HasData(
                new MasterRunningNumber { Id = 1, Topic = "PlantationRental", Template = "PREN{year}{temp1}{running}", Digit = 2, IsActive = true, IsDelete = false },
                new MasterRunningNumber { Id = 2, Topic = "PlantationMOU", Template = "PMOU{year}{temp1}{running}", Digit = 2, IsActive = true, IsDelete = false },
                new MasterRunningNumber { Id = 3, Topic = "PlantationVIP", Template = "PVIP{year}{temp1}{running}", Digit = 2, IsActive = true, IsDelete = false },
                new MasterRunningNumber { Id = 4, Topic = "SubPlantation", Template = "{temp1}-{running}", Digit = 2, IsActive = true, IsDelete = false },
                new MasterRunningNumber { Id = 5, Topic = "Unplan", Template = "UN{year}-{running}", Digit = 5, IsActive = true, IsDelete = false }
             );
        }
    }
}
