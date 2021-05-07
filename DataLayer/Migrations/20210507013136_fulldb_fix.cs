using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class fulldb_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Targets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "Description", "EndDate", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam nec volutpat elit. Pellentesque sit amet ullamcorper leo. In dictum hendrerit tempus. Mauris ultrices ante eu leo elementum, in pretium neque semper. ", new DateTime(2021, 5, 7, 4, 51, 36, 4, DateTimeKind.Local).AddTicks(9522), new DateTime(2021, 5, 7, 4, 31, 36, 4, DateTimeKind.Local).AddTicks(9132), "Облет леса" },
                    { 2, "Ut maximus aliquam leo, eu congue neque consequat eget. Integer non nulla augue. Vestibulum odio est, posuere ac orci sed, mollis dapibus massa. Nullam mattis neque ac scelerisque euismod. Aliquam pretium nisi sed leo iaculis molestie ut ac erat.", new DateTime(2021, 5, 7, 4, 51, 36, 5, DateTimeKind.Local).AddTicks(56), new DateTime(2021, 5, 7, 4, 31, 36, 5, DateTimeKind.Local).AddTicks(53), "Облет поля" }
                });

            migrationBuilder.InsertData(
                table: "DetectedObjects",
                columns: new[] { "Id", "Description", "ImageId", "MissionId", "ObjectStatusId", "Title" },
                values: new object[,]
                {
                    { 1, "На Севере дубравы", null, null, null, "Кот на дубе" },
                    { 2, "На Юго-Западе леса", null, null, null, "Кот в камышах" },
                    { 3, "На Востоке", null, null, null, "Кот в сапогах" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CycleId", "Path", "QtyFindObject", "QtyVerifiedObject", "TimeCreate" },
                values: new object[,]
                {
                    { 1, null, "https://thumbs.dreamstime.com/b/%D0%BB%D0%B5%D1%81-%D1%81%D0%B2%D0%B5%D1%80%D1%85%D1%83-%D0%BB%D0%B5%D1%82%D0%BE%D0%BC-%D0%B2%D0%B8%D0%B4-%D1%81-%D0%B2%D0%BE%D0%B7%D0%B4%D1%83%D1%85%D0%B0-%D0%BE%D0%B1%D0%BE%D0%B5%D0%B2-%D0%BB%D0%B5%D1%81%D0%B0-153275483.jpg", 1, 1, new DateTime(2021, 5, 7, 4, 31, 36, 5, DateTimeKind.Local).AddTicks(2023) },
                    { 2, null, "https://i.pinimg.com/736x/c5/dc/53/c5dc53070960ee2ea4fb07ed2ff325b3.jpg", 1, 1, new DateTime(2021, 5, 7, 4, 31, 36, 5, DateTimeKind.Local).AddTicks(2400) },
                    { 3, null, "https://envato-shoebox-0.imgix.net/4c17/f9ef-0fc2-4571-8819-373327ab564c/trip+mix-12.jpg?auto=compress%2Cformat&fit=max&mark=https%3A%2F%2Felements-assets.envato.com%2Fstatic%2Fwatermark2.png&markalign=center%2Cmiddle&markalpha=18&w=700&s=e56aa60d45ab74037c9f43d3a088bbdf", 1, 1, new DateTime(2021, 5, 7, 4, 31, 36, 5, DateTimeKind.Local).AddTicks(2404) }
                });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 3, null },
                    { 4, null },
                    { 1, null },
                    { 2, null }
                });

            migrationBuilder.InsertData(
                table: "ObjectStatuses",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Не распределен" },
                    { 2, "Распределен" },
                    { 3, "Проверен" }
                });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "CoordinatorId", "Date", "IsSuccess", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 5, 7, 4, 31, 36, 4, DateTimeKind.Local).AddTicks(5182), false, "Поиск кота" },
                    { 2, 1, new DateTime(2021, 5, 7, 4, 31, 36, 4, DateTimeKind.Local).AddTicks(6528), true, "Поиск червя" },
                    { 3, 1, new DateTime(2021, 5, 7, 4, 31, 36, 4, DateTimeKind.Local).AddTicks(6535), true, "Поиск себя" }
                });

            migrationBuilder.InsertData(
                table: "TargetStatuses",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 2, "Требует проверки!" },
                    { 3, "Не найден" },
                    { 1, "Найден" }
                });

            migrationBuilder.InsertData(
                table: "TargetTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 2, "Автомобиль" },
                    { 1, "Человек" }
                });

            migrationBuilder.InsertData(
                table: "Targets",
                columns: new[] { "Id", "Description", "LostTime", "OperationId", "TargetStatusId", "TargetTypeId", "Title" },
                values: new object[,]
                {
                    { 5, "Состояние психической жизни организма, выражающееся в субъективном переживании событий внешнего мира и тела организма", new DateTime(2021, 5, 7, 4, 31, 36, 3, DateTimeKind.Local).AddTicks(1574), null, null, null, "Сознание" },
                    { 4, "Объективная реальность, существующая вне и независимо от человеческого сознания", new DateTime(2021, 5, 7, 4, 31, 36, 3, DateTimeKind.Local).AddTicks(1572), null, null, null, "Материя" },
                    { 3, "Фундаментальная категория философского дискурса, которая фиксирует основу существования", new DateTime(2021, 5, 7, 4, 31, 36, 3, DateTimeKind.Local).AddTicks(1571), null, null, null, "Бытие" },
                    { 2, "Ленточный или кольчатый", new DateTime(2021, 5, 7, 4, 31, 36, 3, DateTimeKind.Local).AddTicks(1558), null, null, null, "Червь" },
                    { 1, "Рыжий и пушистый", new DateTime(2021, 5, 7, 4, 31, 36, 2, DateTimeKind.Local).AddTicks(5625), null, null, null, "Кот" }
                });

            migrationBuilder.InsertData(
                table: "UserPositions",
                columns: new[] { "Id", "UserId", "X", "Y" },
                values: new object[,]
                {
                    { 7, null, "53.26007898803503", "34.19048819371207" },
                    { 6, null, "53.268190335912614", "34.10225374722882" },
                    { 5, null, "53.25833330694125", "34.05487493477459" },
                    { 4, null, "53.256690247883384", "34.029811613072425" },
                    { 2, null, "53.238406958742566", "34.0783918288512" },
                    { 3, null, "53.246727851106336", "34.067062448291985" },
                    { 1, null, "53.23676313746632", "34.111866214361854" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "", "Администратор" },
                    { 2, "", "Руководитель ПСР" },
                    { 3, "", "Координатор ПСР" },
                    { 4, "", "Участник ПСР" }
                });

            migrationBuilder.InsertData(
                table: "UserStatuses",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Активен" },
                    { 2, "Неактивен" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "IsBusy", "MiddleName", "SecondName", "UserRoleId", "UserStatusId" },
                values: new object[] { 4, "Андрей", false, "", "Селифонтов", null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "IsBusy", "MiddleName", "SecondName", "UserRoleId", "UserStatusId" },
                values: new object[] { 3, "Дмитрий", false, "Булатицкий", "Иванович", null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "IsBusy", "MiddleName", "SecondName", "UserRoleId", "UserStatusId" },
                values: new object[] { 2, "Максим", false, "Сергеевич", "Кириченко", null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "IsBusy", "MiddleName", "SecondName", "UserRoleId", "UserStatusId" },
                values: new object[] { 1, "Андрей", false, "Алексеевич", "Подоляко", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserRoleId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Cycles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cycles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ObjectStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ObjectStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ObjectStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TargetStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TargetStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TargetStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TargetTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TargetTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserPositions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserPositions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserPositions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserPositions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserPositions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserPositions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserPositions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Images");
        }
    }
}
