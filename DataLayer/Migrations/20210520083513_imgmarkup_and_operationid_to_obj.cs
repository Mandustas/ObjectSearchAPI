using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class imgmarkup_and_operationid_to_obj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetectedObjects_Images_ImageId",
                table: "DetectedObjects");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "DetectedObjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ImageMarkedUpId",
                table: "DetectedObjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OperationId",
                table: "DetectedObjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageMarkedUpId", "OperationId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageMarkedUpId", "OperationId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageMarkedUpId", "OperationId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageMarkedUpId", "OperationId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 5,
                column: "OperationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageMarkedUpId", "OperationId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_DetectedObjects_ImageMarkedUpId",
                table: "DetectedObjects",
                column: "ImageMarkedUpId");

            migrationBuilder.CreateIndex(
                name: "IX_DetectedObjects_OperationId",
                table: "DetectedObjects",
                column: "OperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetectedObjects_Images_ImageId",
                table: "DetectedObjects",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetectedObjects_Images_ImageMarkedUpId",
                table: "DetectedObjects",
                column: "ImageMarkedUpId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetectedObjects_Operations_OperationId",
                table: "DetectedObjects",
                column: "OperationId",
                principalTable: "Operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetectedObjects_Images_ImageId",
                table: "DetectedObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_DetectedObjects_Images_ImageMarkedUpId",
                table: "DetectedObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_DetectedObjects_Operations_OperationId",
                table: "DetectedObjects");

            migrationBuilder.DropIndex(
                name: "IX_DetectedObjects_ImageMarkedUpId",
                table: "DetectedObjects");

            migrationBuilder.DropIndex(
                name: "IX_DetectedObjects_OperationId",
                table: "DetectedObjects");

            migrationBuilder.DropColumn(
                name: "ImageMarkedUpId",
                table: "DetectedObjects");

            migrationBuilder.DropColumn(
                name: "OperationId",
                table: "DetectedObjects");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "DetectedObjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetectedObjects_Images_ImageId",
                table: "DetectedObjects",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
