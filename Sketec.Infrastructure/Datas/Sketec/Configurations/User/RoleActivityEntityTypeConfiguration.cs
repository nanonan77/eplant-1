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
    public class RoleActivityEntityTypeConfiguration : IEntityTypeConfiguration<RoleActivity>
    {
        public void Configure(EntityTypeBuilder<RoleActivity> builder)
        {
            builder.ConfigEntityBaseType();

            builder.Property(e => e.Role).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.Page).HasMaxLength(200).IsUnicode(true);
            builder.Property(e => e.Activity).HasMaxLength(200).IsUnicode(true);

            builder.HasData(
                new RoleActivity { Id = 1, Role = "O1", Page = "General", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 2, Role = "O1", Page = "Report", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 3, Role = "O1", Page = "Dashboard", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 4, Role = "O1", Page = "Management", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 5, Role = "O1", Page = "New Registration", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 6, Role = "O1", Page = "Status Tracking", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 7, Role = "O1", Page = "Power App", Activity = "All", IsActive = true, IsDelete = false },

                new RoleActivity { Id = 8, Role = "O2", Page = "General", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 9, Role = "O2", Page = "Report", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 10, Role = "O2", Page = "Dashboard", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 11, Role = "O2", Page = "Management", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 12, Role = "O2", Page = "New Registration", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 13, Role = "O2", Page = "Status Tracking", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 14, Role = "O2", Page = "Power App", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 15, Role = "O2", Page = "Plantation", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 16, Role = "O2", Page = "Create Plantation", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 17, Role = "O2", Page = "Create Unplan", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 18, Role = "O2", Page = "Rolling Plan", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 19, Role = "O2", Page = "Calendar", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 20, Role = "O2", Page = "Interface", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 21, Role = "O2", Page = "Create PO", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 22, Role = "O2", Page = "Create Non-PO", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 23, Role = "O2", Page = "SAP-GI", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 24, Role = "O2", Page = "Payment", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 25, Role = "O2", Page = "Mapping 99999", Activity = "All", IsActive = true, IsDelete = false },

                new RoleActivity { Id = 26, Role = "S", Page = "General", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 27, Role = "S", Page = "Report", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 28, Role = "S", Page = "Dashboard", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 29, Role = "S", Page = "Management", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 30, Role = "S", Page = "New Registration", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 31, Role = "S", Page = "Status Tracking", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 32, Role = "S", Page = "Power App", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 33, Role = "S", Page = "Plantation", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 34, Role = "S", Page = "Create Plantation", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 35, Role = "S", Page = "Create Unplan", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 36, Role = "S", Page = "Rolling Plan", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 37, Role = "S", Page = "Calendar", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 38, Role = "S", Page = "Interface", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 39, Role = "S", Page = "Create PO", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 40, Role = "S", Page = "Create Non-PO", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 41, Role = "S", Page = "SAP-GI", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 42, Role = "S", Page = "Payment", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 43, Role = "S", Page = "Mapping 99999", Activity = "All", IsActive = true, IsDelete = false },

                new RoleActivity { Id = 44, Role = "SS", Page = "General", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 45, Role = "SS", Page = "Report", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 46, Role = "SS", Page = "Dashboard", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 47, Role = "SS", Page = "Management", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 48, Role = "SS", Page = "New Registration", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 49, Role = "SS", Page = "Status Tracking", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 50, Role = "SS", Page = "Power App", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 51, Role = "SS", Page = "Plantation", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 52, Role = "SS", Page = "Create Plantation", Activity = "View", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 53, Role = "SS", Page = "Create Unplan", Activity = "View", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 54, Role = "SS", Page = "Rolling Plan", Activity = "View", IsActive = true, IsDelete = false },

                new RoleActivity { Id = 55, Role = "M", Page = "General", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 56, Role = "M", Page = "Report", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 57, Role = "M", Page = "Dashboard", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 58, Role = "M", Page = "Management", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 59, Role = "M", Page = "New Registration", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 60, Role = "M", Page = "Status Tracking", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 61, Role = "M", Page = "Power App", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 62, Role = "M", Page = "Plantation", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 63, Role = "M", Page = "Create Plantation", Activity = "View", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 64, Role = "M", Page = "Create Unplan", Activity = "View", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 65, Role = "M", Page = "Rolling Plan", Activity = "View", IsActive = true, IsDelete = false },

                new RoleActivity { Id = 66, Role = "D", Page = "Management", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 67, Role = "D", Page = "New Registration", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 68, Role = "D", Page = "Status Tracking", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 69, Role = "D", Page = "Power App", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 70, Role = "D", Page = "Plantation", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 71, Role = "D", Page = "Create Plantation", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 72, Role = "D", Page = "Create Unplan", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 73, Role = "D", Page = "Rolling Plan", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 74, Role = "D", Page = "Calendar", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 75, Role = "D", Page = "Interface", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 76, Role = "D", Page = "Create PO", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 77, Role = "D", Page = "Create Non-PO", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 78, Role = "D", Page = "SAP-GI", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 79, Role = "D", Page = "Payment", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 80, Role = "D", Page = "Mapping 99999", Activity = "All", IsActive = true, IsDelete = false },

                new RoleActivity { Id = 81, Role = "A", Page = "General", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 82, Role = "A", Page = "Report", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 83, Role = "A", Page = "Dashboard", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 84, Role = "A", Page = "Management", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 85, Role = "A", Page = "New Registration", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 86, Role = "A", Page = "Status Tracking", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 87, Role = "A", Page = "Power App", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 88, Role = "A", Page = "Plantation", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 89, Role = "A", Page = "Create Plantation", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 90, Role = "A", Page = "Create Unplan", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 91, Role = "A", Page = "Rolling Plan", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 92, Role = "A", Page = "Calendar", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 93, Role = "A", Page = "Interface", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 94, Role = "A", Page = "Create PO", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 95, Role = "A", Page = "Create Non-PO", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 96, Role = "A", Page = "SAP-GI", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 97, Role = "A", Page = "Payment", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 98, Role = "A", Page = "Mapping 99999", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 99, Role = "A", Page = "Master", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 100, Role = "A", Page = "Activity", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 101, Role = "A", Page = "Clone", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 102, Role = "A", Page = "Transportation", Activity = "All", IsActive = true, IsDelete = false },
                new RoleActivity { Id = 103, Role = "A", Page = "User", Activity = "All", IsActive = true, IsDelete = false }
            );

        }
    }
}
