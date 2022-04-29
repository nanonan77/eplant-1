using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class mappingtrans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MappingTransId",
                table: "Match9999",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MappingTrans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MappingTrans", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match9999_MappingTransId",
                table: "Match9999",
                column: "MappingTransId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match9999_MappingTrans_MappingTransId",
                table: "Match9999",
                column: "MappingTransId",
                principalTable: "MappingTrans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match9999_MappingTrans_MappingTransId",
                table: "Match9999");

            migrationBuilder.DropTable(
                name: "MappingTrans");

            migrationBuilder.DropIndex(
                name: "IX_Match9999_MappingTransId",
                table: "Match9999");

            migrationBuilder.DropColumn(
                name: "MappingTransId",
                table: "Match9999");
        }
    }
}
