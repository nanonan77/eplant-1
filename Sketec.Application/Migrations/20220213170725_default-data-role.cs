using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class defaultdatarole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Mill",
                table: "FeasibilityPrice",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "FeasibilityPrice",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "IsDelete", "Mill", "Price", "PriceType", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 16, null, null, true, false, "โรงสับพันธมิตร (บริษัท ที.แอล.เอส.ยูคาลิปตัส 2005 จำกัด)", 1397m, "MTP Agent", null, null });

            migrationBuilder.InsertData(
                table: "MasterConfiguration",
                columns: new[] { "Id", "Code", "ConfigurationKey", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsDelete", "Remarks", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 103, "1", "Role", null, null, "Operation (ทีมหาพื้นที่ , ทีม QC)", true, false, null, null, null, "O1" },
                    { 104, "2", "Role", null, null, "Operation (ทีมปลูก)", true, false, null, null, null, "O2" },
                    { 105, "3", "Role", null, null, "Supervisor", true, false, null, null, null, "S" },
                    { 106, "4", "Role", null, null, "Section manager", true, false, null, null, null, "SS" },
                    { 107, "5", "Role", null, null, "Department manager", true, false, null, null, null, "M" },
                    { 108, "6", "Role", null, null, "Document", true, false, null, null, null, "D" },
                    { 109, "7", "Role", null, null, "Admin", true, false, null, null, null, "A" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FeasibilityPrice",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.AlterColumn<string>(
                name: "Mill",
                table: "FeasibilityPrice",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
