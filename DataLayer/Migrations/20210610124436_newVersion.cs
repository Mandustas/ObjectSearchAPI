using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class newVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TargetStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TargetTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetTypes", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "UserStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsBusy = table.Column<bool>(type: "bit", nullable: false),
                    UserRoleId = table.Column<int>(type: "int", nullable: false),
                    UserStatusId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserStatuses_UserStatusId",
                        column: x => x.UserStatusId,
                        principalTable: "UserStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    CoordinatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_Users_CoordinatorId",
                        column: x => x.CoordinatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Y = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPositions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OperationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cycles_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Missions_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Missions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationUser",
                columns: table => new
                {
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationUser", x => new { x.OperationId, x.UserId });
                    table.ForeignKey(
                        name: "FK_OperationUser_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Targets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    LostTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    TargetStatusId = table.Column<int>(type: "int", nullable: false),
                    TargetTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Targets_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Targets_TargetStatuses_TargetStatusId",
                        column: x => x.TargetStatusId,
                        principalTable: "TargetStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Targets_TargetTypes_TargetTypeId",
                        column: x => x.TargetTypeId,
                        principalTable: "TargetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QtyFindObject = table.Column<int>(type: "int", nullable: false),
                    QtyVerifiedObject = table.Column<int>(type: "int", nullable: false),
                    CycleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Cycles_CycleId",
                        column: x => x.CycleId,
                        principalTable: "Cycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetectedObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IsDesired = table.Column<bool>(type: "bit", nullable: false),
                    X = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Y = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    ImageMarkedUpId = table.Column<int>(type: "int", nullable: true),
                    MissionId = table.Column<int>(type: "int", nullable: true),
                    OperationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetectedObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetectedObjects_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetectedObjects_Images_ImageMarkedUpId",
                        column: x => x.ImageMarkedUpId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetectedObjects_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetectedObjects_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TargetStatuses",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Найден" },
                    { 2, "Требует проверки!" },
                    { 3, "Не найден" }
                });

            migrationBuilder.InsertData(
                table: "TargetTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Человек" },
                    { 2, "Автомобиль" }
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
                    { 1, "Кандидат в участники" },
                    { 2, "Доброволец" },
                    { 3, "Сотрудник" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsBusy", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecondName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRoleId", "UserStatusId" },
                values: new object[,]
                {
                    { 1, 0, "c29b77f8-aca6-42fd-a7d9-67b4509af3d2", null, false, "Андрей", false, false, null, "Алексеевич", null, null, "40BD001563085FC35165329EA1FF5C5ECBDBBEEF", null, false, "Подоляко", "e287ca04-2e1c-483f-a661-ea32ffa80981", false, "Andrey", 3, 3 },
                    { 2, 0, "50cf80ff-264c-4a92-af5b-2bc6b2f566e7", null, false, "Максим", false, false, null, "Сергеевич", null, null, "40BD001563085FC35165329EA1FF5C5ECBDBBEEF", null, false, "Кириченко", "cbf43a77-1bf4-4d85-971b-7ab31f7b97b1", false, "Maxim", 4, 3 },
                    { 3, 0, "dc413ab9-4fd0-4585-8eee-d7bb546896d1", null, false, "Дмитрий", false, false, null, "Булатицкий", null, null, "40BD001563085FC35165329EA1FF5C5ECBDBBEEF", null, false, "Иванович", "db18583e-a99c-4460-aaeb-fd47d3b1d82e", false, "Lead", 2, 3 },
                    { 4, 0, "12236d9e-b4b2-4c4e-8b72-c8e4f165d343", null, false, "Андрей", false, false, null, "Александрович", null, null, "40BD001563085FC35165329EA1FF5C5ECBDBBEEF", null, false, "Селифонтов", "70f7be4a-fad9-41fa-8a83-6b3f7268430e", false, "Andreog", 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "CoordinatorId", "Date", "IsSuccess", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473), false, "Поиск семьи" },
                    { 2, 1, new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473), true, "Поиск туристов" },
                    { 3, 1, new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473), true, "Поиск грибников" }
                });

            migrationBuilder.InsertData(
                table: "UserPositions",
                columns: new[] { "Id", "UserId", "X", "Y" },
                values: new object[,]
                {
                    { 1, 2, "53.23676313746632", "34.111866214361854" },
                    { 2, 2, "53.238406958742566", "34.0783918288512" },
                    { 3, 2, "53.246727851106336", "34.067062448291985" },
                    { 4, 4, "53.256690247883384", "34.029811613072425" },
                    { 5, 4, "53.25833330694125", "34.05487493477459" },
                    { 6, 4, "53.268190335912614", "34.10225374722882" },
                    { 7, 4, "53.26007898803503", "34.19048819371207" }
                });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "Description", "EndDate", "OperationId", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam nec volutpat elit. Pellentesque sit amet ullamcorper leo. In dictum hendrerit tempus. Mauris ultrices ante eu leo elementum, in pretium neque semper. ", new DateTime(2021, 5, 9, 7, 24, 48, 278, DateTimeKind.Local).AddTicks(3473), 1, new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473), "Облет леса" },
                    { 2, "Ut maximus aliquam leo, eu congue neque consequat eget. Integer non nulla augue. Vestibulum odio est, posuere ac orci sed, mollis dapibus massa. Nullam mattis neque ac scelerisque euismod. Aliquam pretium nisi sed leo iaculis molestie ut ac erat.", new DateTime(2021, 5, 9, 7, 24, 48, 278, DateTimeKind.Local).AddTicks(3473), 1, new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473), "Облет поля" }
                });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "OperationId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "OperationUser",
                columns: new[] { "OperationId", "UserId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 4 },
                    { 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Targets",
                columns: new[] { "Id", "Description", "LostTime", "OperationId", "TargetStatusId", "TargetTypeId", "Title" },
                values: new object[,]
                {
                    { 1, "Особые приметы: черная куртка и белые штаны", new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473), 1, 2, 1, "Мужчина 40 лет" },
                    { 6, "Цвет черный, седан", new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473), 1, 3, 1, "Автомобиль Lada" },
                    { 2, "Особые приметы: высокий рост и корзина для грибов", new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473), 2, 3, 1, "Женщина 28 лет" },
                    { 3, "Цвет красный, внедорожник", new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473), 3, 3, 1, "Автомобиль Renaut" },
                    { 4, "Цвет красный, внедорожник", new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473), 3, 3, 1, "Автомобиль Lada" },
                    { 5, "Цвет красный, внедорожник", new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473), 3, 3, 1, "Автомобиль Ford" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CycleId", "Path", "QtyFindObject", "QtyVerifiedObject", "TimeCreate" },
                values: new object[] { 1, 1, "https://thumbs.dreamstime.com/b/%D0%BB%D0%B5%D1%81-%D1%81%D0%B2%D0%B5%D1%80%D1%85%D1%83-%D0%BB%D0%B5%D1%82%D0%BE%D0%BC-%D0%B2%D0%B8%D0%B4-%D1%81-%D0%B2%D0%BE%D0%B7%D0%B4%D1%83%D1%85%D0%B0-%D0%BE%D0%B1%D0%BE%D0%B5%D0%B2-%D0%BB%D0%B5%D1%81%D0%B0-153275483.jpg", 1, 1, new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473) });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CycleId", "Path", "QtyFindObject", "QtyVerifiedObject", "TimeCreate" },
                values: new object[] { 2, 1, "https://i.pinimg.com/736x/c5/dc/53/c5dc53070960ee2ea4fb07ed2ff325b3.jpg", 1, 1, new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473) });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CycleId", "Path", "QtyFindObject", "QtyVerifiedObject", "TimeCreate" },
                values: new object[] { 3, 2, "https://envato-shoebox-0.imgix.net/4c17/f9ef-0fc2-4571-8819-373327ab564c/trip+mix-12.jpg?auto=compress%2Cformat&fit=max&mark=https%3A%2F%2Felements-assets.envato.com%2Fstatic%2Fwatermark2.png&markalign=center%2Cmiddle&markalpha=18&w=700&s=e56aa60d45ab74037c9f43d3a088bbdf", 1, 1, new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473) });

            migrationBuilder.InsertData(
                table: "DetectedObjects",
                columns: new[] { "Id", "Description", "ImageId", "ImageMarkedUpId", "IsDesired", "MissionId", "OperationId", "Title", "X", "Y" },
                values: new object[,]
                {
                    { 1, "На Севере лукоморья", 1, 1, false, 1, 1, "Объект #1", "53.22104557790858", "34.11112667059104" },
                    { 3, "В деревне", 1, 1, true, 1, 1, "Объект #3", "53.23204557790858", "34.12212667059104" },
                    { 2, "На Юго-Западе леса", 2, 1, false, 1, 1, "Объект #2", "53.21104557790858", "34.11012667059104" },
                    { 4, "Желает жить дружно", 2, 1, false, 1, 1, "Объект #4", "53.23104557790858", "34.13112667059104" },
                    { 5, "В чаще", 2, null, false, null, 1, "Объект #5", "53.21204557790858", "34.17212667059104" },
                    { 6, "На Востоке", 3, 1, false, 2, 1, "Объект #6", "53.25104557790858", "34.16012667059104" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cycles_OperationId",
                table: "Cycles",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_DetectedObjects_ImageId",
                table: "DetectedObjects",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_DetectedObjects_ImageMarkedUpId",
                table: "DetectedObjects",
                column: "ImageMarkedUpId");

            migrationBuilder.CreateIndex(
                name: "IX_DetectedObjects_MissionId",
                table: "DetectedObjects",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_DetectedObjects_OperationId",
                table: "DetectedObjects",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_CycleId",
                table: "Images",
                column: "CycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_OperationId",
                table: "Missions",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_UserId",
                table: "Missions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_CoordinatorId",
                table: "Operations",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationUser_UserId",
                table: "OperationUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Targets_OperationId",
                table: "Targets",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Targets_TargetStatusId",
                table: "Targets",
                column: "TargetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Targets_TargetTypeId",
                table: "Targets",
                column: "TargetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPositions_UserId",
                table: "UserPositions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserStatusId",
                table: "Users",
                column: "UserStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetectedObjects");

            migrationBuilder.DropTable(
                name: "OperationUser");

            migrationBuilder.DropTable(
                name: "Targets");

            migrationBuilder.DropTable(
                name: "UserPositions");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "TargetStatuses");

            migrationBuilder.DropTable(
                name: "TargetTypes");

            migrationBuilder.DropTable(
                name: "Cycles");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserStatuses");
        }
    }
}
