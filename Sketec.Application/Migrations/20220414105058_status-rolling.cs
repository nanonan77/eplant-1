using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class statusrolling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MasterConfiguration",
                columns: new[] { "Id", "Code", "ConfigurationKey", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsDelete", "Remarks", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 156, "Plan", "Status Rolling Plan", null, null, "Plan", true, false, null, null, null, "Plan" },
                    { 157, "Start", "Status Rolling Plan", null, null, "Start", true, false, null, null, null, "Start" },
                    { 158, "On progress", "Status Rolling Plan", null, null, "On progress", true, false, null, null, null, "On progress" },
                    { 160, "Done", "Status Rolling Plan", null, null, "Done", true, false, null, null, null, "Done" },
                    { 161, "Delayed", "Status Rolling Plan", null, null, "Delayed", true, false, null, null, null, "Delayed" },
                    { 162, "Cancel", "Status Rolling Plan", null, null, "Cancel", true, false, null, null, null, "Cancel" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 162);
        }
    }
}
