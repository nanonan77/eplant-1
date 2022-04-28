using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class UpdatePlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RollingPlan_SubPlantation_SubPlantationId",
                table: "RollingPlan");

            migrationBuilder.DropIndex(
                name: "IX_RollingPlan_SubPlantationId",
                table: "RollingPlan");

            migrationBuilder.DropColumn(
                name: "SubPlantationId",
                table: "RollingPlan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SubPlantationId",
                table: "RollingPlan",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RollingPlan_SubPlantationId",
                table: "RollingPlan",
                column: "SubPlantationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RollingPlan_SubPlantation_SubPlantationId",
                table: "RollingPlan",
                column: "SubPlantationId",
                principalTable: "SubPlantation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
