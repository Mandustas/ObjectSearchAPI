using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class UpdateMyUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "MiddleName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "13b89019-0a4e-4902-8b10-13dae2769ea0", "Александрович", "qwerty123", "656e1d20-8bda-4332-9220-0477dbb51eaf", "Andreog" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "16299180-38a0-4824-86be-def462bcc58a", "e1500919-5d3c-43c0-9ad4-35d5d0bf59cd" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f52e50e0-38ca-4d0a-b600-c7d4f0ca74ae", "62e92db4-e85d-4831-99bb-56a9308f1ec5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e021c2b0-6629-4e33-ab02-7bdc9a0c040e", "cdf70bc4-0284-4d25-9b28-b1fd78334a62" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "MiddleName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8cd590ad-4b9b-43a2-bfc0-ec9f52c8f453", "", null, "29b43822-4bbc-47a0-93de-8610507c0633", null });
        }
    }
}
