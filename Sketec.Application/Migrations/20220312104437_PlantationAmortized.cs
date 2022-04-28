using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class PlantationAmortized : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlantationAmortized",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CashPaid = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    MonthlyRental = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    Interest = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    Depreciation = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    PlantationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantationAmortized", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantationAmortized_Plantation_PlantationId",
                        column: x => x.PlantationId,
                        principalTable: "Plantation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantationAmortized_PlantationId",
                table: "PlantationAmortized",
                column: "PlantationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantationAmortized");
        }
    }
}
