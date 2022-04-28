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
    public class FeasibilityYieldEntityTypeConfiguration : IEntityTypeConfiguration<FeasibilityYield>
    {
        public void Configure(EntityTypeBuilder<FeasibilityYield> builder)
        {
            builder.ConfigEntityBaseType();

            builder.Property(e => e.SoilType)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.Yield).HasPrecision(22, 2);


            builder.HasData(
                new FeasibilityYield { Id = 1, SoilType = "4", RainfallStart = null, RainfallEnd = 1000, Yield = 12.8M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 2, SoilType = "4", RainfallStart = 1000, RainfallEnd = 1200, Yield = 14.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 3, SoilType = "4", RainfallStart = 1200, RainfallEnd = 1400, Yield = 14.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 4, SoilType = "4", RainfallStart = 1400, RainfallEnd = null, Yield = 15.7M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 5, SoilType = "5", RainfallStart = null, RainfallEnd = 1000, Yield = 12.8M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 6, SoilType = "5", RainfallStart = 1000, RainfallEnd = 1200, Yield = 14.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 7, SoilType = "5", RainfallStart = 1200, RainfallEnd = 1400, Yield = 14.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 8, SoilType = "5", RainfallStart = 1400, RainfallEnd = null, Yield = 15.7M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 9, SoilType = "6", RainfallStart = null, RainfallEnd = 1000, Yield = 12.8M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 10, SoilType = "6", RainfallStart = 1000, RainfallEnd = 1200, Yield = 14.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 11, SoilType = "6", RainfallStart = 1200, RainfallEnd = 1400, Yield = 14.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 12, SoilType = "6", RainfallStart = 1400, RainfallEnd = null, Yield = 15.7M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 13, SoilType = "7", RainfallStart = null, RainfallEnd = 1000, Yield = 12.8M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 14, SoilType = "7", RainfallStart = 1000, RainfallEnd = 1200, Yield = 14.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 15, SoilType = "7", RainfallStart = 1200, RainfallEnd = 1400, Yield = 14.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 16, SoilType = "7", RainfallStart = 1400, RainfallEnd = null, Yield = 15.7M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 17, SoilType = "15", RainfallStart = null, RainfallEnd = 1000, Yield = 0, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 18, SoilType = "15", RainfallStart = 1000, RainfallEnd = 1200, Yield = 16.5M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 19, SoilType = "15", RainfallStart = 1200, RainfallEnd = 1400, Yield = 16.5M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 20, SoilType = "15", RainfallStart = 1400, RainfallEnd = null, Yield = 18, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 21, SoilType = "17", RainfallStart = null, RainfallEnd = 1000, Yield = 0, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 22, SoilType = "17", RainfallStart = 1000, RainfallEnd = 1200, Yield = 16.5M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 23, SoilType = "17", RainfallStart = 1200, RainfallEnd = 1400, Yield = 16.5M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 24, SoilType = "17", RainfallStart = 1400, RainfallEnd = null, Yield = 18, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 25, SoilType = "18", RainfallStart = null, RainfallEnd = 1000, Yield = 0, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 26, SoilType = "18", RainfallStart = 1000, RainfallEnd = 1200, Yield = 16.5M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 27, SoilType = "18", RainfallStart = 1200, RainfallEnd = 1400, Yield = 16.5M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 28, SoilType = "18", RainfallStart = 1400, RainfallEnd = null, Yield = 18, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 29, SoilType = "19", RainfallStart = null, RainfallEnd = 1000, Yield = 12.5M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 30, SoilType = "19", RainfallStart = 1000, RainfallEnd = 1200, Yield = 19.1M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 31, SoilType = "19", RainfallStart = 1200, RainfallEnd = 1400, Yield = 22.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 32, SoilType = "19", RainfallStart = 1400, RainfallEnd = null, Yield = 22.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 33, SoilType = "21", RainfallStart = null, RainfallEnd = 1000, Yield = 12.5M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 34, SoilType = "21", RainfallStart = 1000, RainfallEnd = 1200, Yield = 19.1M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 35, SoilType = "21", RainfallStart = 1200, RainfallEnd = 1400, Yield = 22.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 36, SoilType = "21", RainfallStart = 1400, RainfallEnd = null, Yield = 22.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 37, SoilType = "22", RainfallStart = null, RainfallEnd = 1000, Yield = 12.5M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 38, SoilType = "22", RainfallStart = 1000, RainfallEnd = 1200, Yield = 19.1M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 39, SoilType = "22", RainfallStart = 1200, RainfallEnd = 1400, Yield = 22.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 40, SoilType = "22", RainfallStart = 1400, RainfallEnd = null, Yield = 22.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 41, SoilType = "25", RainfallStart = null, RainfallEnd = 1000, Yield = 0, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 42, SoilType = "25", RainfallStart = 1000, RainfallEnd = 1200, Yield = 13.8M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 43, SoilType = "25", RainfallStart = 1200, RainfallEnd = 1400, Yield = 18.2M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 44, SoilType = "25", RainfallStart = 1400, RainfallEnd = null, Yield = 18.2M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 45, SoilType = "28", RainfallStart = null, RainfallEnd = 1000, Yield = 12.8M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 46, SoilType = "28", RainfallStart = 1000, RainfallEnd = 1200, Yield = 14.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 47, SoilType = "28", RainfallStart = 1200, RainfallEnd = 1400, Yield = 14.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 48, SoilType = "28", RainfallStart = 1400, RainfallEnd = null, Yield = 15.7M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 49, SoilType = "29", RainfallStart = null, RainfallEnd = 1000, Yield = 12.8M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 50, SoilType = "29", RainfallStart = 1000, RainfallEnd = 1200, Yield = 14.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 51, SoilType = "29", RainfallStart = 1200, RainfallEnd = 1400, Yield = 14.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 52, SoilType = "29", RainfallStart = 1400, RainfallEnd = null, Yield = 15.7M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 53, SoilType = "30", RainfallStart = null, RainfallEnd = 1000, Yield = 12.8M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 54, SoilType = "30", RainfallStart = 1000, RainfallEnd = 1200, Yield = 14.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 55, SoilType = "30", RainfallStart = 1200, RainfallEnd = 1400, Yield = 14.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 56, SoilType = "30", RainfallStart = 1400, RainfallEnd = null, Yield = 15.7M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 57, SoilType = "31", RainfallStart = null, RainfallEnd = 1000, Yield = 12.8M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 58, SoilType = "31", RainfallStart = 1000, RainfallEnd = 1200, Yield = 14.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 59, SoilType = "31", RainfallStart = 1200, RainfallEnd = 1400, Yield = 14.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 60, SoilType = "31", RainfallStart = 1400, RainfallEnd = null, Yield = 15.7M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 61, SoilType = "35", RainfallStart = null, RainfallEnd = 1000, Yield = 15.7M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 62, SoilType = "35", RainfallStart = 1000, RainfallEnd = 1200, Yield = 19, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 63, SoilType = "35", RainfallStart = 1200, RainfallEnd = 1400, Yield = 24.2M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 64, SoilType = "35", RainfallStart = 1400, RainfallEnd = null, Yield = 24.2M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 65, SoilType = "36", RainfallStart = null, RainfallEnd = 1000, Yield = 15.7M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 66, SoilType = "36", RainfallStart = 1000, RainfallEnd = 1200, Yield = 19, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 67, SoilType = "36", RainfallStart = 1200, RainfallEnd = 1400, Yield = 24.2M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 68, SoilType = "36", RainfallStart = 1400, RainfallEnd = null, Yield = 24.2M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 69, SoilType = "37", RainfallStart = null, RainfallEnd = 1000, Yield = 11.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 70, SoilType = "37", RainfallStart = 1000, RainfallEnd = 1200, Yield = 17.4M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 71, SoilType = "37", RainfallStart = 1200, RainfallEnd = 1400, Yield = 17.5M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 72, SoilType = "37", RainfallStart = 1400, RainfallEnd = null, Yield = 19.4M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 73, SoilType = "40", RainfallStart = null, RainfallEnd = 1000, Yield = 12.5M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 74, SoilType = "40", RainfallStart = 1000, RainfallEnd = 1200, Yield = 19.1M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 75, SoilType = "40", RainfallStart = 1200, RainfallEnd = 1400, Yield = 22.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 76, SoilType = "40", RainfallStart = 1400, RainfallEnd = null, Yield = 22.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 77, SoilType = "46", RainfallStart = null, RainfallEnd = 1000, Yield = 11.2M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 78, SoilType = "46", RainfallStart = 1000, RainfallEnd = 1200, Yield = 16.2M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 79, SoilType = "46", RainfallStart = 1200, RainfallEnd = 1400, Yield = 22, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 80, SoilType = "46", RainfallStart = 1400, RainfallEnd = null, Yield = 22, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 81, SoilType = "47", RainfallStart = null, RainfallEnd = 1000, Yield = 11.2M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 82, SoilType = "47", RainfallStart = 1000, RainfallEnd = 1200, Yield = 16.2M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 83, SoilType = "47", RainfallStart = 1200, RainfallEnd = 1400, Yield = 22, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 84, SoilType = "47", RainfallStart = 1400, RainfallEnd = null, Yield = 22, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 85, SoilType = "48", RainfallStart = null, RainfallEnd = 1000, Yield = 11.2M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 86, SoilType = "48", RainfallStart = 1000, RainfallEnd = 1200, Yield = 16.2M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 87, SoilType = "48", RainfallStart = 1200, RainfallEnd = 1400, Yield = 22, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 88, SoilType = "48", RainfallStart = 1400, RainfallEnd = null, Yield = 22, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 89, SoilType = "49", RainfallStart = null, RainfallEnd = 1000, Yield = 0, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 90, SoilType = "49", RainfallStart = 1000, RainfallEnd = 1200, Yield = 13.8M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 91, SoilType = "49", RainfallStart = 1200, RainfallEnd = 1400, Yield = 18.2M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 92, SoilType = "49", RainfallStart = 1400, RainfallEnd = null, Yield = 18.2M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 93, SoilType = "52", RainfallStart = null, RainfallEnd = 1000, Yield = 0, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 94, SoilType = "52", RainfallStart = 1000, RainfallEnd = 1200, Yield = 0, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 95, SoilType = "52", RainfallStart = 1200, RainfallEnd = 1400, Yield = 0, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 96, SoilType = "52", RainfallStart = 1400, RainfallEnd = null, Yield = 0, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 97, SoilType = "54", RainfallStart = null, RainfallEnd = 1000, Yield = 0, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 98, SoilType = "54", RainfallStart = 1000, RainfallEnd = 1200, Yield = 0, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 99, SoilType = "54", RainfallStart = 1200, RainfallEnd = 1400, Yield = 0, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 100, SoilType = "54", RainfallStart = 1400, RainfallEnd = null, Yield = 0, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 101, SoilType = "55", RainfallStart = null, RainfallEnd = 1000, Yield = 11.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 102, SoilType = "55", RainfallStart = 1000, RainfallEnd = 1200, Yield = 17.4M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 103, SoilType = "55", RainfallStart = 1200, RainfallEnd = 1400, Yield = 17.5M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 104, SoilType = "55", RainfallStart = 1400, RainfallEnd = null, Yield = 19.4M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 105, SoilType = "56", RainfallStart = null, RainfallEnd = 1000, Yield = 11.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 106, SoilType = "56", RainfallStart = 1000, RainfallEnd = 1200, Yield = 17.4M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 107, SoilType = "56", RainfallStart = 1200, RainfallEnd = 1400, Yield = 17.5M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 108, SoilType = "56", RainfallStart = 1400, RainfallEnd = null, Yield = 19.4M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 109, SoilType = "60", RainfallStart = null, RainfallEnd = 1000, Yield = 12.5M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 110, SoilType = "60", RainfallStart = 1000, RainfallEnd = 1200, Yield = 19.1M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 111, SoilType = "60", RainfallStart = 1200, RainfallEnd = 1400, Yield = 22.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 112, SoilType = "60", RainfallStart = 1400, RainfallEnd = null, Yield = 22.9M, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 113, SoilType = "62", RainfallStart = null, RainfallEnd = 1000, Yield = 0, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 114, SoilType = "62", RainfallStart = 1000, RainfallEnd = 1200, Yield = 0, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 115, SoilType = "62", RainfallStart = 1200, RainfallEnd = 1400, Yield = 0, IsActive = true, IsDelete = false },
                new FeasibilityYield { Id = 116, SoilType = "62", RainfallStart = 1400, RainfallEnd = null, Yield = 0, IsActive = true, IsDelete = false }
            );
        }
    }
}
