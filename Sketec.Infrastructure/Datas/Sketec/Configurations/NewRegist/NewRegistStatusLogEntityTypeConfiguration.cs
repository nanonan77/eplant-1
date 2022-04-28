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
    public class NewRegistStatusLogEntityTypeConfiguration : IEntityTypeConfiguration<NewRegistStatusLog>
    {
        public void Configure(EntityTypeBuilder<NewRegistStatusLog> builder)
        {
            builder.ConfigEntityBaseTypeTrans();
            builder.Property(e => e.AssignTo).HasMaxLength(100).IsUnicode(false);
            builder.Property(e => e.CCTo).HasMaxLength(1000).IsUnicode(false);
            builder.Property(e => e.Action).HasMaxLength(100).IsUnicode(false);
            builder.Property(e => e.Status).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.Comment).HasMaxLength(2000).IsUnicode(true);
        }
    }
}
