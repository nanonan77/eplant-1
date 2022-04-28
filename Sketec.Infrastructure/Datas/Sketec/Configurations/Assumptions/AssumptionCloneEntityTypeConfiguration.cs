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
    public class AssumptionCloneEntityTypeConfiguration : IEntityTypeConfiguration<AssumptionClone>
    {
        public void Configure(EntityTypeBuilder<AssumptionClone> builder)
        {
            builder.ConfigEntityBaseTypeTrans();

            builder.Property(e => e.AssumptionId).IsRequired();
            builder.Property(e => e.Clone).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.Portion).HasPrecision(22, 2);
            builder.Property(e => e.Area).HasPrecision(22, 2);
            builder.Property(e => e.ProductTon).HasPrecision(22, 2);
        }
    }
}
