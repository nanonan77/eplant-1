using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class changestructureexpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseActivity");

            migrationBuilder.AddColumn<decimal>(
                name: "YearCost1",
                table: "Expense",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "YearCost10",
                table: "Expense",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "YearCost11",
                table: "Expense",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "YearCost12",
                table: "Expense",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "YearCost13",
                table: "Expense",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "YearCost14",
                table: "Expense",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "YearCost15",
                table: "Expense",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "YearCost2",
                table: "Expense",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "YearCost3",
                table: "Expense",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "YearCost4",
                table: "Expense",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "YearCost5",
                table: "Expense",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "YearCost6",
                table: "Expense",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "YearCost7",
                table: "Expense",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "YearCost8",
                table: "Expense",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "YearCost9",
                table: "Expense",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearCost1",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "YearCost10",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "YearCost11",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "YearCost12",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "YearCost13",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "YearCost14",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "YearCost15",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "YearCost2",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "YearCost3",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "YearCost4",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "YearCost5",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "YearCost6",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "YearCost7",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "YearCost8",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "YearCost9",
                table: "Expense");

            migrationBuilder.CreateTable(
                name: "ExpenseActivity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpenseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseActivity_Expense_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseActivity_ExpenseId",
                table: "ExpenseActivity",
                column: "ExpenseId");
        }
    }
}
