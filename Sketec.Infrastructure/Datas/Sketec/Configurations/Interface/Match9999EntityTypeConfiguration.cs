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
    public class Match9999EntityTypeConfiguration : IEntityTypeConfiguration<Match9999>
    {
        public void Configure(EntityTypeBuilder<Match9999> builder)
        {
            builder.ConfigEntityBaseTypeTrans();

            builder.Property(e => e.TransactionNo)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(true);


        }
    }
}
