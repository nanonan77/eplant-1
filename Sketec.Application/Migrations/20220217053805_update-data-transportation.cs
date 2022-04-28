using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class updatedatatransportation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MasterTransportationDetail",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "IsDelete", "MasterTransportationHeaderId", "Title", "UnitPrice", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, null, true, false, 1, 50, 2.2m, null, null },
                    { 2, null, null, true, false, 1, 100, 1.65m, null, null },
                    { 3, null, null, true, false, 1, 150, 1.47m, null, null },
                    { 4, null, null, true, false, 1, 200, 1.38m, null, null },
                    { 5, null, null, true, false, 1, 250, 1.3m, null, null },
                    { 6, null, null, true, false, 1, 300, 1.22m, null, null },
                    { 7, null, null, true, false, 1, 350, 1.16m, null, null },
                    { 8, null, null, true, false, 1, 400, 1.11m, null, null },
                    { 9, null, null, true, false, 1, 450, 1.07m, null, null },
                    { 10, null, null, true, false, 1, 500, 1.02m, null, null },
                    { 11, null, null, true, false, 1, 550, 0.98m, null, null },
                    { 12, null, null, true, false, 1, 600, 0.95m, null, null }
                });

            migrationBuilder.UpdateData(
                table: "MasterTransportationHeader",
                keyColumn: "Id",
                keyValue: 1,
                column: "FreightMin",
                value: 110m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MasterTransportationDetail",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MasterTransportationDetail",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MasterTransportationDetail",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MasterTransportationDetail",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MasterTransportationDetail",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MasterTransportationDetail",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MasterTransportationDetail",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MasterTransportationDetail",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MasterTransportationDetail",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MasterTransportationDetail",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MasterTransportationDetail",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MasterTransportationDetail",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "MasterTransportationHeader",
                keyColumn: "Id",
                keyValue: 1,
                column: "FreightMin",
                value: null);
        }
    }
}
