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
    public class MatchPlantationEntityTypeConfiguration : IEntityTypeConfiguration<MatchPlantation>
    {
        public void Configure(EntityTypeBuilder<MatchPlantation> builder)
        {
            builder.ConfigEntityBaseTypeTrans();

            builder.Property(e => e.Amount).HasPrecision(22, 2);

        }
    }
}
