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
    public class MasterTransportationDetailEntityTypeConfiguration : IEntityTypeConfiguration<MasterTransportationDetail>
    {
        public void Configure(EntityTypeBuilder<MasterTransportationDetail> builder)
        {
            builder.ConfigEntityBaseType();
            builder.Property(e => e.UnitPrice).HasPrecision(22, 2);

            builder.HasData(
                new MasterTransportationDetail { MasterTransportationHeaderId = 1, Id = 1, Title = 50, UnitPrice = Convert.ToDecimal(2.2), IsActive = true, IsDelete = false},
                new MasterTransportationDetail { MasterTransportationHeaderId = 1, Id = 2, Title = 100, UnitPrice = Convert.ToDecimal(1.65), IsActive = true, IsDelete = false },
                new MasterTransportationDetail { MasterTransportationHeaderId = 1, Id = 3, Title = 150, UnitPrice = Convert.ToDecimal(1.47), IsActive = true, IsDelete = false },
                new MasterTransportationDetail { MasterTransportationHeaderId = 1, Id = 4, Title = 200, UnitPrice = Convert.ToDecimal(1.38), IsActive = true, IsDelete = false },
                new MasterTransportationDetail { MasterTransportationHeaderId = 1, Id = 5, Title = 250, UnitPrice = Convert.ToDecimal(1.3), IsActive = true, IsDelete = false },
                new MasterTransportationDetail { MasterTransportationHeaderId = 1, Id = 6, Title = 300, UnitPrice = Convert.ToDecimal(1.22), IsActive = true, IsDelete = false },
                new MasterTransportationDetail { MasterTransportationHeaderId = 1, Id = 7, Title = 350, UnitPrice = Convert.ToDecimal(1.16), IsActive = true, IsDelete = false },
                new MasterTransportationDetail { MasterTransportationHeaderId = 1, Id = 8, Title = 400, UnitPrice = Convert.ToDecimal(1.11), IsActive = true, IsDelete = false },
                new MasterTransportationDetail { MasterTransportationHeaderId = 1, Id = 9, Title = 450, UnitPrice = Convert.ToDecimal(1.07), IsActive = true, IsDelete = false },
                new MasterTransportationDetail { MasterTransportationHeaderId = 1, Id = 10, Title = 500, UnitPrice = Convert.ToDecimal(1.02), IsActive = true, IsDelete = false },
                new MasterTransportationDetail { MasterTransportationHeaderId = 1, Id = 11, Title = 550, UnitPrice = Convert.ToDecimal(0.98), IsActive = true, IsDelete = false },
                new MasterTransportationDetail { MasterTransportationHeaderId = 1, Id = 12, Title = 600, UnitPrice = Convert.ToDecimal(0.95), IsActive = true, IsDelete = false }
            );

        }
    }
}
