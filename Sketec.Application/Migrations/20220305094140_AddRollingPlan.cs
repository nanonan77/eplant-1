using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class AddRollingPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RollingPlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Area = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    ActualArea = table.Column<decimal>(type: "decimal(22,2)", precision: 22, scale: 2, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    SubPlantationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterActivityId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RollingPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RollingPlan_MasterActivity_MasterActivityId",
                        column: x => x.MasterActivityId,
                        principalTable: "MasterActivity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RollingPlan_SubPlantation_SubPlantationId",
                        column: x => x.SubPlantationId,
                        principalTable: "SubPlantation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RollingPlan_MasterActivityId",
                table: "RollingPlan",
                column: "MasterActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_RollingPlan_SubPlantationId",
                table: "RollingPlan",
                column: "SubPlantationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RollingPlan");
        }
    }
}
