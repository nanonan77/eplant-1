using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class mapping9999 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mapping9999",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    CostCenter = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CostElement = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PurchaseOrderText = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RefDocumentNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PostingRow = table.Column<int>(type: "int", nullable: false),
                    ValCOAreaCrcy = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: false),
                    RefCompanyCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FiscalYear = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mapping9999", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Match9999",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match9999", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Match9999Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mapping9999Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValCOAreaCrcy = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchData_Mapping9999_Mapping9999Id",
                        column: x => x.Mapping9999Id,
                        principalTable: "Mapping9999",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchData_Match9999_Match9999Id",
                        column: x => x.Match9999Id,
                        principalTable: "Match9999",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchPlantation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Match9999Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlantationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MasterActivityId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchPlantation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchPlantation_MasterActivity_MasterActivityId",
                        column: x => x.MasterActivityId,
                        principalTable: "MasterActivity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchPlantation_Match9999_Match9999Id",
                        column: x => x.Match9999Id,
                        principalTable: "Match9999",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchPlantation_Plantation_PlantationId",
                        column: x => x.PlantationId,
                        principalTable: "Plantation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchData_Mapping9999Id",
                table: "MatchData",
                column: "Mapping9999Id");

            migrationBuilder.CreateIndex(
                name: "IX_MatchData_Match9999Id",
                table: "MatchData",
                column: "Match9999Id");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlantation_MasterActivityId",
                table: "MatchPlantation",
                column: "MasterActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlantation_Match9999Id",
                table: "MatchPlantation",
                column: "Match9999Id");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlantation_PlantationId",
                table: "MatchPlantation",
                column: "PlantationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchData");

            migrationBuilder.DropTable(
                name: "MatchPlantation");

            migrationBuilder.DropTable(
                name: "Mapping9999");

            migrationBuilder.DropTable(
                name: "Match9999");
        }
    }
}
