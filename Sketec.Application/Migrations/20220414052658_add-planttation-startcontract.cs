using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class addplanttationstartcontract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ContractEndDate",
                table: "Plantation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ContractStartDate",
                table: "Plantation",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractEndDate",
                table: "Plantation");

            migrationBuilder.DropColumn(
                name: "ContractStartDate",
                table: "Plantation");
        }
    }
}
