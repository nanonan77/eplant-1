using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class UpdateRollingPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlantationId",
                table: "RollingPlan",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubPlantationNo",
                table: "RollingPlan",
                type: "varchar(1000)",
                unicode: false,
                maxLength: 1000,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RollingPlan_PlantationId",
                table: "RollingPlan",
                column: "PlantationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RollingPlan_Plantation_PlantationId",
                table: "RollingPlan",
                column: "PlantationId",
                principalTable: "Plantation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RollingPlan_Plantation_PlantationId",
                table: "RollingPlan");

            migrationBuilder.DropIndex(
                name: "IX_RollingPlan_PlantationId",
                table: "RollingPlan");

            migrationBuilder.DropColumn(
                name: "PlantationId",
                table: "RollingPlan");

            migrationBuilder.DropColumn(
                name: "SubPlantationNo",
                table: "RollingPlan");
        }
    }
}
