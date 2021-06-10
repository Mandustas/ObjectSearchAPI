using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class operid_to_mission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OperationId",
                table: "Missions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 1,
                column: "OperationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 2,
                column: "OperationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserStatusId" },
                values: new object[] { "d9530b41-fd3a-477d-91a5-e2c6f57a55df", "38032dd6-909e-4d38-a769-c0e7599c0305", 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserStatusId" },
                values: new object[] { "d18ec43c-8f71-4220-a259-b27482ed9edb", "d680bc08-9dd6-4d2b-b101-77fefa45201b", 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserStatusId" },
                values: new object[] { "836be7b0-f122-49a2-86f5-46b212175a23", "9a23c7ab-92c2-4d8d-80cc-262efdd99597", 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserStatusId" },
                values: new object[] { "73102c3f-8f05-4b26-a1f1-e4b5763abc9f", "eefc4d3b-831d-47bf-b0df-d9169dede22d", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Missions_OperationId",
                table: "Missions",
                column: "OperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Operations_OperationId",
                table: "Missions",
                column: "OperationId",
                principalTable: "Operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Operations_OperationId",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Missions_OperationId",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "OperationId",
                table: "Missions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserStatusId" },
                values: new object[] { "528edd57-71c1-4d04-867b-bd24beb368f3", "62e869d9-1b6d-47a3-b81b-2f0043d100e7", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserStatusId" },
                values: new object[] { "9beca2c0-b161-420f-952e-9e03eda43884", "26321d0a-fc03-4445-8d2c-4a3b144f5b9e", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserStatusId" },
                values: new object[] { "b32a4ab0-11a3-4a4f-8868-a3a1e8900274", "146a27a1-3be1-40cd-af9a-76f67c90d0d2", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserStatusId" },
                values: new object[] { "15e20992-7f50-4e5d-8bfe-fb21c7519c4b", "98c76872-ec3c-454d-b0a1-c64a8798a9ec", 1 });
        }
    }
}
