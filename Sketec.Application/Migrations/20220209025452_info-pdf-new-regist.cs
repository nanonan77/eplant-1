using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class infopdfnewregist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ContractEnd",
                table: "NewRegist",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ContractStart",
                table: "NewRegist",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalArea",
                table: "NewRegist",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractEnd",
                table: "NewRegist");

            migrationBuilder.DropColumn(
                name: "ContractStart",
                table: "NewRegist");

            migrationBuilder.DropColumn(
                name: "PhysicalArea",
                table: "NewRegist");
        }
    }
}
