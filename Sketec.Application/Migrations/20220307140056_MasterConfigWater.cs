using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class MasterConfigWater : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Description", "Value" },
                values: new object[] { "Yes", "Yes" });

            migrationBuilder.UpdateData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Description", "Value" },
                values: new object[] { "No", "No" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Description", "Value" },
                values: new object[] { "มี", "มี" });

            migrationBuilder.UpdateData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Description", "Value" },
                values: new object[] { "ไม่มี", "ไม่มี" });
        }
    }
}
