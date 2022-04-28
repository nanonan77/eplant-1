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
    public class MasterActivityTypeEntityTypeConfiguration : IEntityTypeConfiguration<MasterActivityType>
    {
        public void Configure(EntityTypeBuilder<MasterActivityType> builder)
        {
            builder.ConfigEntityBaseType();

            builder.Property(e => e.TitleEN)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.TitleTH)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.ActivityGroup)
                .HasMaxLength(10)
                .IsUnicode(true);


            builder.HasData(
               new MasterActivityType
               {
                   Id = 1,
                   TitleEN = "Rental",
                   TitleTH = "ค่าเช่าที่ดิน",
                   ActivityGroup = "A",
                   IsActive = true,
                   IsDelete = false,
                   Seq = 1
               }, new MasterActivityType
               {
                   Id = 2,
                   TitleEN = "Site Preparation",
                   TitleTH = "การเตรียมพื้นที่ปลูก",
                   ActivityGroup = "B",
                   IsActive = true,
                   IsDelete = false,
                   Seq = 2
               }, new MasterActivityType
               {
                   Id = 3,
                   TitleEN = "Planting",
                   TitleTH = "การปลูก",
                   ActivityGroup = "C",
                   IsActive = true,
                   IsDelete = false,
                   Seq = 3
               }, new MasterActivityType
               {
                   Id = 4,
                   TitleEN = "Maintenance",
                   TitleTH = "การดูแล",
                   ActivityGroup = "D",
                   IsActive = true,
                   IsDelete = false,
                   Seq = 4
               }, new MasterActivityType
               {
                   Id = 5,
                   TitleEN = "Harvesting",
                   TitleTH = "ค่าตัด",
                   ActivityGroup = "E",
                   IsActive = true,
                   IsDelete = false,
                   Seq = 5
               }, new MasterActivityType
               {
                   Id = 6,
                   TitleEN = "Others",
                   TitleTH = "ค่าบริหารการจัดการ",
                   ActivityGroup = "F",
                   IsActive = true,
                   IsDelete = false,
                   Seq = 6
               }, new MasterActivityType
               {
                   Id = 7,
                   TitleEN = "Est. Cost (Income)",
                   TitleTH = "รายได้",
                   ActivityGroup = "G",
                   IsActive = true,
                   IsDelete = false,
                   Seq = 7
               }, new MasterActivityType
               {
                   Id = 8,
                   TitleEN = "Transportation",
                   TitleTH = "ค่าขนส่ง",
                   ActivityGroup = "H",
                   IsActive = true,
                   IsDelete = false,
                   Seq = 8
               }
           );
        }
    }
}
