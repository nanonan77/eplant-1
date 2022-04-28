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
    public class ExpenseActivityEntityTypeConfiguration : IEntityTypeConfiguration<ExpenseActivity>
    {
        public void Configure(EntityTypeBuilder<ExpenseActivity> builder)
        {
            builder.ConfigEntityBaseTypeTrans();

            builder.Property(e => e.ExpenseId).IsRequired();
            builder.Property(e => e.Year).IsRequired();
            builder.Property(e => e.Cost).HasPrecision(22, 2);
        }
    }
}
