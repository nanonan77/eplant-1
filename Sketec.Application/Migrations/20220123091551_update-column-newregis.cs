using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class updatecolumnnewregis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "SubNewRegistTestPlot",
                newName: "SubRegistId");

            migrationBuilder.RenameColumn(
                name: "HarvetingYear2",
                table: "NewRegist",
                newName: "HarvestingYear2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubRegistId",
                table: "SubNewRegistTestPlot",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "HarvestingYear2",
                table: "NewRegist",
                newName: "HarvetingYear2");
        }
    }
}
