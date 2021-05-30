using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class statuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Кандидат в участники");

            migrationBuilder.UpdateData(
                table: "UserStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Доброволец");

            migrationBuilder.InsertData(
                table: "UserStatuses",
                columns: new[] { "Id", "Title" },
                values: new object[] { 3, "Сотрудник" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "528edd57-71c1-4d04-867b-bd24beb368f3", "62e869d9-1b6d-47a3-b81b-2f0043d100e7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9beca2c0-b161-420f-952e-9e03eda43884", "26321d0a-fc03-4445-8d2c-4a3b144f5b9e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b32a4ab0-11a3-4a4f-8868-a3a1e8900274", "146a27a1-3be1-40cd-af9a-76f67c90d0d2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "15e20992-7f50-4e5d-8bfe-fb21c7519c4b", "98c76872-ec3c-454d-b0a1-c64a8798a9ec" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "UserStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Активен");

            migrationBuilder.UpdateData(
                table: "UserStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Неактивен");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3861cc0a-df00-41f0-a3bf-3bf052892d63", "349afde9-e2f2-469a-b283-6550776db246" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9b997da0-3884-4481-b889-644575fde064", "51fa7c33-847b-45e4-911b-99b324a95aa7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "99e75160-6b93-4958-82fc-34814d7c19c6", "5862cf7d-b274-490d-a03e-9373c33b56db" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "13b89019-0a4e-4902-8b10-13dae2769ea0", "656e1d20-8bda-4332-9220-0477dbb51eaf" });
        }
    }
}
