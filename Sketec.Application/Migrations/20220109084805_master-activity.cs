using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class masteractivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterActivityType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleEN = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    TitleTH = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ActivityGroup = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Seq = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterActivityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterActivity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityEN = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    ActivityTH = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ActivityCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MasterActivityTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterActivity_MasterActivityType_MasterActivityTypeId",
                        column: x => x.MasterActivityTypeId,
                        principalTable: "MasterActivityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MasterActivityType",
                columns: new[] { "Id", "ActivityGroup", "CreatedBy", "CreatedDate", "IsActive", "IsDelete", "Seq", "TitleEN", "TitleTH", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "A", null, null, true, false, 1, "Rental", "ค่าเช่าที่ดิน", null, null },
                    { 2, "B", null, null, true, false, 2, "Site Preparation", "การเตรียมพื้นที่ปลูก", null, null },
                    { 3, "C", null, null, true, false, 3, "Planting", "การปลูก", null, null },
                    { 4, "D", null, null, true, false, 4, "Maintenance", "การดูแล", null, null },
                    { 5, "E", null, null, true, false, 5, "Harvesting", "ค่าตัด", null, null },
                    { 6, "F", null, null, true, false, 6, "Others", "ค่าบริหารการจัดการ", null, null },
                    { 7, "G", null, null, true, false, 7, "Est. Cost (Income)", "รายได้", null, null },
                    { 8, "H", null, null, true, false, 8, "Transportation", "ค่าขนส่ง", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterActivity_MasterActivityTypeId",
                table: "MasterActivity",
                column: "MasterActivityTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterActivity");

            migrationBuilder.DropTable(
                name: "MasterActivityType");
        }
    }
}
