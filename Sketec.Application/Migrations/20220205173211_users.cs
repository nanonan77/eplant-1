using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalArea",
                table: "NewRegist",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PlanVolume",
                table: "NewRegist",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clearing1Area",
                table: "NewRegist",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    EmpCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    OrganizationName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AdAcount = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    T_FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    E_FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PositionName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BusinessUnit = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Div_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Dep_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SubDep_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sec_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmployeeOrganizationRelationTypeId = table.Column<int>(type: "int", nullable: true),
                    EmpOrgLevel = table.Column<int>(type: "int", nullable: true),
                    CctR_Dept = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CctR_Over = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ManagerEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Team = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsLocal = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.UniqueConstraint("AK_User_Username", x => x.Username);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalArea",
                table: "NewRegist",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(22,2)",
                oldPrecision: 22,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PlanVolume",
                table: "NewRegist",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(22,2)",
                oldPrecision: 22,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clearing1Area",
                table: "NewRegist",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(22,2)",
                oldPrecision: 22,
                oldScale: 2,
                oldNullable: true);
        }
    }
}
