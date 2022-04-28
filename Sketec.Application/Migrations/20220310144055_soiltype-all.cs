using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class soiltypeall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MasterConfiguration",
                columns: new[] { "Id", "Code", "ConfigurationKey", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsDelete", "Remarks", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 116, "1", "SoilType", null, null, "1", true, false, null, null, null, "1" },
                    { 147, "59", "SoilType", null, null, "59", true, false, null, null, null, "59" },
                    { 146, "58", "SoilType", null, null, "58", true, false, null, null, null, "58" },
                    { 145, "57", "SoilType", null, null, "57", true, false, null, null, null, "57" },
                    { 144, "53", "SoilType", null, null, "53", true, false, null, null, null, "53" },
                    { 143, "51", "SoilType", null, null, "51", true, false, null, null, null, "51" },
                    { 142, "50", "SoilType", null, null, "50", true, false, null, null, null, "50" },
                    { 141, "45", "SoilType", null, null, "45", true, false, null, null, null, "45" },
                    { 140, "44", "SoilType", null, null, "44", true, false, null, null, null, "44" },
                    { 139, "43", "SoilType", null, null, "43", true, false, null, null, null, "43" },
                    { 138, "42", "SoilType", null, null, "42", true, false, null, null, null, "42" },
                    { 137, "41", "SoilType", null, null, "41", true, false, null, null, null, "41" },
                    { 136, "39", "SoilType", null, null, "39", true, false, null, null, null, "39" },
                    { 135, "38", "SoilType", null, null, "38", true, false, null, null, null, "38" },
                    { 134, "34", "SoilType", null, null, "34", true, false, null, null, null, "34" },
                    { 133, "33", "SoilType", null, null, "33", true, false, null, null, null, "33" },
                    { 132, "32", "SoilType", null, null, "32", true, false, null, null, null, "32" },
                    { 131, "27", "SoilType", null, null, "27", true, false, null, null, null, "27" },
                    { 117, "2", "SoilType", null, null, "2", true, false, null, null, null, "2" },
                    { 118, "3", "SoilType", null, null, "3", true, false, null, null, null, "3" },
                    { 119, "8", "SoilType", null, null, "8", true, false, null, null, null, "8" },
                    { 120, "9", "SoilType", null, null, "9", true, false, null, null, null, "9" },
                    { 121, "10", "SoilType", null, null, "10", true, false, null, null, null, "10" },
                    { 122, "11", "SoilType", null, null, "11", true, false, null, null, null, "11" },
                    { 148, "61", "SoilType", null, null, "61", true, false, null, null, null, "61" },
                    { 123, "12", "SoilType", null, null, "12", true, false, null, null, null, "12" },
                    { 125, "14", "SoilType", null, null, "14", true, false, null, null, null, "14" },
                    { 126, "16", "SoilType", null, null, "16", true, false, null, null, null, "16" },
                    { 127, "20", "SoilType", null, null, "20", true, false, null, null, null, "20" },
                    { 128, "23", "SoilType", null, null, "23", true, false, null, null, null, "23" },
                    { 129, "24", "SoilType", null, null, "24", true, false, null, null, null, "24" },
                    { 130, "26", "SoilType", null, null, "26", true, false, null, null, null, "26" },
                    { 124, "13", "SoilType", null, null, "13", true, false, null, null, null, "13" },
                    { 149, "63", "SoilType", null, null, "63", true, false, null, null, null, "63" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 149);
        }
    }
}
