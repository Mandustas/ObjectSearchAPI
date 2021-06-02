using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class addlogpass_to_initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "7eb1dc0a-ae65-4709-84db-13937fd7a9e7", "40BD001563085FC35165329EA1FF5C5ECBDBBEEF", "e2bd68c4-a1d3-4fb7-8323-5d3f41db10b5", "Andrey" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "84e6106c-14fa-4e74-9541-26fa7732cb70", "40BD001563085FC35165329EA1FF5C5ECBDBBEEF", "8a5f0c87-0192-40b0-8421-aa47fb617a72", "Maxim" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "d1112464-de47-4f49-ad07-b9d0e758b0b8", "40BD001563085FC35165329EA1FF5C5ECBDBBEEF", "506c4ba2-c604-4b9d-a22d-6810b4bea74b", "Lead" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fefb7570-fdd0-4f45-96d8-8592221c18bd", "40BD001563085FC35165329EA1FF5C5ECBDBBEEF", "648fa8b6-c705-45c7-a519-f2ef622f0a5e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "d9530b41-fd3a-477d-91a5-e2c6f57a55df", null, "38032dd6-909e-4d38-a769-c0e7599c0305", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "d18ec43c-8f71-4220-a259-b27482ed9edb", null, "d680bc08-9dd6-4d2b-b101-77fefa45201b", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "836be7b0-f122-49a2-86f5-46b212175a23", null, "9a23c7ab-92c2-4d8d-80cc-262efdd99597", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73102c3f-8f05-4b26-a1f1-e4b5763abc9f", "qwerty123", "eefc4d3b-831d-47bf-b0df-d9169dede22d" });
        }
    }
}
