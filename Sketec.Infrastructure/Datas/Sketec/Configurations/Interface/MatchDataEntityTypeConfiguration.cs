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
    public class MatchDataEntityTypeConfiguration : IEntityTypeConfiguration<MatchData>
    {
        public void Configure(EntityTypeBuilder<MatchData> builder)
        {
            builder.ConfigEntityBaseTypeTrans();

            builder.Property(e => e.ValCOAreaCrcy).HasPrecision(22, 2);

        }
    }
}
