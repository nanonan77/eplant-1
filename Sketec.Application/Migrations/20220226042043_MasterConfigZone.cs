using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class MasterConfigZone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MasterConfiguration",
                columns: new[] { "Id", "Code", "ConfigurationKey", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsDelete", "Remarks", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[] { 111, "1", "Zone", null, null, "West", true, false, null, null, null, "West" });

            migrationBuilder.InsertData(
                table: "MasterConfiguration",
                columns: new[] { "Id", "Code", "ConfigurationKey", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsDelete", "Remarks", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[] { 112, "2", "Zone", null, null, "North", true, false, null, null, null, "North" });

            migrationBuilder.InsertData(
                table: "MasterConfiguration",
                columns: new[] { "Id", "Code", "ConfigurationKey", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsDelete", "Remarks", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[] { 113, "3", "Zone", null, null, "Northeast", true, false, null, null, null, "Northeast" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 113);
        }
    }
}
