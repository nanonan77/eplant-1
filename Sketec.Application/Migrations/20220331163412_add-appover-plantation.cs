using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class addappoverplantation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Approver1",
                table: "Plantation",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Approver2",
                table: "Plantation",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Approver3",
                table: "Plantation",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OverAllStatus",
                table: "Plantation",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusApprover1",
                table: "Plantation",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusApprover2",
                table: "Plantation",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusApprover3",
                table: "Plantation",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approver1",
                table: "Plantation");

            migrationBuilder.DropColumn(
                name: "Approver2",
                table: "Plantation");

            migrationBuilder.DropColumn(
                name: "Approver3",
                table: "Plantation");

            migrationBuilder.DropColumn(
                name: "OverAllStatus",
                table: "Plantation");

            migrationBuilder.DropColumn(
                name: "StatusApprover1",
                table: "Plantation");

            migrationBuilder.DropColumn(
                name: "StatusApprover2",
                table: "Plantation");

            migrationBuilder.DropColumn(
                name: "StatusApprover3",
                table: "Plantation");
        }
    }
}
