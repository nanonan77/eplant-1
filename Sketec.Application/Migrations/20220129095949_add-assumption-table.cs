using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class addassumptiontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assumption",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewRegistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectYear = table.Column<int>(type: "int", nullable: false),
                    GardenType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RentalArea = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    ProductiveAreaPercent = table.Column<int>(type: "int", nullable: true),
                    ProductiveArea = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    Rainfall = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SoilType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CuttingRound = table.Column<int>(type: "int", nullable: false),
                    DistanceToPlant = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    Mill = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AveragePrice = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    MtpPrice = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    FcPrice = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    CuttingCostType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuttingCost = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    FreightType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Freight = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assumption", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssumptionClone",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssumptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Clone = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Portion = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    Area = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    ProductTon = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssumptionClone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssumptionClone_Assumption_AssumptionId",
                        column: x => x.AssumptionId,
                        principalTable: "Assumption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssumptionYield",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssumptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Round = table.Column<int>(type: "int", nullable: false),
                    Yield = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssumptionYield", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssumptionYield_Assumption_AssumptionId",
                        column: x => x.AssumptionId,
                        principalTable: "Assumption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssumptionClone_AssumptionId",
                table: "AssumptionClone",
                column: "AssumptionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssumptionYield_AssumptionId",
                table: "AssumptionYield",
                column: "AssumptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssumptionClone");

            migrationBuilder.DropTable(
                name: "AssumptionYield");

            migrationBuilder.DropTable(
                name: "Assumption");
        }
    }
}
