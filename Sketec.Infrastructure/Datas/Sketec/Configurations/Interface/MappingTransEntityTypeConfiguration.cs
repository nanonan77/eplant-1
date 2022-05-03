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
    public class MappingTransEntityTypeConfiguration : IEntityTypeConfiguration<MappingTrans>
    {
        public void Configure(EntityTypeBuilder<MappingTrans> builder)
        {
            builder.ConfigEntityBaseTypeTrans();

            builder.Property(e => e.TransactionNo)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(e => e.Comment)
                .HasMaxLength(500)
                .IsUnicode(true);


        }
    }
}
