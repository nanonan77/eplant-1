using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sketec.Core.Domains;

namespace Sketec.Infrastructure.Datas.Configurations
{
    public class FileInfoEntityTypeConfiguration : IEntityTypeConfiguration<FileInfo>
    {
        public void Configure(EntityTypeBuilder<FileInfo> builder)
        {
            builder.ConfigEntityBaseTypeTrans();
            builder.Property(e => e.FileName).HasMaxLength(500).IsUnicode(true);
            builder.Property(e => e.ContentType).HasMaxLength(100).IsUnicode(false);
            builder.Property(e => e.FileType).HasMaxLength(100).IsUnicode(false);
            builder.Property(e => e.Description).HasMaxLength(2000).IsUnicode(true);
            builder.Property(e => e.Remark).HasMaxLength(2000).IsUnicode(true);
            builder.Property(e => e.Status).HasMaxLength(100).IsUnicode(false);
            builder.Property(e => e.Path).HasMaxLength(2000).IsUnicode(false);
        }
    }
}
