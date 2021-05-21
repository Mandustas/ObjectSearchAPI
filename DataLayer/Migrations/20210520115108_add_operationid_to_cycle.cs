using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class add_operationid_to_cycle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OperationId",
                table: "Cycles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Cycles",
                keyColumn: "Id",
                keyValue: 1,
                column: "OperationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Cycles",
                keyColumn: "Id",
                keyValue: 2,
                column: "OperationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "CycleId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Cycles_OperationId",
                table: "Cycles",
                column: "OperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cycles_Operations_OperationId",
                table: "Cycles",
                column: "OperationId",
                principalTable: "Operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cycles_Operations_OperationId",
                table: "Cycles");

            migrationBuilder.DropIndex(
                name: "IX_Cycles_OperationId",
                table: "Cycles");

            migrationBuilder.DropColumn(
                name: "OperationId",
                table: "Cycles");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "CycleId",
                value: 1);
        }
    }
}
