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
    public class NewRegistImagePathEntityTypeConfiguration : IEntityTypeConfiguration<NewRegistImagePath>
    {
        public void Configure(EntityTypeBuilder<NewRegistImagePath> builder)
        {
            builder.ConfigEntityBaseTypeTrans();
            builder.Property(e => e.Name).HasMaxLength(30).IsUnicode(true);
            builder.Property(e => e.SurveyId).HasMaxLength(30).IsUnicode(true);
            builder.Property(e => e.PlantationId).HasMaxLength(30).IsUnicode(true);
            builder.Property(e => e.ImageInfo).HasMaxLength(2000).IsUnicode(true);
            builder.Property(e => e.ImageInfo2).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.ImageInfo3).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.ItemType).HasMaxLength(30).IsUnicode(true);

            builder.Property(e => e.Path).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.ImageLevel)
                .HasMaxLength(30)
                .IsUnicode(true)
                .HasConversion(type => type.GetStringValue(), str => EnumStringValueExtension.GetEnumFromStringValue<NewRegistLevel>(str, "NewRegist")); ;
        }
    }
}
