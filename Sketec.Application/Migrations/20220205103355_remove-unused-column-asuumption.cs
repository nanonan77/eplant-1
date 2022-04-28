using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class removeunusedcolumnasuumption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractType",
                table: "Assumption");

            migrationBuilder.DropColumn(
                name: "Rainfall",
                table: "Assumption");

            migrationBuilder.DropColumn(
                name: "SoilType",
                table: "Assumption");

            migrationBuilder.CreateIndex(
                name: "IX_Assumption_NewRegistId",
                table: "Assumption",
                column: "NewRegistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assumption_NewRegist_NewRegistId",
                table: "Assumption",
                column: "NewRegistId",
                principalTable: "NewRegist",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assumption_NewRegist_NewRegistId",
                table: "Assumption");

            migrationBuilder.DropIndex(
                name: "IX_Assumption_NewRegistId",
                table: "Assumption");

            migrationBuilder.AddColumn<string>(
                name: "ContractType",
                table: "Assumption",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rainfall",
                table: "Assumption",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoilType",
                table: "Assumption",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
