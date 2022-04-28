using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class runningnumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterRunningNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Template = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Digit = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterRunningNumber", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RunningNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    Temp1 = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Temp2 = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Temp3 = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Running = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunningNumber", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MasterRunningNumber",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Digit", "IsActive", "IsDelete", "Template", "Topic", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, null, 2, true, false, "PREN{year}{temp1}{running}", "PlantationRental", null, null },
                    { 2, null, null, 2, true, false, "PMOU{year}{temp1}{running}", "PlantationMOU", null, null },
                    { 3, null, null, 2, true, false, "PVIP{year}{temp1}{running}", "PlantationVIP", null, null },
                    { 4, null, null, 2, true, false, "{temp1}-{running}", "SubPlantation", null, null },
                    { 5, null, null, 5, true, false, "UN{year}-{running}", "Unplan", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterRunningNumber");

            migrationBuilder.DropTable(
                name: "RunningNumber");
        }
    }
}
