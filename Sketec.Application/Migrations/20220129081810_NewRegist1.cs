using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class NewRegist1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Meter",
                table: "NewRegist",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Ngan",
                table: "NewRegist",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerLastname",
                table: "NewRegist",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "NewRegist",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerTel",
                table: "NewRegist",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Rai",
                table: "NewRegist",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Meter",
                table: "NewRegist");

            migrationBuilder.DropColumn(
                name: "Ngan",
                table: "NewRegist");

            migrationBuilder.DropColumn(
                name: "OwnerLastname",
                table: "NewRegist");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "NewRegist");

            migrationBuilder.DropColumn(
                name: "OwnerTel",
                table: "NewRegist");

            migrationBuilder.DropColumn(
                name: "Rai",
                table: "NewRegist");
        }
    }
}
