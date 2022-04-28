using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class fixmasterconfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConfiguratioKey",
                table: "MasterConfiguration",
                newName: "ConfigurationKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConfigurationKey",
                table: "MasterConfiguration",
                newName: "ConfiguratioKey");
        }
    }
}
