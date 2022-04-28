using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class defaultclone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MasterConfiguration",
                columns: new[] { "Id", "Code", "ConfigurationKey", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsDelete", "Remarks", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 96, "P6", "Clone", null, null, "P6", true, false, null, null, null, "P6" },
                    { 97, "H26", "Clone", null, null, "H26", true, false, null, null, null, "H26" },
                    { 98, "H32", "Clone", null, null, "H32", true, false, null, null, null, "H32" },
                    { 99, "H36", "Clone", null, null, "H36", true, false, null, null, null, "H36" },
                    { 100, "H38", "Clone", null, null, "H38", true, false, null, null, null, "H38" },
                    { 101, "H40", "Clone", null, null, "H40", true, false, null, null, null, "H40" },
                    { 102, "H42", "Clone", null, null, "H42", true, false, null, null, null, "H42" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 102);
        }
    }
}
