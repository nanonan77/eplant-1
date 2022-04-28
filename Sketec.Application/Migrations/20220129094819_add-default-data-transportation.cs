using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class adddefaultdatatransportation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MasterTransportationHeader",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "FreightMax", "FreightMin", "IsActive", "IsDelete", "TruckType", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, null, null, null, true, false, "Normal", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MasterTransportationHeader",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
