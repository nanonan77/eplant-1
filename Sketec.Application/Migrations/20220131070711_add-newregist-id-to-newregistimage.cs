using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class addnewregistidtonewregistimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NewRegistId",
                table: "NewRegistImagePath",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SubNewRegistId",
                table: "NewRegistImagePath",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubNewRegistTestPlotId",
                table: "NewRegistImagePath",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewRegistId",
                table: "NewRegistImagePath");

            migrationBuilder.DropColumn(
                name: "SubNewRegistId",
                table: "NewRegistImagePath");

            migrationBuilder.DropColumn(
                name: "SubNewRegistTestPlotId",
                table: "NewRegistImagePath");
        }
    }
}
