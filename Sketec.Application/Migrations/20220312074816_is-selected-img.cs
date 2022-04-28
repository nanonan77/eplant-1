using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class isselectedimg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelectedStep2",
                table: "NewRegistImagePath",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelectedStep3",
                table: "NewRegistImagePath",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelectedStep2",
                table: "NewRegistImagePath");

            migrationBuilder.DropColumn(
                name: "IsSelectedStep3",
                table: "NewRegistImagePath");
        }
    }
}
