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
    public class RunningNumberEntityTypeConfiguration : IEntityTypeConfiguration<RunningNumber>
    {
        public void Configure(EntityTypeBuilder<RunningNumber> builder)
        {
            builder.ConfigEntityBaseType();

            builder.Property(e => e.Topic)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasConversion<string>();

            builder.Property(e => e.Temp1)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Temp2)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Temp3)
                .HasMaxLength(200)
                .IsUnicode(false);
        }
    }
}
