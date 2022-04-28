using Microsoft.EntityFrameworkCore.Migrations;

namespace Sketec.Application.Migrations
{
    public partial class updateconfigstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_MasterActivity_MasterActivityId",
                table: "Expense");

            migrationBuilder.DropIndex(
                name: "IX_Expense_MasterActivityId",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "MasterActivityId",
                table: "Expense");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ExpenseActivity",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ExpenseActivity",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "ExpenseActivity",
                type: "decimal(22,2)",
                precision: 22,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Expense",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Expense",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "ทีมหาพื้นที่");

            migrationBuilder.UpdateData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "ทีมปลูก");

            migrationBuilder.UpdateData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "ทีม QC");

            migrationBuilder.UpdateData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 13,
                column: "Description",
                value: "ทีมหาพื้นที่");

            migrationBuilder.UpdateData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 14,
                column: "Description",
                value: "ทีมปลูก");

            migrationBuilder.UpdateData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "Description", "Value" },
                values: new object[] { "Approver", "P" });

            migrationBuilder.InsertData(
                table: "MasterConfiguration",
                columns: new[] { "Id", "Code", "ConfigurationKey", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsDelete", "Remarks", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[] { 110, "8", "Role", null, null, "Admin", true, false, null, null, null, "A" });

            migrationBuilder.CreateIndex(
                name: "IX_Expense_ActivityId",
                table: "Expense",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_MasterActivity_ActivityId",
                table: "Expense",
                column: "ActivityId",
                principalTable: "MasterActivity",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_MasterActivity_ActivityId",
                table: "Expense");

            migrationBuilder.DropIndex(
                name: "IX_Expense_ActivityId",
                table: "Expense");

            migrationBuilder.DeleteData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ExpenseActivity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ExpenseActivity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "ExpenseActivity",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(22,2)",
                oldPrecision: 22,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Expense",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Expense",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterActivityId",
                table: "Expense",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "Submitted");

            migrationBuilder.UpdateData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "Verify Cost");

            migrationBuilder.UpdateData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "Verify Feas.");

            migrationBuilder.UpdateData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 13,
                column: "Description",
                value: "Final Negotiate");

            migrationBuilder.UpdateData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 14,
                column: "Description",
                value: "Contract Signed");

            migrationBuilder.UpdateData(
                table: "MasterConfiguration",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "Description", "Value" },
                values: new object[] { "Admin", "A" });

            migrationBuilder.CreateIndex(
                name: "IX_Expense_MasterActivityId",
                table: "Expense",
                column: "MasterActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_MasterActivity_MasterActivityId",
                table: "Expense",
                column: "MasterActivityId",
                principalTable: "MasterActivity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
