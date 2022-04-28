using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sketec.Core.Domains;

namespace Sketec.Infrastructure.Datas
{
    public static class BaseEntityTypeConfiguration
    {
        public static void ConfigEntityBaseType<T>(this EntityTypeBuilder<T> builder)
            where T : Entity
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

        }

        public static void ConfigEntityBaseTypeTrans<T>(this EntityTypeBuilder<T> builder)
            where T : EntityTransaction
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

        }
    }
}
