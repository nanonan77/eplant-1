using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class plantation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plantation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlantationId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContractYear = table.Column<int>(type: "int", nullable: true),
                    ContractMonth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Contract = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContractType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PIC = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ContractId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubDistrict = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Village = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RentalArea = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    ProductiveArea = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    PotentialArea = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Zone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MOUType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Seedling = table.Column<int>(type: "int", nullable: true),
                    NewRegistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plantation_NewRegist_NewRegistId",
                        column: x => x.NewRegistId,
                        principalTable: "NewRegist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubPlantation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlantationId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubPlantationId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Area = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    Seedling = table.Column<int>(type: "int", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    PlantYear = table.Column<int>(type: "int", nullable: true),
                    HarvestingMonth = table.Column<int>(type: "int", nullable: true),
                    HarvestingYear = table.Column<int>(type: "int", nullable: true),
                    Volume = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    VipPrice = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    ActualVolume = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    ActualVipPrice = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    NewPlantationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlantationId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubPlantation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubPlantation_Plantation_PlantationId1",
                        column: x => x.PlantationId1,
                        principalTable: "Plantation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plantation_NewRegistId",
                table: "Plantation",
                column: "NewRegistId");

            migrationBuilder.CreateIndex(
                name: "IX_SubPlantation_PlantationId1",
                table: "SubPlantation",
                column: "PlantationId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubPlantation");

            migrationBuilder.DropTable(
                name: "Plantation");
        }
    }
}
