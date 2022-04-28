using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class NewRegist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "NewRegist",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RegistID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Subdistrict = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Village = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Plot = table.Column<int>(type: "int", precision: 22, scale: 2, nullable: true),
                    TotalArea = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Clearing1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 22, scale: 2, nullable: true),
                    Clearing1Area = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Clearing2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Contract = table.Column<int>(type: "int", nullable: true),
                    PIC = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Generated = table.Column<int>(type: "int", nullable: true),
                    Interface = table.Column<int>(type: "int", nullable: true),
                    ItemType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Path = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Zone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Verifier = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MOUType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Seedling = table.Column<int>(type: "int", nullable: true),
                    HarvestingYear1 = table.Column<int>(type: "int", nullable: true),
                    HarvestingMonth1 = table.Column<int>(type: "int", nullable: true),
                    HarvetingYear2 = table.Column<int>(type: "int", nullable: true),
                    HarvestingMonth2 = table.Column<int>(type: "int", precision: 22, scale: 2, nullable: true),
                    MOUPrice = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    PlanVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewRegist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubNewRegist",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubRegistID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NumSoilType = table.Column<int>(type: "int", nullable: true),
                    SoilType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandUse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accessibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Water = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumSoilTest = table.Column<int>(type: "int", nullable: true),
                    Rainfall = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DeedArea = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ItemType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantYear = table.Column<int>(type: "int", nullable: true),
                    HarvestingMonth = table.Column<int>(type: "int", nullable: true),
                    HarvestingYear = table.Column<int>(type: "int", nullable: true),
                    Volume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VIPPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewRegistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubNewRegist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubNewRegist_NewRegist_NewRegistId",
                        column: x => x.NewRegistId,
                        principalTable: "NewRegist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubNewRegistTestPlot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubnewregistTestID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoilType = table.Column<int>(type: "int", nullable: true),
                    Depth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    soillfloorDepth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GravelDepth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PH30 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PH60 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EC30 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EC60 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Dot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubNewRegistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubNewRegistTestPlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubNewRegistTestPlot_SubNewRegist_SubNewRegistId",
                        column: x => x.SubNewRegistId,
                        principalTable: "SubNewRegist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubNewRegist_NewRegistId",
                table: "SubNewRegist",
                column: "NewRegistId");

            migrationBuilder.CreateIndex(
                name: "IX_SubNewRegistTestPlot_SubNewRegistId",
                table: "SubNewRegistTestPlot",
                column: "SubNewRegistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubNewRegistTestPlot");

            migrationBuilder.DropTable(
                name: "SubNewRegist");

            migrationBuilder.DropTable(
                name: "NewRegist");

        }
    }
}
