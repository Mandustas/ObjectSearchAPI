using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class AddPhotoTargetField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathImage",
                table: "Targets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 1,
                column: "PathImage",
                value: "https://games.mail.ru/hotbox/content_files/news/2021/06/09/567b8d118d4b425b8ee66deefd564617.jpg");

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 6,
                column: "PathImage",
                value: "https://a.d-cd.net/598af9s-960.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "91e23639-f968-46b0-b19f-0573489544a3", "6b08162a-dd4f-4524-a756-2b8a048aacce" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3f07a8a7-98ed-41a8-9bd5-10bda9852be0", "c89b49d8-16fc-4d87-905b-9a55b469b7e3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "18c21ec8-a02b-476b-b3fb-a6ea59b2a709", "09405b43-1cfa-46fd-8055-78d861176375" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "58cf038a-a814-4ef0-a69f-48bb34ce36b7", "60ca35e6-27dc-4e83-9d77-5de5adf6f40a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathImage",
                table: "Targets");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c3abe456-4ccb-4950-a24a-6a5c0ed1c4be", "38af0dce-9fcf-4def-a6ee-30e8d65531e5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f7dbbdfb-f305-4612-a8ef-7f9be9ae6484", "2aa779ed-f513-4982-85d8-dd8184208eff" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f1afd47b-5cb2-4b68-9483-89d8fcddad7b", "e1e28108-9811-4c74-ab45-f2df70956bc1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f04bbc89-22a9-4b65-b38f-ee17f22910e0", "d8ed7f61-ad6f-4673-a049-9b5dc0bd65c2" });
        }
    }
}
