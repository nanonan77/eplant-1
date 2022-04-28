using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class contract34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MasterConfiguration",
                columns: new[] { "Id", "Code", "ConfigurationKey", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsDelete", "Remarks", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[] { 150, "3", "Contract", null, null, "3", true, false, null, null, null, "3" });

            migrationBuilder.InsertData(
                table: "MasterConfiguration",
                columns: new[] { "Id", "Code", "ConfigurationKey", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsDelete", "Remarks", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[] { 151, "4", "Contract", null, null, "4", true, false, null, null, null, "4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 151);
        }
    }
}
