using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class reportto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase(
                collation: "Thai_CI_AS");

            migrationBuilder.AddColumn<string>(
                name: "ReportToEmail2",
                table: "User",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportToEmail3",
                table: "User",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportToEmail2",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ReportToEmail3",
                table: "User");

            migrationBuilder.AlterDatabase(
                oldCollation: "Thai_CI_AS");
        }
    }
}
