using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class roleactivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleActivity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Page = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Activity = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleActivity", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RoleActivity",
                columns: new[] { "Id", "Activity", "CreatedBy", "CreatedDate", "IsActive", "IsDelete", "Page", "Role", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "All", null, null, true, false, "General", "O1", null, null },
                    { 75, "All", null, null, true, false, "Interface", "D", null, null },
                    { 74, "All", null, null, true, false, "Calendar", "D", null, null },
                    { 73, "All", null, null, true, false, "Rolling Plan", "D", null, null },
                    { 72, "All", null, null, true, false, "Create Unplan", "D", null, null },
                    { 71, "All", null, null, true, false, "Create Plantation", "D", null, null },
                    { 70, "All", null, null, true, false, "Plantation", "D", null, null },
                    { 69, "All", null, null, true, false, "Power App", "D", null, null },
                    { 68, "All", null, null, true, false, "Status Tracking", "D", null, null },
                    { 67, "All", null, null, true, false, "New Registration", "D", null, null },
                    { 66, "All", null, null, true, false, "Management", "D", null, null },
                    { 76, "All", null, null, true, false, "Create PO", "D", null, null },
                    { 65, "View", null, null, true, false, "Rolling Plan", "M", null, null },
                    { 63, "View", null, null, true, false, "Create Plantation", "M", null, null },
                    { 62, "All", null, null, true, false, "Plantation", "M", null, null },
                    { 61, "All", null, null, true, false, "Power App", "M", null, null },
                    { 60, "All", null, null, true, false, "Status Tracking", "M", null, null },
                    { 59, "All", null, null, true, false, "New Registration", "M", null, null },
                    { 58, "All", null, null, true, false, "Management", "M", null, null },
                    { 57, "All", null, null, true, false, "Dashboard", "M", null, null },
                    { 56, "All", null, null, true, false, "Report", "M", null, null },
                    { 55, "All", null, null, true, false, "General", "M", null, null },
                    { 54, "View", null, null, true, false, "Rolling Plan", "SS", null, null },
                    { 64, "View", null, null, true, false, "Create Unplan", "M", null, null },
                    { 53, "View", null, null, true, false, "Create Unplan", "SS", null, null },
                    { 77, "All", null, null, true, false, "Create Non-PO", "D", null, null },
                    { 79, "All", null, null, true, false, "Payment", "D", null, null },
                    { 101, "All", null, null, true, false, "Clone", "A", null, null },
                    { 100, "All", null, null, true, false, "Activity", "A", null, null },
                    { 99, "All", null, null, true, false, "Master", "A", null, null },
                    { 98, "All", null, null, true, false, "Mapping 99999", "A", null, null },
                    { 97, "All", null, null, true, false, "Payment", "A", null, null },
                    { 96, "All", null, null, true, false, "SAP-GI", "A", null, null },
                    { 95, "All", null, null, true, false, "Create Non-PO", "A", null, null },
                    { 94, "All", null, null, true, false, "Create PO", "A", null, null },
                    { 93, "All", null, null, true, false, "Interface", "A", null, null },
                    { 92, "All", null, null, true, false, "Calendar", "A", null, null },
                    { 78, "All", null, null, true, false, "SAP-GI", "D", null, null },
                    { 91, "All", null, null, true, false, "Rolling Plan", "A", null, null },
                    { 89, "All", null, null, true, false, "Create Plantation", "A", null, null },
                    { 88, "All", null, null, true, false, "Plantation", "A", null, null },
                    { 87, "All", null, null, true, false, "Power App", "A", null, null }
                });

            migrationBuilder.InsertData(
                table: "RoleActivity",
                columns: new[] { "Id", "Activity", "CreatedBy", "CreatedDate", "IsActive", "IsDelete", "Page", "Role", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 86, "All", null, null, true, false, "Status Tracking", "A", null, null },
                    { 85, "All", null, null, true, false, "New Registration", "A", null, null },
                    { 84, "All", null, null, true, false, "Management", "A", null, null },
                    { 83, "All", null, null, true, false, "Dashboard", "A", null, null },
                    { 82, "All", null, null, true, false, "Report", "A", null, null },
                    { 81, "All", null, null, true, false, "General", "A", null, null },
                    { 80, "All", null, null, true, false, "Mapping 99999", "D", null, null },
                    { 90, "All", null, null, true, false, "Create Unplan", "A", null, null },
                    { 102, "All", null, null, true, false, "Transportation", "A", null, null },
                    { 52, "View", null, null, true, false, "Create Plantation", "SS", null, null },
                    { 50, "All", null, null, true, false, "Power App", "SS", null, null },
                    { 23, "All", null, null, true, false, "SAP-GI", "O2", null, null },
                    { 22, "All", null, null, true, false, "Create Non-PO", "O2", null, null },
                    { 21, "All", null, null, true, false, "Create PO", "O2", null, null },
                    { 20, "All", null, null, true, false, "Interface", "O2", null, null },
                    { 19, "All", null, null, true, false, "Calendar", "O2", null, null },
                    { 18, "All", null, null, true, false, "Rolling Plan", "O2", null, null },
                    { 17, "All", null, null, true, false, "Create Unplan", "O2", null, null },
                    { 16, "All", null, null, true, false, "Create Plantation", "O2", null, null },
                    { 15, "All", null, null, true, false, "Plantation", "O2", null, null },
                    { 14, "All", null, null, true, false, "Power App", "O2", null, null },
                    { 24, "All", null, null, true, false, "Payment", "O2", null, null },
                    { 13, "All", null, null, true, false, "Status Tracking", "O2", null, null },
                    { 11, "All", null, null, true, false, "Management", "O2", null, null },
                    { 10, "All", null, null, true, false, "Dashboard", "O2", null, null },
                    { 9, "All", null, null, true, false, "Report", "O2", null, null },
                    { 8, "All", null, null, true, false, "General", "O2", null, null },
                    { 7, "All", null, null, true, false, "Power App", "O1", null, null },
                    { 6, "All", null, null, true, false, "Status Tracking", "O1", null, null },
                    { 5, "All", null, null, true, false, "New Registration", "O1", null, null },
                    { 4, "All", null, null, true, false, "Management", "O1", null, null },
                    { 3, "All", null, null, true, false, "Dashboard", "O1", null, null },
                    { 2, "All", null, null, true, false, "Report", "O1", null, null },
                    { 12, "All", null, null, true, false, "New Registration", "O2", null, null },
                    { 51, "All", null, null, true, false, "Plantation", "SS", null, null },
                    { 25, "All", null, null, true, false, "Mapping 99999", "O2", null, null },
                    { 27, "All", null, null, true, false, "Report", "S", null, null },
                    { 49, "All", null, null, true, false, "Status Tracking", "SS", null, null },
                    { 48, "All", null, null, true, false, "New Registration", "SS", null, null },
                    { 47, "All", null, null, true, false, "Management", "SS", null, null },
                    { 46, "All", null, null, true, false, "Dashboard", "SS", null, null },
                    { 45, "All", null, null, true, false, "Report", "SS", null, null }
                });

            migrationBuilder.InsertData(
                table: "RoleActivity",
                columns: new[] { "Id", "Activity", "CreatedBy", "CreatedDate", "IsActive", "IsDelete", "Page", "Role", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 44, "All", null, null, true, false, "General", "SS", null, null },
                    { 43, "All", null, null, true, false, "Mapping 99999", "S", null, null },
                    { 42, "All", null, null, true, false, "Payment", "S", null, null },
                    { 41, "All", null, null, true, false, "SAP-GI", "S", null, null },
                    { 40, "All", null, null, true, false, "Create Non-PO", "S", null, null },
                    { 26, "All", null, null, true, false, "General", "S", null, null },
                    { 39, "All", null, null, true, false, "Create PO", "S", null, null },
                    { 37, "All", null, null, true, false, "Calendar", "S", null, null },
                    { 36, "All", null, null, true, false, "Rolling Plan", "S", null, null },
                    { 35, "All", null, null, true, false, "Create Unplan", "S", null, null },
                    { 34, "All", null, null, true, false, "Create Plantation", "S", null, null },
                    { 33, "All", null, null, true, false, "Plantation", "S", null, null },
                    { 32, "All", null, null, true, false, "Power App", "S", null, null },
                    { 31, "All", null, null, true, false, "Status Tracking", "S", null, null },
                    { 30, "All", null, null, true, false, "New Registration", "S", null, null },
                    { 29, "All", null, null, true, false, "Management", "S", null, null },
                    { 28, "All", null, null, true, false, "Dashboard", "S", null, null },
                    { 38, "All", null, null, true, false, "Interface", "S", null, null },
                    { 103, "All", null, null, true, false, "User", "A", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleActivity");
        }
    }
}
