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
    public class AssumptionYieldEntityTypeConfiguration : IEntityTypeConfiguration<AssumptionYield>
    {
        public void Configure(EntityTypeBuilder<AssumptionYield> builder)
        {
            builder.ConfigEntityBaseTypeTrans();

            builder.Property(e => e.AssumptionId).IsRequired();
            builder.Property(e => e.Round).IsRequired();
            builder.Property(e => e.Yield).HasPrecision(22, 2);
        }
    }
}
