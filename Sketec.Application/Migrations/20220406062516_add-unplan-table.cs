using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class addunplantable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantation_NewRegist_NewRegistId",
                table: "Plantation");

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

            migrationBuilder.AddColumn<Guid>(
                name: "UnplanId",
                table: "Expense",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Unplan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlantationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewRegistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnplanNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverAllStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approver1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusApprover1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approver2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusApprover2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approver3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusApprover3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLatest = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unplan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unplan_NewRegist_NewRegistId",
                        column: x => x.NewRegistId,
                        principalTable: "NewRegist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Unplan_Plantation_PlantationId",
                        column: x => x.PlantationId,
                        principalTable: "Plantation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expense_UnplanId",
                table: "Expense",
                column: "UnplanId");

            migrationBuilder.CreateIndex(
                name: "IX_Unplan_NewRegistId",
                table: "Unplan",
                column: "NewRegistId");

            migrationBuilder.CreateIndex(
                name: "IX_Unplan_PlantationId",
                table: "Unplan",
                column: "PlantationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Unplan_UnplanId",
                table: "Expense",
                column: "UnplanId",
                principalTable: "Unplan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantation_NewRegist_NewRegistId",
                table: "Plantation",
                column: "NewRegistId",
                principalTable: "NewRegist",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Unplan_UnplanId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantation_NewRegist_NewRegistId",
                table: "Plantation");

            migrationBuilder.DropTable(
                name: "Unplan");

            migrationBuilder.DropIndex(
                name: "IX_Expense_UnplanId",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "UnplanId",
                table: "Expense");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Plantation_NewRegist_NewRegistId",
                table: "Plantation",
                column: "NewRegistId",
                principalTable: "NewRegist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
