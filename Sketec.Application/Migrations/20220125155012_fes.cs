using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class fes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeasibilityPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mill = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PriceType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeasibilityPrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeasibilityYield",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoilType = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    RainfallStart = table.Column<int>(type: "int", nullable: true),
                    RainfallEnd = table.Column<int>(type: "int", nullable: true),
                    Yield = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeasibilityYield", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FeasibilityPrice",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "IsDelete", "Mill", "Price", "PriceType", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, null, true, false, "TPC", 1220m, "FC Target", null, null },
                    { 15, null, null, true, false, "PHY", 1132m, "Current", null, null },
                    { 13, null, null, true, false, "CHP", 1146m, "Current", null, null },
                    { 12, null, null, true, false, "KPP", 1184m, "Current", null, null },
                    { 11, null, null, true, false, "TPC", 1326m, "Current", null, null },
                    { 10, null, null, true, false, "PHY", 1264m, "MTP Agent", null, null },
                    { 9, null, null, true, false, "PPPC", 1405m, "MTP Agent", null, null },
                    { 14, null, null, true, false, "PPPC", 1202m, "Current", null, null },
                    { 7, null, null, true, false, "KPP", 1245m, "MTP Agent", null, null },
                    { 6, null, null, true, false, "TPC", 1500m, "MTP Agent", null, null },
                    { 5, null, null, true, false, "PHY", 1061m, "FC Target", null, null },
                    { 4, null, null, true, false, "PPPC", 1101m, "FC Target", null, null },
                    { 3, null, null, true, false, "CHP", 1070m, "FC Target", null, null },
                    { 2, null, null, true, false, "KPP", 1070m, "FC Target", null, null },
                    { 8, null, null, true, false, "CHP", 1261m, "MTP Agent", null, null }
                });

            migrationBuilder.InsertData(
                table: "FeasibilityYield",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "IsDelete", "RainfallEnd", "RainfallStart", "SoilType", "UpdatedBy", "UpdatedDate", "Yield" },
                values: new object[,]
                {
                    { 76, null, null, true, false, null, 1400, "40", null, null, 22.9m },
                    { 77, null, null, true, false, 1000, null, "46", null, null, 11.2m },
                    { 78, null, null, true, false, 1200, 1000, "46", null, null, 16.2m },
                    { 79, null, null, true, false, 1400, 1200, "46", null, null, 22m },
                    { 80, null, null, true, false, null, 1400, "46", null, null, 22m },
                    { 83, null, null, true, false, 1400, 1200, "47", null, null, 22m },
                    { 82, null, null, true, false, 1200, 1000, "47", null, null, 16.2m },
                    { 84, null, null, true, false, null, 1400, "47", null, null, 22m },
                    { 85, null, null, true, false, 1000, null, "48", null, null, 11.2m },
                    { 75, null, null, true, false, 1400, 1200, "40", null, null, 22.9m },
                    { 81, null, null, true, false, 1000, null, "47", null, null, 11.2m },
                    { 74, null, null, true, false, 1200, 1000, "40", null, null, 19.1m },
                    { 66, null, null, true, false, 1200, 1000, "36", null, null, 19m },
                    { 72, null, null, true, false, null, 1400, "37", null, null, 19.4m },
                    { 71, null, null, true, false, 1400, 1200, "37", null, null, 17.5m },
                    { 70, null, null, true, false, 1200, 1000, "37", null, null, 17.4m },
                    { 69, null, null, true, false, 1000, null, "37", null, null, 11.9m },
                    { 68, null, null, true, false, null, 1400, "36", null, null, 24.2m },
                    { 67, null, null, true, false, 1400, 1200, "36", null, null, 24.2m },
                    { 86, null, null, true, false, 1200, 1000, "48", null, null, 16.2m },
                    { 65, null, null, true, false, 1000, null, "36", null, null, 15.7m },
                    { 64, null, null, true, false, null, 1400, "35", null, null, 24.2m },
                    { 63, null, null, true, false, 1400, 1200, "35", null, null, 24.2m },
                    { 62, null, null, true, false, 1200, 1000, "35", null, null, 19m },
                    { 61, null, null, true, false, 1000, null, "35", null, null, 15.7m },
                    { 73, null, null, true, false, 1000, null, "40", null, null, 12.5m },
                    { 87, null, null, true, false, 1400, 1200, "48", null, null, 22m }
                });

            migrationBuilder.InsertData(
                table: "FeasibilityYield",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "IsDelete", "RainfallEnd", "RainfallStart", "SoilType", "UpdatedBy", "UpdatedDate", "Yield" },
                values: new object[,]
                {
                    { 95, null, null, true, false, 1400, 1200, "52", null, null, 0m },
                    { 89, null, null, true, false, 1000, null, "49", null, null, 0m },
                    { 116, null, null, true, false, null, 1400, "62", null, null, 0m },
                    { 115, null, null, true, false, 1400, 1200, "62", null, null, 0m },
                    { 114, null, null, true, false, 1200, 1000, "62", null, null, 0m },
                    { 113, null, null, true, false, 1000, null, "62", null, null, 0m },
                    { 112, null, null, true, false, null, 1400, "60", null, null, 22.9m },
                    { 111, null, null, true, false, 1400, 1200, "60", null, null, 22.9m },
                    { 110, null, null, true, false, 1200, 1000, "60", null, null, 19.1m },
                    { 108, null, null, true, false, null, 1400, "56", null, null, 19.4m },
                    { 107, null, null, true, false, 1400, 1200, "56", null, null, 17.5m },
                    { 106, null, null, true, false, 1200, 1000, "56", null, null, 17.4m },
                    { 105, null, null, true, false, 1000, null, "56", null, null, 11.9m },
                    { 104, null, null, true, false, null, 1400, "55", null, null, 19.4m },
                    { 88, null, null, true, false, null, 1400, "48", null, null, 22m },
                    { 103, null, null, true, false, 1400, 1200, "55", null, null, 17.5m },
                    { 101, null, null, true, false, 1000, null, "55", null, null, 11.9m },
                    { 100, null, null, true, false, null, 1400, "54", null, null, 0m },
                    { 99, null, null, true, false, 1400, 1200, "54", null, null, 0m },
                    { 98, null, null, true, false, 1200, 1000, "54", null, null, 0m },
                    { 97, null, null, true, false, 1000, null, "54", null, null, 0m },
                    { 96, null, null, true, false, null, 1400, "52", null, null, 0m },
                    { 60, null, null, true, false, null, 1400, "31", null, null, 15.7m },
                    { 94, null, null, true, false, 1200, 1000, "52", null, null, 0m },
                    { 93, null, null, true, false, 1000, null, "52", null, null, 0m },
                    { 92, null, null, true, false, null, 1400, "49", null, null, 18.2m },
                    { 91, null, null, true, false, 1400, 1200, "49", null, null, 18.2m },
                    { 90, null, null, true, false, 1200, 1000, "49", null, null, 13.8m },
                    { 102, null, null, true, false, 1200, 1000, "55", null, null, 17.4m },
                    { 59, null, null, true, false, 1400, 1200, "31", null, null, 14.9m },
                    { 109, null, null, true, false, 1000, null, "60", null, null, 12.5m },
                    { 57, null, null, true, false, 1000, null, "31", null, null, 12.8m },
                    { 26, null, null, true, false, 1200, 1000, "18", null, null, 16.5m },
                    { 25, null, null, true, false, 1000, null, "18", null, null, 0m },
                    { 24, null, null, true, false, null, 1400, "17", null, null, 18m },
                    { 23, null, null, true, false, 1400, 1200, "17", null, null, 16.5m },
                    { 22, null, null, true, false, 1200, 1000, "17", null, null, 16.5m },
                    { 21, null, null, true, false, 1000, null, "17", null, null, 0m },
                    { 20, null, null, true, false, null, 1400, "15", null, null, 18m },
                    { 18, null, null, true, false, 1200, 1000, "15", null, null, 16.5m },
                    { 17, null, null, true, false, 1000, null, "15", null, null, 0m },
                    { 16, null, null, true, false, null, 1400, "7", null, null, 15.7m }
                });

            migrationBuilder.InsertData(
                table: "FeasibilityYield",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "IsDelete", "RainfallEnd", "RainfallStart", "SoilType", "UpdatedBy", "UpdatedDate", "Yield" },
                values: new object[,]
                {
                    { 15, null, null, true, false, 1400, 1200, "7", null, null, 14.9m },
                    { 14, null, null, true, false, 1200, 1000, "7", null, null, 14.9m },
                    { 27, null, null, true, false, 1400, 1200, "18", null, null, 16.5m },
                    { 13, null, null, true, false, 1000, null, "7", null, null, 12.8m },
                    { 11, null, null, true, false, 1400, 1200, "6", null, null, 14.9m },
                    { 10, null, null, true, false, 1200, 1000, "6", null, null, 14.9m },
                    { 9, null, null, true, false, 1000, null, "6", null, null, 12.8m },
                    { 8, null, null, true, false, null, 1400, "5", null, null, 15.7m },
                    { 7, null, null, true, false, 1400, 1200, "5", null, null, 14.9m },
                    { 6, null, null, true, false, 1200, 1000, "5", null, null, 14.9m },
                    { 5, null, null, true, false, 1000, null, "5", null, null, 12.8m },
                    { 4, null, null, true, false, null, 1400, "4", null, null, 15.7m },
                    { 3, null, null, true, false, 1400, 1200, "4", null, null, 14.9m },
                    { 2, null, null, true, false, 1200, 1000, "4", null, null, 14.9m },
                    { 1, null, null, true, false, 1000, null, "4", null, null, 12.8m },
                    { 58, null, null, true, false, 1200, 1000, "31", null, null, 14.9m },
                    { 12, null, null, true, false, null, 1400, "6", null, null, 15.7m },
                    { 28, null, null, true, false, null, 1400, "18", null, null, 18m },
                    { 19, null, null, true, false, 1400, 1200, "15", null, null, 16.5m },
                    { 30, null, null, true, false, 1200, 1000, "19", null, null, 19.1m },
                    { 56, null, null, true, false, null, 1400, "30", null, null, 15.7m },
                    { 55, null, null, true, false, 1400, 1200, "30", null, null, 14.9m },
                    { 54, null, null, true, false, 1200, 1000, "30", null, null, 14.9m },
                    { 53, null, null, true, false, 1000, null, "30", null, null, 12.8m },
                    { 52, null, null, true, false, null, 1400, "29", null, null, 15.7m },
                    { 29, null, null, true, false, 1000, null, "19", null, null, 12.5m },
                    { 50, null, null, true, false, 1200, 1000, "29", null, null, 14.9m },
                    { 49, null, null, true, false, 1000, null, "29", null, null, 12.8m },
                    { 48, null, null, true, false, null, 1400, "28", null, null, 15.7m },
                    { 47, null, null, true, false, 1400, 1200, "28", null, null, 14.9m },
                    { 46, null, null, true, false, 1200, 1000, "28", null, null, 14.9m },
                    { 45, null, null, true, false, 1000, null, "28", null, null, 12.8m },
                    { 44, null, null, true, false, null, 1400, "25", null, null, 18.2m },
                    { 51, null, null, true, false, 1400, 1200, "29", null, null, 14.9m },
                    { 42, null, null, true, false, 1200, 1000, "25", null, null, 13.8m },
                    { 31, null, null, true, false, 1400, 1200, "19", null, null, 22.9m },
                    { 43, null, null, true, false, 1400, 1200, "25", null, null, 18.2m },
                    { 32, null, null, true, false, null, 1400, "19", null, null, 22.9m },
                    { 33, null, null, true, false, 1000, null, "21", null, null, 12.5m },
                    { 35, null, null, true, false, 1400, 1200, "21", null, null, 22.9m },
                    { 36, null, null, true, false, null, 1400, "21", null, null, 22.9m },
                    { 34, null, null, true, false, 1200, 1000, "21", null, null, 19.1m }
                });

            migrationBuilder.InsertData(
                table: "FeasibilityYield",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "IsDelete", "RainfallEnd", "RainfallStart", "SoilType", "UpdatedBy", "UpdatedDate", "Yield" },
                values: new object[,]
                {
                    { 38, null, null, true, false, 1200, 1000, "22", null, null, 19.1m },
                    { 39, null, null, true, false, 1400, 1200, "22", null, null, 22.9m },
                    { 40, null, null, true, false, null, 1400, "22", null, null, 22.9m },
                    { 41, null, null, true, false, 1000, null, "25", null, null, 0m },
                    { 37, null, null, true, false, 1000, null, "22", null, null, 12.5m }
                });

            migrationBuilder.InsertData(
                table: "MasterActivity",
                columns: new[] { "Id", "ActivityCode", "ActivityEN", "ActivityTH", "CreatedBy", "CreatedDate", "IsActive", "IsDelete", "MasterActivityTypeId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 63, "D19", "", "ค่าปั่นโรตารี่ตีดิน ", null, null, true, false, 4, null, null },
                    { 64, "D20", "", "ค่าตัดหญ้า ด้วยแทรกเตอร์", null, null, true, false, 4, null, null },
                    { 58, "D14", "Fire control : Fire brake", "ทำแนวกันไฟ", null, null, true, false, 4, null, null },
                    { 62, "D18", "", "ฉีด/พ่น สารเคมีแทรกเตอร์ ", null, null, true, false, 4, null, null },
                    { 61, "D17", "", "ค่าหว่านปุ๋ยเม็ดด้วยแทรกเตอร์ ", null, null, true, false, 4, null, null },
                    { 60, "D16", "", "ค่าใส่ปุ๋ย เครื่องจักร", null, null, true, false, 4, null, null },
                    { 59, "D15", "Maintenance : Watering", "รดน้ำ", null, null, true, false, 4, null, null },
                    { 57, "D13", "Fertilizing : sowing", "หว่านรอบโคนต้น", null, null, true, false, 4, null, null },
                    { 51, "D07", "Weeding control by tractor : 1 column (3 m)", "ไถแนวเดียว ร่อง 3 ม.", null, null, true, false, 4, null, null },
                    { 55, "D11", "Sludge", "ค่า sludge", null, null, true, false, 4, null, null },
                    { 54, "D10", "Organic fert.", "ค่าปุ๋ยอินทรีย์", null, null, true, false, 4, null, null },
                    { 53, "D09", "Chem fert.", "ค่าปุ๋ยเคมี", null, null, true, false, 4, null, null },
                    { 52, "D08", "Weeding control by tractor : 1 column (2 m)", "ไถแนวเดียว ร่อง 2 ม.", null, null, true, false, 4, null, null },
                    { 50, "D06", "Weeding control by tractor : cross", "ไถกากบาท", null, null, true, false, 4, null, null },
                    { 49, "D05", "Weeding control by chemical (drone)", "ฉีด/พ่น ยาฆ่าหญ้า, ยาฆ่าแมลง,สารเคมี (โดรน)", null, null, true, false, 4, null, null },
                    { 48, "D04", "Weeding control by chemical (manaul)", "ฉีด/พ่น ยาฆ่าหญ้า, ยาฆ่าแมลง,สารเคมี (แรงงาน)", null, null, true, false, 4, null, null },
                    { 65, "D21", "", "ค่าดันแปลง/ดันถนนรอบแปลง ", null, null, true, false, 4, null, null },
                    { 47, "D03", "Weeding control by manaul", "หวดกำจัดวัชพืช", null, null, true, false, 4, null, null },
                    { 56, "D12", "Fertilizing : Digging 2 holes", "ขุดหลุมฝังกลบ 2 ข้าง", null, null, true, false, 4, null, null },
                    { 66, "D22", "Wage / Salary & OT Tractor driver / Machine rental", "ค่าแรงคนขับรถไถ & OT & ค่าเช่ารถ", null, null, true, false, 4, null, null },
                    { 87, "G00", "Others", "รายรับอื่นๆ", null, null, true, false, 7, null, null },
                    { 68, "D24", "Lubricant, Lube", "ค่าน้ำมันเครื่อง", null, null, true, false, 4, null, null },
                    { 46, "D02", "Weeding control by manaul (0.5 m)", "ถากรอบโคน (0.5 m)", null, null, true, false, 4, null, null },
                    { 86, "G02", "Biomass", "ค่าไม้ชีวมวล", null, null, true, false, 7, null, null },
                    { 85, "G01", "Wood Log", "ค่าไม้ท่อน", null, null, true, false, 7, null, null },
                    { 84, "H01", "Wood Log Transportation", "ค่าขนส่งไม้ท่อน", null, null, true, false, 8, null, null },
                    { 83, "E02", "Harvesting (Machine)", "ค่าตัดไม้ (รถตัด)", null, null, true, false, 5, null, null },
                    { 82, "E01", "Harvesting (Labor)", "ค่าตัดไม้ (แรงงานคน)", null, null, true, false, 5, null, null },
                    { 81, "F00", "Others", "อื่นๆ", null, null, true, false, 6, null, null },
                    { 80, "F08", "Forest inventory : Growth", "ค่าประเมินผลผลิต (ความโต)", null, null, true, false, 6, null, null },
                    { 79, "F07", "Monitoring : %Surv.", "ค่าประเมินอัตรารอดตาย", null, null, true, false, 6, null, null },
                    { 78, "F06", "Lodging", "ค่าที่พัก", null, null, true, false, 6, null, null },
                    { 77, "F05", "Office maintenance", "ค่าซ่อมบำรุง สถานที่ / สำนักงาน", null, null, true, false, 6, null, null },
                    { 76, "F04", "Tool, Equipment, ", "ค่าวัสดุอุปกรณ์", null, null, true, false, 6, null, null },
                    { 75, "F03", "Donation, Gift, Contribution,", "ค่าสนับสนุน, เงินบริจาค", null, null, true, false, 6, null, null },
                    { 74, "F02", "Tax", "อากรแสตมป์, ภาษีบำรุงท้องที่, ภาษีตามกฏหมาย", null, null, true, false, 6, null, null },
                    { 73, "F01", "Administrative fee, Public utility, Annual fee", "จดทะเบียนเช่า, ค่าสาธารณูปโภค, ค่าดำเนินการตามกฏหมาย ,ค่าพนักงานสวนไม้,คนเฝ้าแปลง ฯลฯ", null, null, true, false, 6, null, null }
                });

            migrationBuilder.InsertData(
                table: "MasterActivity",
                columns: new[] { "Id", "ActivityCode", "ActivityEN", "ActivityTH", "CreatedBy", "CreatedDate", "IsActive", "IsDelete", "MasterActivityTypeId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 72, "D00", "Maintenance : Others", "อื่นๆ", null, null, true, false, 4, null, null },
                    { 71, "D27", "Moving & transport", "ค่าขนย้ายรถ", null, null, true, false, 4, null, null },
                    { 70, "D26", "Maintenance", "ค่าซ่อม/บำรุง เครื่องจักร", null, null, true, false, 4, null, null },
                    { 69, "D25", "Spare parts,", "ค่าอะไหล่", null, null, true, false, 4, null, null },
                    { 67, "D23", "Diesel", "ค่าน้ำมันดีเซล", null, null, true, false, 4, null, null },
                    { 45, "D01", "Coppice Thinning", "แต่งหน่อ ", null, null, true, false, 4, null, null },
                    { 29, "C06", "Planting : Put polymer on the bottom ", "ใส่โพลิเมอร์รองก้นหลุม ", null, null, true, false, 3, null, null },
                    { 43, "C20", "Moving & transport", "ค่าขนย้ายรถ", null, null, true, false, 3, null, null },
                    { 18, "B14", "Diesel", "ค่าน้ำมันดีเซล", null, null, true, false, 2, null, null },
                    { 17, "B13", "Wage / Salary & OT Tractor driver / Machine rental", "ค่าแรงคนขับรถไถ & OT & ค่าเช่ารถ", null, null, true, false, 2, null, null },
                    { 16, "B12", "", "ยกร่อง", null, null, true, false, 2, null, null },
                    { 15, "B11", "", "ลง Ripper 60 cm.", null, null, true, false, 2, null, null },
                    { 14, "B10", "", "ฉีดยาคุมหญ้า", null, null, true, false, 2, null, null },
                    { 13, "B09", "", "รองก้นหลุมด้วย Sludge /ปุ๋ย อินทรีย์ (รอบตัดฟัน#1)", null, null, true, false, 2, null, null },
                    { 12, "B08", "Site Preparation : Ripper & Trench & Sludge", "ลง ripper ยกร่อง ใส่ sludge", null, null, true, false, 2, null, null },
                    { 11, "B07", "Improve soil quality by Sludge (Machine)", "ปรับปรุงคุณภาพดินด้วย Sludge (เครื่องพ่น)", null, null, true, false, 2, null, null },
                    { 19, "B15", "Lubricant, Lube", "ค่าน้ำมันเครื่อง", null, null, true, false, 2, null, null },
                    { 10, "B06", "Improve soil quality by Org.Fertilizer", "ปรับปรุงคุณภาพดินด้วยปุ๋ยอินทรีย์", null, null, true, false, 2, null, null },
                    { 8, "B04", "Plough soil with 7 disks tractor", "ไถพรวนดิน (ผาน 7)", null, null, true, false, 2, null, null },
                    { 44, "C00", "Planting : Others", "อื่นๆ", null, null, true, false, 3, null, null },
                    { 6, "B02", "Site Preparation : Ripper", "ลง ripper", null, null, true, false, 2, null, null },
                    { 5, "B01", "Site Preparation : Land clearing", "ขุดตอ เก็บริบ&สุมเผา&ทำร่องน้ำ", null, null, true, false, 2, null, null },
                    { 4, "A00", "Others", "อื่นๆ", null, null, true, false, 1, null, null },
                    { 3, "A03", "Commission", "ค่านายหน้า", null, null, true, false, 1, null, null },
                    { 2, "A02", "Share benefit / profit", "ค่าแบ่งปันผลประโยชน์ / ผลกำไร", null, null, true, false, 1, null, null },
                    { 1, "A01", "Rental", "ค่าเช่าที่ดิน", null, null, true, false, 1, null, null },
                    { 9, "B05", "Improve soil quality by Sludge", "ปรับปรุงคุณภาพดินด้วย Sludge", null, null, true, false, 2, null, null },
                    { 20, "B16", "Spare parts,", "ค่าอะไหล่", null, null, true, false, 2, null, null },
                    { 7, "B03", "Plough soil with 3 disks tractor ", "ไถบุกเบิก (ผาน 3)", null, null, true, false, 2, null, null },
                    { 22, "B18", "Moving & transport", "ค่าขนย้ายรถ", null, null, true, false, 2, null, null },
                    { 21, "B17", "Maintenance", "ค่าซ่อม/บำรุง เครื่องจักร", null, null, true, false, 2, null, null },
                    { 42, "C19", "Maintenance", "ค่าซ่อม/บำรุง เครื่องจักร", null, null, true, false, 3, null, null },
                    { 41, "C18", "Spare parts,", "ค่าอะไหล่", null, null, true, false, 3, null, null },
                    { 40, "C17", "Lubricant, Lube", "ค่าน้ำมันเครื่อง", null, null, true, false, 3, null, null },
                    { 38, "C15", "Wage / Salary & OT Tractor driver / Machine rental", "ค่าแรงคนขับรถไถ & OT & ค่าเช่ารถ", null, null, true, false, 3, null, null },
                    { 37, "C14", "", "ปลูกเจาะหลุมด้วยแทรกเตอร์", null, null, true, false, 3, null, null },
                    { 36, "C13", "", "ปลูกด้วยเครื่องติดแทรกเตอร์ ", null, null, true, false, 3, null, null },
                    { 35, "C12", "", "ค่ากำจัดวัชพืชรอบโคน", null, null, true, false, 3, null, null },
                    { 34, "C11", "", "ค่าสารปรับปรุงดิน (ปุ๋ย หรือ อื่นๆ)", null, null, true, false, 3, null, null },
                    { 39, "C16", "Diesel", "ค่าน้ำมันดีเซล", null, null, true, false, 3, null, null },
                    { 32, "C09", "Planting : Watering", "รดน้ำ", null, null, true, false, 3, null, null },
                    { 31, "C08", "Planting : Put sludge on the bottom", "ใส่ Sludg รองก้นหลุม", null, null, true, false, 3, null, null }
                });

            migrationBuilder.InsertData(
                table: "MasterActivity",
                columns: new[] { "Id", "ActivityCode", "ActivityEN", "ActivityTH", "CreatedBy", "CreatedDate", "IsActive", "IsDelete", "MasterActivityTypeId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 30, "C07", "Planting : Put osmocote fert. on the bottom", "ใส่ปุ๋ยละลายช้ารองก้นหลุม", null, null, true, false, 3, null, null },
                    { 28, "C05", "Planting : Drill a hole by tractor", "วางแนว & เจาะหลุมปลูก (รถไถ)", null, null, true, false, 3, null, null },
                    { 27, "C04", "Planting : Drill a hole by labor", "วางแนว & เจาะหลุมปลูก (แรงงาน)", null, null, true, false, 3, null, null },
                    { 26, "C03", "Planting : Digging a hole by labor", "วางแนว & ขุดหลุมปลูก (แรงงาน)", null, null, true, false, 3, null, null },
                    { 25, "C02", "Planting : Strip line", "วางแนว & ปลูก", null, null, true, false, 3, null, null },
                    { 24, "C01", "Planting : Seedling", "ค่ากล้าไม้", null, null, true, false, 3, null, null },
                    { 33, "C10", "Planting : Blanking", "ปลูกซ่อม", null, null, true, false, 3, null, null },
                    { 23, "B00", "Site Preparation : Others", "อื่นๆ", null, null, true, false, 2, null, null }
                });

            migrationBuilder.InsertData(
                table: "MasterConfiguration",
                columns: new[] { "Id", "Code", "ConfigurationKey", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsDelete", "Remarks", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 32, "36", "SoilType", null, null, "36", true, false, null, null, null, "36" },
                    { 33, "37", "SoilType", null, null, "37", true, false, null, null, null, "37" },
                    { 34, "40", "SoilType", null, null, "40", true, false, null, null, null, "40" },
                    { 35, "46", "SoilType", null, null, "46", true, false, null, null, null, "46" },
                    { 36, "47", "SoilType", null, null, "47", true, false, null, null, null, "47" },
                    { 40, "54", "SoilType", null, null, "54", true, false, null, null, null, "54" },
                    { 38, "49", "SoilType", null, null, "49", true, false, null, null, null, "49" },
                    { 39, "52", "SoilType", null, null, "52", true, false, null, null, null, "52" },
                    { 41, "55", "SoilType", null, null, "55", true, false, null, null, null, "55" },
                    { 42, "56", "SoilType", null, null, "56", true, false, null, null, null, "56" },
                    { 31, "35", "SoilType", null, null, "35", true, false, null, null, null, "35" },
                    { 37, "48", "SoilType", null, null, "48", true, false, null, null, null, "48" },
                    { 30, "31", "SoilType", null, null, "31", true, false, null, null, null, "31" },
                    { 19, "7", "SoilType", null, null, "7", true, false, null, null, null, "7" },
                    { 28, "29", "SoilType", null, null, "29", true, false, null, null, null, "29" },
                    { 27, "28", "SoilType", null, null, "28", true, false, null, null, null, "28" },
                    { 26, "25", "SoilType", null, null, "25", true, false, null, null, null, "25" },
                    { 25, "22", "SoilType", null, null, "22", true, false, null, null, null, "22" },
                    { 24, "21", "SoilType", null, null, "21", true, false, null, null, null, "21" },
                    { 23, "19", "SoilType", null, null, "19", true, false, null, null, null, "19" },
                    { 22, "18", "SoilType", null, null, "18", true, false, null, null, null, "18" },
                    { 21, "17", "SoilType", null, null, "17", true, false, null, null, null, "17" },
                    { 20, "15", "SoilType", null, null, "15", true, false, null, null, null, "15" },
                    { 18, "6", "SoilType", null, null, "6", true, false, null, null, null, "6" },
                    { 17, "5", "SoilType", null, null, "5", true, false, null, null, null, "5" },
                    { 16, "4", "SoilType", null, null, "4", true, false, null, null, null, "4" },
                    { 43, "60", "SoilType", null, null, "60", true, false, null, null, null, "60" },
                    { 29, "30", "SoilType", null, null, "30", true, false, null, null, null, "30" },
                    { 44, "62", "SoilType", null, null, "62", true, false, null, null, null, "62" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeasibilityPrice");

            migrationBuilder.DropTable(
                name: "FeasibilityYield");

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "MasterActivity",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 44);
        }
    }
}
