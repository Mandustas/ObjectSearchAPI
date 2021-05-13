using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class fk_coordinatorid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CoordinatorId",
                table: "Operations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Cycles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 5, 9, 7, 24, 48, 278, DateTimeKind.Local).AddTicks(3473), new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473) });

            migrationBuilder.UpdateData(
                table: "Cycles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 5, 9, 7, 24, 48, 278, DateTimeKind.Local).AddTicks(3473), new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473) });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeCreate",
                value: new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeCreate",
                value: new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeCreate",
                value: new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 1,
                column: "LostTime",
                value: new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 2,
                column: "LostTime",
                value: new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 3,
                column: "LostTime",
                value: new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 4,
                column: "LostTime",
                value: new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 5,
                column: "LostTime",
                value: new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 6,
                column: "LostTime",
                value: new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473));

            migrationBuilder.CreateIndex(
                name: "IX_Operations_CoordinatorId",
                table: "Operations",
                column: "CoordinatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Users_CoordinatorId",
                table: "Operations",
                column: "CoordinatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Users_CoordinatorId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Operations_CoordinatorId",
                table: "Operations");

            migrationBuilder.AlterColumn<int>(
                name: "CoordinatorId",
                table: "Operations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Cycles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 5, 8, 22, 36, 11, 636, DateTimeKind.Local).AddTicks(8237), new DateTime(2021, 5, 8, 22, 16, 11, 636, DateTimeKind.Local).AddTicks(7854) });

            migrationBuilder.UpdateData(
                table: "Cycles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 5, 8, 22, 36, 11, 636, DateTimeKind.Local).AddTicks(8708), new DateTime(2021, 5, 8, 22, 16, 11, 636, DateTimeKind.Local).AddTicks(8703) });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeCreate",
                value: new DateTime(2021, 5, 8, 22, 16, 11, 637, DateTimeKind.Local).AddTicks(634));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeCreate",
                value: new DateTime(2021, 5, 8, 22, 16, 11, 637, DateTimeKind.Local).AddTicks(1347));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeCreate",
                value: new DateTime(2021, 5, 8, 22, 16, 11, 637, DateTimeKind.Local).AddTicks(1351));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 5, 8, 22, 16, 11, 636, DateTimeKind.Local).AddTicks(4290));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 5, 8, 22, 16, 11, 636, DateTimeKind.Local).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 5, 8, 22, 16, 11, 636, DateTimeKind.Local).AddTicks(5035));

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 1,
                column: "LostTime",
                value: new DateTime(2021, 5, 8, 22, 16, 11, 633, DateTimeKind.Local).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 2,
                column: "LostTime",
                value: new DateTime(2021, 5, 8, 22, 16, 11, 634, DateTimeKind.Local).AddTicks(6951));

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 3,
                column: "LostTime",
                value: new DateTime(2021, 5, 8, 22, 16, 11, 634, DateTimeKind.Local).AddTicks(6963));

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 4,
                column: "LostTime",
                value: new DateTime(2021, 5, 8, 22, 16, 11, 634, DateTimeKind.Local).AddTicks(6966));

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 5,
                column: "LostTime",
                value: new DateTime(2021, 5, 8, 22, 16, 11, 634, DateTimeKind.Local).AddTicks(6967));

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 6,
                column: "LostTime",
                value: new DateTime(2021, 5, 8, 22, 16, 11, 634, DateTimeKind.Local).AddTicks(6969));
        }
    }
}
