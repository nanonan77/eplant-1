using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class changecolumntypeassumption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CuttingCostType",
                table: "Assumption");

            migrationBuilder.DropColumn(
                name: "FreightType",
                table: "Assumption");

            migrationBuilder.AddColumn<int>(
                name: "CuttingCostTypeId",
                table: "Assumption",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FreightTypeId",
                table: "Assumption",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Assumption_CuttingCostTypeId",
                table: "Assumption",
                column: "CuttingCostTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Assumption_FreightTypeId",
                table: "Assumption",
                column: "FreightTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assumption_MasterActivity_CuttingCostTypeId",
                table: "Assumption",
                column: "CuttingCostTypeId",
                principalTable: "MasterActivity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assumption_MasterActivity_FreightTypeId",
                table: "Assumption",
                column: "FreightTypeId",
                principalTable: "MasterActivity",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assumption_MasterActivity_CuttingCostTypeId",
                table: "Assumption");

            migrationBuilder.DropForeignKey(
                name: "FK_Assumption_MasterActivity_FreightTypeId",
                table: "Assumption");

            migrationBuilder.DropIndex(
                name: "IX_Assumption_CuttingCostTypeId",
                table: "Assumption");

            migrationBuilder.DropIndex(
                name: "IX_Assumption_FreightTypeId",
                table: "Assumption");

            migrationBuilder.DropColumn(
                name: "CuttingCostTypeId",
                table: "Assumption");

            migrationBuilder.DropColumn(
                name: "FreightTypeId",
                table: "Assumption");

            migrationBuilder.AddColumn<string>(
                name: "CuttingCostType",
                table: "Assumption",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreightType",
                table: "Assumption",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
