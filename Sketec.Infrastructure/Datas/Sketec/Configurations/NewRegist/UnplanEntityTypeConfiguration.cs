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
    public class UnplanEntityTypeConfiguration : IEntityTypeConfiguration<Unplan>
    {
        public void Configure(EntityTypeBuilder<Unplan> builder)
        {
            builder.ConfigEntityBaseTypeTrans();
            builder.Property(e => e.UnplanNo).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.PlantationId).IsRequired();
            builder.Property(e => e.NewRegistId).IsRequired();

            builder.Property(e => e.OverAllStatus).HasMaxLength(20).IsUnicode(true);
            builder.Property(e => e.Approver1).HasMaxLength(30).IsUnicode(true);
            builder.Property(e => e.Approver2).HasMaxLength(30).IsUnicode(true);
            builder.Property(e => e.Approver3).HasMaxLength(30).IsUnicode(true);
            builder.Property(e => e.StatusApprover1).HasMaxLength(30).IsUnicode(true);
            builder.Property(e => e.StatusApprover2).HasMaxLength(30).IsUnicode(true);
            builder.Property(e => e.StatusApprover3).HasMaxLength(30).IsUnicode(true);
            builder.Property(e => e.Reason).HasMaxLength(2000).IsUnicode(true);
            builder.Property(e => e.Remark1).HasMaxLength(2000).IsUnicode(true);
            builder.Property(e => e.Remark2).HasMaxLength(2000).IsUnicode(true);
            builder.Property(e => e.Remark3).HasMaxLength(2000).IsUnicode(true);
            builder.Property(e => e.Remark3).HasPrecision(22, 2);

            builder.HasOne(e => e.NewRegist)
                .WithMany()
                .HasForeignKey(e => e.NewRegistId)
                .HasPrincipalKey(e => e.Id)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
