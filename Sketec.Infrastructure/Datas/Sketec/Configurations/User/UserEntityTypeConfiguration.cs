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
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ConfigEntityBaseType();

            builder.HasAlternateKey(e => e.Username);

            builder.Property(e => e.Username).HasMaxLength(50).IsUnicode(false);
            builder.Property(e => e.EmpCode).HasMaxLength(50).IsUnicode(false);
            builder.Property(e => e.OrganizationName).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.AdAcount).HasMaxLength(50).IsUnicode(false);
            builder.Property(e => e.T_FullName).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.E_FullName).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.NickName).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.PositionName).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.BusinessUnit).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.CompanyCode).HasMaxLength(50).IsUnicode(true);
            builder.Property(e => e.CompanyName).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.Div_Name).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.Dep_Name).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.Sec_Name).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.Email).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.Location).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.CctR_Dept).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.CctR_Over).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.ManagerEmail).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.ReportToEmail2).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.ReportToEmail3).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.Tel).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.MobileNo).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.Team).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.Role).HasMaxLength(200).IsUnicode(true);
        }
    }
}
