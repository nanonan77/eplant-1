using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sketec.Infrastructure.Datas.WebCreditStaging.Configurations
{
    //public class ArOutstandingWebCreditLimitEntityTypeConfiguration : IEntityTypeConfiguration<ArOutstandingWebCreditLimit>
    //{
    //    public void Configure(EntityTypeBuilder<ArOutstandingWebCreditLimit> entity)
    //    {
    //        entity.HasNoKey();

    //        entity.ToTable("ar_outstanding_web_credit_limit");

    //        entity.Property(e => e.Amount)
    //            .HasColumnType("decimal(38, 2)")
    //            .HasColumnName("amount");

    //        entity.Property(e => e.Cca)
    //            .IsRequired()
    //            .HasMaxLength(21)
    //            .IsUnicode(false)
    //            .HasColumnName("CCA");

    //        entity.Property(e => e.CompanyCode)
    //            .HasMaxLength(4)
    //            .IsUnicode(false)
    //            .HasColumnName("Company_Code");

    //        entity.Property(e => e.Customer)
    //            .HasMaxLength(10)
    //            .IsUnicode(false);

    //        entity.Property(e => e.Expr1).HasColumnType("decimal(38, 2)");

    //        entity.Property(e => e.Name)
    //            .HasMaxLength(80)
    //            .IsUnicode(false);

    //        entity.Property(e => e.NextDueDate)
    //            .HasColumnType("date")
    //            .HasColumnName("next_due_date");

    //        entity.Property(e => e.NotDueYet)
    //            .HasColumnType("decimal(38, 2)")
    //            .HasColumnName("not_due_yet");

    //        entity.Property(e => e.Over15)
    //            .HasColumnType("decimal(38, 2)")
    //            .HasColumnName("Over_15");

    //        entity.Property(e => e.Over30)
    //            .HasColumnType("decimal(38, 2)")
    //            .HasColumnName("Over_30");

    //        entity.Property(e => e.Over60)
    //            .HasColumnType("decimal(38, 2)")
    //            .HasColumnName("Over_60");

    //        entity.Property(e => e.Over90)
    //            .HasColumnType("decimal(38, 2)")
    //            .HasColumnName("Over_90");

    //        entity.Property(e => e.OverMore90)
    //            .HasColumnType("decimal(38, 2)")
    //            .HasColumnName("Over_more_90");

    //        entity.Property(e => e.Overdue).HasColumnType("decimal(38, 2)");
    //    }
    //}
}
