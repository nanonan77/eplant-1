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
    public class ExpenseEntityTypeConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ConfigEntityBaseTypeTrans();

            builder.Property(e => e.AssumptionId).IsRequired();
            builder.Property(e => e.ActivityId).IsRequired(false);
            builder.Property(e => e.BahtPerRai).HasPrecision(22, 2);
            builder.Property(e => e.YearCost1).HasPrecision(22, 2);
            builder.Property(e => e.YearCost2).HasPrecision(22, 2);
            builder.Property(e => e.YearCost3).HasPrecision(22, 2);
            builder.Property(e => e.YearCost4).HasPrecision(22, 2);
            builder.Property(e => e.YearCost5).HasPrecision(22, 2);
            builder.Property(e => e.YearCost6).HasPrecision(22, 2);
            builder.Property(e => e.YearCost7).HasPrecision(22, 2);
            builder.Property(e => e.YearCost8).HasPrecision(22, 2);
            builder.Property(e => e.YearCost9).HasPrecision(22, 2);
            builder.Property(e => e.YearCost10).HasPrecision(22, 2);
            builder.Property(e => e.YearCost11).HasPrecision(22, 2);
            builder.Property(e => e.YearCost12).HasPrecision(22, 2);
            builder.Property(e => e.YearCost13).HasPrecision(22, 2);
            builder.Property(e => e.YearCost14).HasPrecision(22, 2);
            builder.Property(e => e.YearCost15).HasPrecision(22, 2);
            builder.Property(e => e.ExpenseType)
                .HasMaxLength(30)
                .IsUnicode(true)
                .HasConversion(type => type.GetStringValue(), str => EnumStringValueExtension.GetEnumFromStringValue<ExpenseType>(str, "ActivityGroupA"));




            builder.HasOne(e => e.MasterActivity)
                    .WithMany()
                    .HasForeignKey(e => e.ActivityId)
                    .HasPrincipalKey(e => e.Id)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
