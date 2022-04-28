using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class costcenter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterCostCenter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Zone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Plant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CostCenter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterCostCenter", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MasterCostCenter",
                columns: new[] { "Id", "ContractType", "CostCenter", "CreatedBy", "CreatedDate", "IsActive", "IsDelete", "Plant", "UpdatedBy", "UpdatedDate", "Zone" },
                values: new object[,]
                {
                    { 1, "Rental", "0760-99999", null, null, true, false, "7611", null, null, "West" },
                    { 2, "Rental", "0760-99999", null, null, true, false, "7611", null, null, "North" },
                    { 3, "Rental", "0762-99999", null, null, true, false, "7612", null, null, "Northeast" },
                    { 4, "MOU", "0761-99999", null, null, true, false, "7611", null, null, "West" },
                    { 5, "MOU", "0761-99999", null, null, true, false, "7611", null, null, "North" },
                    { 6, "MOU", "0761-99999", null, null, true, false, "7612", null, null, "Northeast" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterCostCenter");
        }
    }
}
