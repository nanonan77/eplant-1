using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class mappingtrans2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match9999_MappingTrans_MappingTransId",
                table: "Match9999");

            migrationBuilder.AlterColumn<Guid>(
                name: "MappingTransId",
                table: "Match9999",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "MasterRunningNumber",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Digit", "IsActive", "IsDelete", "Template", "Topic", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 6, null, null, 2, true, false, "MM{year}{temp1}-{running}", "MappingTrans", null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_Match9999_MappingTrans_MappingTransId",
                table: "Match9999",
                column: "MappingTransId",
                principalTable: "MappingTrans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match9999_MappingTrans_MappingTransId",
                table: "Match9999");

            migrationBuilder.DeleteData(
                table: "MasterRunningNumber",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<Guid>(
                name: "MappingTransId",
                table: "Match9999",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Match9999_MappingTrans_MappingTransId",
                table: "Match9999",
                column: "MappingTransId",
                principalTable: "MappingTrans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
