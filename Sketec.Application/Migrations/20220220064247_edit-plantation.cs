using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class editplantation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubPlantation_Plantation_PlantationId1",
                table: "SubPlantation");

            migrationBuilder.DropIndex(
                name: "IX_SubPlantation_PlantationId1",
                table: "SubPlantation");

            migrationBuilder.DropColumn(
                name: "NewPlantationId",
                table: "SubPlantation");

            migrationBuilder.DropColumn(
                name: "PlantationId1",
                table: "SubPlantation");

            migrationBuilder.RenameColumn(
                name: "SubPlantationId",
                table: "SubPlantation",
                newName: "SubPlantationNo");

            migrationBuilder.RenameColumn(
                name: "PlantationId",
                table: "Plantation",
                newName: "PlantationNo");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlantationId",
                table: "SubPlantation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlantationNo",
                table: "SubPlantation",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubPlantation_PlantationId",
                table: "SubPlantation",
                column: "PlantationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubPlantation_Plantation_PlantationId",
                table: "SubPlantation",
                column: "PlantationId",
                principalTable: "Plantation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubPlantation_Plantation_PlantationId",
                table: "SubPlantation");

            migrationBuilder.DropIndex(
                name: "IX_SubPlantation_PlantationId",
                table: "SubPlantation");

            migrationBuilder.DropColumn(
                name: "PlantationNo",
                table: "SubPlantation");

            migrationBuilder.RenameColumn(
                name: "SubPlantationNo",
                table: "SubPlantation",
                newName: "SubPlantationId");

            migrationBuilder.RenameColumn(
                name: "PlantationNo",
                table: "Plantation",
                newName: "PlantationId");

            migrationBuilder.AlterColumn<string>(
                name: "PlantationId",
                table: "SubPlantation",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "NewPlantationId",
                table: "SubPlantation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PlantationId1",
                table: "SubPlantation",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubPlantation_PlantationId1",
                table: "SubPlantation",
                column: "PlantationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SubPlantation_Plantation_PlantationId1",
                table: "SubPlantation",
                column: "PlantationId1",
                principalTable: "Plantation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
