using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class configdropdown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MasterConfiguration",
                columns: new[] { "Id", "Code", "ConfigurationKey", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsDelete", "Remarks", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 45, "1", "Accessibility", null, null, "มี - รถบรรทุกไม้เข้าถึง", true, false, null, null, null, "มี - รถบรรทุกไม้เข้าถึง" },
                    { 72, "1", "Activity Rentral", null, null, "A01", true, false, null, null, null, "A01" },
                    { 73, "2", "Activity Rentral", null, null, "A03", true, false, null, null, null, "A03" },
                    { 74, "3", "Activity Rentral", null, null, "B01", true, false, null, null, null, "B01" },
                    { 75, "4", "Activity Rentral", null, null, "B03", true, false, null, null, null, "B03" },
                    { 76, "5", "Activity Rentral", null, null, "B04", true, false, null, null, null, "B04" },
                    { 77, "6", "Activity Rentral", null, null, "B09", true, false, null, null, null, "B09" },
                    { 78, "7", "Activity Rentral", null, null, "B10", true, false, null, null, null, "B10" },
                    { 79, "8", "Activity Rentral", null, null, "C01", true, false, null, null, null, "C01" },
                    { 80, "9", "Activity Rentral", null, null, "C11", true, false, null, null, null, "C11" },
                    { 81, "10", "Activity Rentral", null, null, "C03", true, false, null, null, null, "C03" },
                    { 71, "3", "Team", null, null, "ทีม QC", true, false, null, null, null, "ทีม QC" },
                    { 82, "11", "Activity Rentral", null, null, "C09", true, false, null, null, null, "C09" },
                    { 84, "13", "Activity Rentral", null, null, "C10", true, false, null, null, null, "C10" },
                    { 85, "14", "Activity Rentral", null, null, "D01", true, false, null, null, null, "D01" },
                    { 86, "15", "Activity Rentral", null, null, "D02", true, false, null, null, null, "D02" },
                    { 87, "16", "Activity Rentral", null, null, "D06", true, false, null, null, null, "D06" },
                    { 88, "17", "Activity Rentral", null, null, "D09", true, false, null, null, null, "D09" },
                    { 89, "18", "Activity Rentral", null, null, "D16", true, false, null, null, null, "D16" },
                    { 90, "19", "Activity Rentral", null, null, "D14", true, false, null, null, null, "D14" },
                    { 91, "20", "Activity Rentral", null, null, "F01", true, false, null, null, null, "F01" },
                    { 92, "21", "Activity Rentral", null, null, "F02", true, false, null, null, null, "F02" },
                    { 93, "1", "Activity MOU", null, null, "C01", true, false, null, null, null, "C01" },
                    { 83, "12", "Activity Rentral", null, null, "C12", true, false, null, null, null, "C12" },
                    { 94, "2", "Activity MOU", null, null, "C03", true, false, null, null, null, "C03" },
                    { 70, "2", "Team", null, null, "ทีมปลูก", true, false, null, null, null, "ทีมปลูก" },
                    { 68, "4", "Contract", null, null, "15", true, false, null, null, null, "15" },
                    { 46, "2", "Accessibility", null, null, "มี - รถบรรทุกเข้าถึงไม่ได้", true, false, null, null, null, "มี - รถบรรทุกเข้าถึงไม่ได้" },
                    { 47, "3", "Accessibility", null, null, "แปลงตาบอด", true, false, null, null, null, "แปลงตาบอด" },
                    { 48, "1", "Depth", null, null, "< 30 cm.", true, false, null, null, null, "< 30 cm." },
                    { 49, "2", "Depth", null, null, "30-50 cm.", true, false, null, null, null, "30-50 cm." },
                    { 50, "3", "Depth", null, null, "50-80 cm.", true, false, null, null, null, "50-80 cm." },
                    { 51, "4", "Depth", null, null, "80-100 cm.", true, false, null, null, null, "80-100 cm." },
                    { 52, "5", "Depth", null, null, "> 100 cm.", true, false, null, null, null, "> 100 cm." },
                    { 53, "1", "SoillFloorDepth", null, null, "No", true, false, null, null, null, "No" },
                    { 54, "2", "SoillFloorDepth", null, null, "< 30 cm.", true, false, null, null, null, "< 30 cm." },
                    { 55, "3", "SoillFloorDepth", null, null, "30-50 cm.", true, false, null, null, null, "30-50 cm." },
                    { 69, "1", "Team", null, null, "ทีมหาพื้นที่", true, false, null, null, null, "ทีมหาพื้นที่" },
                    { 56, "4", "SoillFloorDepth", null, null, "50-80 cm.", true, false, null, null, null, "50-80 cm." },
                    { 58, "1", "GravelDepth", null, null, "No", true, false, null, null, null, "No" },
                    { 59, "2", "GravelDepth", null, null, "< 30 cm.", true, false, null, null, null, "< 30 cm." },
                    { 60, "3", "GravelDepth", null, null, "30-50 cm.", true, false, null, null, null, "30-50 cm." }
                });

            migrationBuilder.InsertData(
                table: "MasterConfiguration",
                columns: new[] { "Id", "Code", "ConfigurationKey", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsDelete", "Remarks", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 61, "4", "GravelDepth", null, null, "50-80 cm.", true, false, null, null, null, "50-80 cm." },
                    { 62, "5", "GravelDepth", null, null, "80-100 cm.", true, false, null, null, null, "80-100 cm." },
                    { 63, "1", "Water", null, null, "มี", true, false, null, null, null, "มี" },
                    { 64, "2", "Water", null, null, "ไม่มี", true, false, null, null, null, "ไม่มี" },
                    { 65, "1", "Contract", null, null, "5", true, false, null, null, null, "5" },
                    { 66, "2", "Contract", null, null, "6", true, false, null, null, null, "6" },
                    { 67, "3", "Contract", null, null, "10", true, false, null, null, null, "10" },
                    { 57, "5", "SoillFloorDepth", null, null, "80-100 cm.", true, false, null, null, null, "80-100 cm." },
                    { 95, "3", "Activity MOU", null, null, "F01", true, false, null, null, null, "F01" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 95);
        }
    }
}
