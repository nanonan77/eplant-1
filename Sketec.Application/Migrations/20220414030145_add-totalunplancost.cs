using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class addtotalunplancost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                table: "Unplan",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "Unplan");
        }
    }
}
