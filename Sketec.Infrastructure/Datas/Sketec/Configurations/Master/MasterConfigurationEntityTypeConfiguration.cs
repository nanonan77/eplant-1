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
    public class MasterConfigurationEntityTypeConfiguration : IEntityTypeConfiguration<MasterConfiguration>
    {
        public void Configure(EntityTypeBuilder<MasterConfiguration> builder)
        {
            builder.ConfigEntityBaseType();

            builder.Property(e => e.ConfigurationKey)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.Value)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Remarks)
                .HasMaxLength(200)
                .IsUnicode(true);



            builder.HasData(new MasterConfiguration
                {
                    Id = 1,
                    ConfigurationKey = "Day",
                    Code = "3",
                    Value = "3",
                    Remarks = null,
                    IsActive = true,
                    IsDelete = false
                }, new MasterConfiguration
                {
                    Id = 2,
                    ConfigurationKey = "Inflation Rate",
                    Code = "1",
                    Value = "1",
                    Remarks = null,
                    IsActive = true,
                    IsDelete = false
                }, new MasterConfiguration
                {
                    Id = 3,
                    ConfigurationKey = "Incremental Tax Rate1",
                    Code = "20",
                    Value = "20",
                    Remarks = null,
                    IsActive = true,
                    IsDelete = false
                }, new MasterConfiguration
                {
                    Id = 4,
                    ConfigurationKey = "Criteria 1",
                    Code = "2",
                    Value = "2",
                    Remarks = null,
                    IsActive = true,
                    IsDelete = false
                }, new MasterConfiguration
                {
                    Id = 5,
                    ConfigurationKey = "Criteria 2",
                    Code = "12",
                    Value = "12",
                    Remarks = null,
                    IsActive = true,
                    IsDelete = false
                }, new MasterConfiguration
                {
                    Id = 6,
                    ConfigurationKey = "Criteria 3",
                    Code = "2",
                    Value = "2",
                    Remarks = null,
                    IsActive = true,
                    IsDelete = false
                }, new MasterConfiguration
                {
                    Id = 7,
                    ConfigurationKey = "Contract Type",
                    Code = "Rental",
                    Value = "Rental",
                    Description = "Rental",
                    Remarks = null,
                    IsActive = true,
                    IsDelete = false
                }, new MasterConfiguration
                {
                    Id = 8,
                    ConfigurationKey = "Contract Type",
                    Code = "MOU",
                    Value = "MOU",
                    Description = "MOU",
                    Remarks = null,
                    IsActive = true,
                    IsDelete = false
                }, new MasterConfiguration
                {
                    Id = 9,
                    ConfigurationKey = "Contract Type",
                    Code = "VIP",
                    Value = "VIP",
                    Description = "VIP",
                    Remarks = null,
                    IsActive = true,
                    IsDelete = false
                }, new MasterConfiguration
                {
                    Id = 10,
                    ConfigurationKey = "Status Tracking",
                    Code = "1",
                    Value = "Submitted",
                    Description = "ทีมหาพื้นที่",
                    Remarks = null,
                    IsActive = true,
                    IsDelete = false
                }, new MasterConfiguration
                {
                    Id = 11,
                    ConfigurationKey = "Status Tracking",
                    Code = "2",
                    Value = "Verify Cost",
                    Description = "ทีมปลูก",
                    Remarks = null,
                    IsActive = true,
                    IsDelete = false
                }, new MasterConfiguration
                {
                    Id = 12,
                    ConfigurationKey = "Status Tracking",
                    Code = "3",
                    Value = "Verify Feas.",
                    Description = "ทีม QC",
                    Remarks = null,
                    IsActive = true,
                    IsDelete = false
                }, new MasterConfiguration
                {
                    Id = 13,
                    ConfigurationKey = "Status Tracking",
                    Code = "4",
                    Value = "Final Negotiate",
                    Description = "ทีมหาพื้นที่",
                    Remarks = null,
                    IsActive = true,
                    IsDelete = false
                }, new MasterConfiguration
                {
                    Id = 14,
                    ConfigurationKey = "Status Tracking",
                    Code = "5",
                    Value = "Contract Signed",
                    Description = "ทีมปลูก",
                    Remarks = null,
                    IsActive = true,
                    IsDelete = false
                }, new MasterConfiguration
                {
                    Id = 15,
                    ConfigurationKey = "Status Tracking",
                    Code = "6",
                    Value = "Completed",
                    Description = "Completed",
                    Remarks = null,
                    IsActive = true,
                    IsDelete = false
                },
                new MasterConfiguration { Id = 16, ConfigurationKey = "SoilType", Code = "4", Value = "4", Description = "4", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 17, ConfigurationKey = "SoilType", Code = "5", Value = "5", Description = "5", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 18, ConfigurationKey = "SoilType", Code = "6", Value = "6", Description = "6", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 19, ConfigurationKey = "SoilType", Code = "7", Value = "7", Description = "7", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 20, ConfigurationKey = "SoilType", Code = "15", Value = "15", Description = "15", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 21, ConfigurationKey = "SoilType", Code = "17", Value = "17", Description = "17", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 22, ConfigurationKey = "SoilType", Code = "18", Value = "18", Description = "18", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 23, ConfigurationKey = "SoilType", Code = "19", Value = "19", Description = "19", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 24, ConfigurationKey = "SoilType", Code = "21", Value = "21", Description = "21", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 25, ConfigurationKey = "SoilType", Code = "22", Value = "22", Description = "22", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 26, ConfigurationKey = "SoilType", Code = "25", Value = "25", Description = "25", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 27, ConfigurationKey = "SoilType", Code = "28", Value = "28", Description = "28", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 28, ConfigurationKey = "SoilType", Code = "29", Value = "29", Description = "29", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 29, ConfigurationKey = "SoilType", Code = "30", Value = "30", Description = "30", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 30, ConfigurationKey = "SoilType", Code = "31", Value = "31", Description = "31", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 31, ConfigurationKey = "SoilType", Code = "35", Value = "35", Description = "35", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 32, ConfigurationKey = "SoilType", Code = "36", Value = "36", Description = "36", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 33, ConfigurationKey = "SoilType", Code = "37", Value = "37", Description = "37", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 34, ConfigurationKey = "SoilType", Code = "40", Value = "40", Description = "40", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 35, ConfigurationKey = "SoilType", Code = "46", Value = "46", Description = "46", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 36, ConfigurationKey = "SoilType", Code = "47", Value = "47", Description = "47", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 37, ConfigurationKey = "SoilType", Code = "48", Value = "48", Description = "48", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 38, ConfigurationKey = "SoilType", Code = "49", Value = "49", Description = "49", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 39, ConfigurationKey = "SoilType", Code = "52", Value = "52", Description = "52", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 40, ConfigurationKey = "SoilType", Code = "54", Value = "54", Description = "54", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 41, ConfigurationKey = "SoilType", Code = "55", Value = "55", Description = "55", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 42, ConfigurationKey = "SoilType", Code = "56", Value = "56", Description = "56", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 43, ConfigurationKey = "SoilType", Code = "60", Value = "60", Description = "60", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 44, ConfigurationKey = "SoilType", Code = "62", Value = "62", Description = "62", Remarks = null, IsActive = true, IsDelete = false },


                new MasterConfiguration { Id = 45, ConfigurationKey = "Accessibility", Code = "1", Value = "มี - รถบรรทุกไม้เข้าถึง", Description = "มี - รถบรรทุกไม้เข้าถึง", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 46, ConfigurationKey = "Accessibility", Code = "2", Value = "มี - รถบรรทุกเข้าถึงไม่ได้", Description = "มี - รถบรรทุกเข้าถึงไม่ได้", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 47, ConfigurationKey = "Accessibility", Code = "3", Value = "แปลงตาบอด", Description = "แปลงตาบอด", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 48, ConfigurationKey = "Depth", Code = "1", Value = "< 30 cm.", Description = "< 30 cm.", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 49, ConfigurationKey = "Depth", Code = "2", Value = "30-50 cm.", Description = "30-50 cm.", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 50, ConfigurationKey = "Depth", Code = "3", Value = "50-80 cm.", Description = "50-80 cm.", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 51, ConfigurationKey = "Depth", Code = "4", Value = "80-100 cm.", Description = "80-100 cm.", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 52, ConfigurationKey = "Depth", Code = "5", Value = "> 100 cm.", Description = "> 100 cm.", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 53, ConfigurationKey = "SoillFloorDepth", Code = "1", Value = "No", Description = "No", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 54, ConfigurationKey = "SoillFloorDepth", Code = "2", Value = "< 30 cm.", Description = "< 30 cm.", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 55, ConfigurationKey = "SoillFloorDepth", Code = "3", Value = "30-50 cm.", Description = "30-50 cm.", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 56, ConfigurationKey = "SoillFloorDepth", Code = "4", Value = "50-80 cm.", Description = "50-80 cm.", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 57, ConfigurationKey = "SoillFloorDepth", Code = "5", Value = "80-100 cm.", Description = "80-100 cm.", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 58, ConfigurationKey = "GravelDepth", Code = "1", Value = "No", Description = "No", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 59, ConfigurationKey = "GravelDepth", Code = "2", Value = "< 30 cm.", Description = "< 30 cm.", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 60, ConfigurationKey = "GravelDepth", Code = "3", Value = "30-50 cm.", Description = "30-50 cm.", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 61, ConfigurationKey = "GravelDepth", Code = "4", Value = "50-80 cm.", Description = "50-80 cm.", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 62, ConfigurationKey = "GravelDepth", Code = "5", Value = "80-100 cm.", Description = "80-100 cm.", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 63, ConfigurationKey = "Water", Code = "1", Value = "Yes", Description = "Yes", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 64, ConfigurationKey = "Water", Code = "2", Value = "No", Description = "No", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 65, ConfigurationKey = "Contract", Code = "1", Value = "5", Description = "5", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 66, ConfigurationKey = "Contract", Code = "2", Value = "6", Description = "6", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 67, ConfigurationKey = "Contract", Code = "3", Value = "10", Description = "10", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 68, ConfigurationKey = "Contract", Code = "4", Value = "15", Description = "15", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 69, ConfigurationKey = "Team", Code = "1", Value = "ทีมหาพื้นที่", Description = "ทีมหาพื้นที่", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 70, ConfigurationKey = "Team", Code = "2", Value = "ทีมปลูก", Description = "ทีมปลูก", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 71, ConfigurationKey = "Team", Code = "3", Value = "ทีม QC", Description = "ทีม QC", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 72, ConfigurationKey = "Activity Rentral", Code = "1", Value = "A01", Description = "A01", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 73, ConfigurationKey = "Activity Rentral", Code = "2", Value = "A03", Description = "A03", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 74, ConfigurationKey = "Activity Rentral", Code = "3", Value = "B01", Description = "B01", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 75, ConfigurationKey = "Activity Rentral", Code = "4", Value = "B03", Description = "B03", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 76, ConfigurationKey = "Activity Rentral", Code = "5", Value = "B04", Description = "B04", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 77, ConfigurationKey = "Activity Rentral", Code = "6", Value = "B09", Description = "B09", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 78, ConfigurationKey = "Activity Rentral", Code = "7", Value = "B10", Description = "B10", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 79, ConfigurationKey = "Activity Rentral", Code = "8", Value = "C01", Description = "C01", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 80, ConfigurationKey = "Activity Rentral", Code = "9", Value = "C11", Description = "C11", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 81, ConfigurationKey = "Activity Rentral", Code = "10", Value = "C03", Description = "C03", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 82, ConfigurationKey = "Activity Rentral", Code = "11", Value = "C09", Description = "C09", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 83, ConfigurationKey = "Activity Rentral", Code = "12", Value = "C12", Description = "C12", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 84, ConfigurationKey = "Activity Rentral", Code = "13", Value = "C10", Description = "C10", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 85, ConfigurationKey = "Activity Rentral", Code = "14", Value = "D01", Description = "D01", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 86, ConfigurationKey = "Activity Rentral", Code = "15", Value = "D02", Description = "D02", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 87, ConfigurationKey = "Activity Rentral", Code = "16", Value = "D06", Description = "D06", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 88, ConfigurationKey = "Activity Rentral", Code = "17", Value = "D09", Description = "D09", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 89, ConfigurationKey = "Activity Rentral", Code = "18", Value = "D16", Description = "D16", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 90, ConfigurationKey = "Activity Rentral", Code = "19", Value = "D14", Description = "D14", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 91, ConfigurationKey = "Activity Rentral", Code = "20", Value = "F01", Description = "F01", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 92, ConfigurationKey = "Activity Rentral", Code = "21", Value = "F02", Description = "F02", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 93, ConfigurationKey = "Activity MOU", Code = "1", Value = "C01", Description = "C01", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 94, ConfigurationKey = "Activity MOU", Code = "2", Value = "C03", Description = "C03", Remarks = null, IsActive = true, IsDelete = false },
                //new MasterConfiguration { Id = 95, ConfigurationKey = "Activity MOU", Code = "3", Value = "F01", Description = "F01", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 96, ConfigurationKey = "Clone", Code = "P6", Value = "P6", Description = "P6", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 97, ConfigurationKey = "Clone", Code = "H26", Value = "H26", Description = "H26", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 98, ConfigurationKey = "Clone", Code = "H32", Value = "H32", Description = "H32", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 99, ConfigurationKey = "Clone", Code = "H36", Value = "H36", Description = "H36", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 100, ConfigurationKey = "Clone", Code = "H38", Value = "H38", Description = "H38", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 101, ConfigurationKey = "Clone", Code = "H40", Value = "H40", Description = "H40", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 102, ConfigurationKey = "Clone", Code = "H42", Value = "H42", Description = "H42", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 103, ConfigurationKey = "Role", Code = "1", Value = "O1", Description = "Operation (ทีมหาพื้นที่ , ทีม QC)", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 104, ConfigurationKey = "Role", Code = "2", Value = "O2", Description = "Operation (ทีมปลูก)", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 105, ConfigurationKey = "Role", Code = "3", Value = "S", Description = "Supervisor", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 106, ConfigurationKey = "Role", Code = "4", Value = "SS", Description = "Section manager", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 107, ConfigurationKey = "Role", Code = "5", Value = "M", Description = "Department manager", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 108, ConfigurationKey = "Role", Code = "6", Value = "D", Description = "Document", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 109, ConfigurationKey = "Role", Code = "7", Value = "P", Description = "Approver", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 110, ConfigurationKey = "Role", Code = "8", Value = "A", Description = "Admin", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 111, ConfigurationKey = "Zone", Code = "1", Value = "West", Description = "West", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 112, ConfigurationKey = "Zone", Code = "2", Value = "North", Description = "North", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 113, ConfigurationKey = "Zone", Code = "3", Value = "Northeast", Description = "Northeast", Remarks = null, IsActive = true, IsDelete = false } ,
                new MasterConfiguration { Id = 114, ConfigurationKey = "MouType", Code = "1", Value = "Free Seed", Description = "Free Seed", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 115, ConfigurationKey = "MouType", Code = "2", Value = "Free Seed & Planting Subsidy", Description = "Free Seed & Planting Subsidy", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 116, ConfigurationKey = "SoilType", Code = "1", Value = "1", Description = "1", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 117, ConfigurationKey = "SoilType", Code = "2", Value = "2", Description = "2", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 118, ConfigurationKey = "SoilType", Code = "3", Value = "3", Description = "3", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 119, ConfigurationKey = "SoilType", Code = "8", Value = "8", Description = "8", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 120, ConfigurationKey = "SoilType", Code = "9", Value = "9", Description = "9", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 121, ConfigurationKey = "SoilType", Code = "10", Value = "10", Description = "10", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 122, ConfigurationKey = "SoilType", Code = "11", Value = "11", Description = "11", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 123, ConfigurationKey = "SoilType", Code = "12", Value = "12", Description = "12", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 124, ConfigurationKey = "SoilType", Code = "13", Value = "13", Description = "13", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 125, ConfigurationKey = "SoilType", Code = "14", Value = "14", Description = "14", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 126, ConfigurationKey = "SoilType", Code = "16", Value = "16", Description = "16", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 127, ConfigurationKey = "SoilType", Code = "20", Value = "20", Description = "20", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 128, ConfigurationKey = "SoilType", Code = "23", Value = "23", Description = "23", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 129, ConfigurationKey = "SoilType", Code = "24", Value = "24", Description = "24", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 130, ConfigurationKey = "SoilType", Code = "26", Value = "26", Description = "26", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 131, ConfigurationKey = "SoilType", Code = "27", Value = "27", Description = "27", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 132, ConfigurationKey = "SoilType", Code = "32", Value = "32", Description = "32", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 133, ConfigurationKey = "SoilType", Code = "33", Value = "33", Description = "33", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 134, ConfigurationKey = "SoilType", Code = "34", Value = "34", Description = "34", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 135, ConfigurationKey = "SoilType", Code = "38", Value = "38", Description = "38", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 136, ConfigurationKey = "SoilType", Code = "39", Value = "39", Description = "39", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 137, ConfigurationKey = "SoilType", Code = "41", Value = "41", Description = "41", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 138, ConfigurationKey = "SoilType", Code = "42", Value = "42", Description = "42", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 139, ConfigurationKey = "SoilType", Code = "43", Value = "43", Description = "43", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 140, ConfigurationKey = "SoilType", Code = "44", Value = "44", Description = "44", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 141, ConfigurationKey = "SoilType", Code = "45", Value = "45", Description = "45", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 142, ConfigurationKey = "SoilType", Code = "50", Value = "50", Description = "50", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 143, ConfigurationKey = "SoilType", Code = "51", Value = "51", Description = "51", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 144, ConfigurationKey = "SoilType", Code = "53", Value = "53", Description = "53", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 145, ConfigurationKey = "SoilType", Code = "57", Value = "57", Description = "57", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 146, ConfigurationKey = "SoilType", Code = "58", Value = "58", Description = "58", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 147, ConfigurationKey = "SoilType", Code = "59", Value = "59", Description = "59", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 148, ConfigurationKey = "SoilType", Code = "61", Value = "61", Description = "61", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 149, ConfigurationKey = "SoilType", Code = "63", Value = "63", Description = "63", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 150, ConfigurationKey = "Contract", Code = "3", Value = "3", Description = "3", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration { Id = 151, ConfigurationKey = "Contract", Code = "4", Value = "4", Description = "4", Remarks = null, IsActive = true, IsDelete = false },
                new MasterConfiguration
                {
                    Id = 152,
                    ConfigurationKey = "Status Plantation",
                    Code = "Contract Signed",
                    Value = "Contract Signed",
                    Description = "Contract Signed",
                    Remarks = null,
                    IsActive = true,
                    IsDelete = false
                },
                new MasterConfiguration
                {
                    Id = 153,
                    ConfigurationKey = "Status Plantation",
                    Code = "Completed",
                    Value = "Completed",
                    Description = "Completed",
                    Remarks = null,
                    IsActive = true,
                    IsDelete = false
                },
                new MasterConfiguration
                {
                    Id = 154,
                    ConfigurationKey = "Status Plantation",
                    Code = "Cancel",
                    Value = "Cancel",
                    Description = "Cancel",
                    Remarks = null,
                    IsActive = true,
                    IsDelete = false
                }

            );
        }
    }
}
