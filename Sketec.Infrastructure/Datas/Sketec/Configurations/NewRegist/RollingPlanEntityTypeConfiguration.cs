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
    public class RollingPlanEntityTypeConfiguration : IEntityTypeConfiguration<RollingPlan>
    {
        public void Configure(EntityTypeBuilder<RollingPlan> builder)
        {
            builder.ConfigEntityBaseTypeTrans();
            builder.Property(e => e.Status).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.Note).HasMaxLength(2000).IsUnicode(true);
            builder.Property(e => e.Area).HasPrecision(22, 2);
            builder.Property(e => e.ActualArea).HasPrecision(22, 2);
            builder.Property(e => e.SubPlantationNo).HasMaxLength(1000).IsUnicode(false);

        }
    }
}
