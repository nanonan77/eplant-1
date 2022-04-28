using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class MasterConfigMouType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MasterConfiguration",
                columns: new[] { "Id", "Code", "ConfigurationKey", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsDelete", "Remarks", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[] { 114, "1", "MouType", null, null, "Free Seed", true, false, null, null, null, "Free Seed" });

            migrationBuilder.InsertData(
                table: "MasterConfiguration",
                columns: new[] { "Id", "Code", "ConfigurationKey", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsDelete", "Remarks", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[] { 115, "2", "MouType", null, null, "Free Seed & Planting Subsidy", true, false, null, null, null, "Free Seed & Planting Subsidy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 115);
        }
    }
}
