using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cycles", x => x.Id);
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
                    CoordinatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                });

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
                    UserStatusId = table.Column<int>(type: "int", nullable: false)
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
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
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
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    MissionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetectedObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetectedObjects_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetectedObjects_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "Description", "EndDate", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam nec volutpat elit. Pellentesque sit amet ullamcorper leo. In dictum hendrerit tempus. Mauris ultrices ante eu leo elementum, in pretium neque semper. ", new DateTime(2021, 5, 8, 22, 36, 11, 636, DateTimeKind.Local).AddTicks(8237), new DateTime(2021, 5, 8, 22, 16, 11, 636, DateTimeKind.Local).AddTicks(7854), "Облет леса" },
                    { 2, "Ut maximus aliquam leo, eu congue neque consequat eget. Integer non nulla augue. Vestibulum odio est, posuere ac orci sed, mollis dapibus massa. Nullam mattis neque ac scelerisque euismod. Aliquam pretium nisi sed leo iaculis molestie ut ac erat.", new DateTime(2021, 5, 8, 22, 36, 11, 636, DateTimeKind.Local).AddTicks(8708), new DateTime(2021, 5, 8, 22, 16, 11, 636, DateTimeKind.Local).AddTicks(8703), "Облет поля" }
                });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "CoordinatorId", "Date", "IsSuccess", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 5, 8, 22, 16, 11, 636, DateTimeKind.Local).AddTicks(4290), false, "Поиск кота" },
                    { 2, 1, new DateTime(2021, 5, 8, 22, 16, 11, 636, DateTimeKind.Local).AddTicks(5030), true, "Поиск червя" },
                    { 3, 1, new DateTime(2021, 5, 8, 22, 16, 11, 636, DateTimeKind.Local).AddTicks(5035), true, "Поиск себя" }
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
                    { 1, "Активен" },
                    { 2, "Неактивен" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CycleId", "Path", "QtyFindObject", "QtyVerifiedObject", "TimeCreate" },
                values: new object[,]
                {
                    { 1, 1, "https://thumbs.dreamstime.com/b/%D0%BB%D0%B5%D1%81-%D1%81%D0%B2%D0%B5%D1%80%D1%85%D1%83-%D0%BB%D0%B5%D1%82%D0%BE%D0%BC-%D0%B2%D0%B8%D0%B4-%D1%81-%D0%B2%D0%BE%D0%B7%D0%B4%D1%83%D1%85%D0%B0-%D0%BE%D0%B1%D0%BE%D0%B5%D0%B2-%D0%BB%D0%B5%D1%81%D0%B0-153275483.jpg", 1, 1, new DateTime(2021, 5, 8, 22, 16, 11, 637, DateTimeKind.Local).AddTicks(634) },
                    { 2, 1, "https://i.pinimg.com/736x/c5/dc/53/c5dc53070960ee2ea4fb07ed2ff325b3.jpg", 1, 1, new DateTime(2021, 5, 8, 22, 16, 11, 637, DateTimeKind.Local).AddTicks(1347) },
                    { 3, 1, "https://envato-shoebox-0.imgix.net/4c17/f9ef-0fc2-4571-8819-373327ab564c/trip+mix-12.jpg?auto=compress%2Cformat&fit=max&mark=https%3A%2F%2Felements-assets.envato.com%2Fstatic%2Fwatermark2.png&markalign=center%2Cmiddle&markalpha=18&w=700&s=e56aa60d45ab74037c9f43d3a088bbdf", 1, 1, new DateTime(2021, 5, 8, 22, 16, 11, 637, DateTimeKind.Local).AddTicks(1351) }
                });

            migrationBuilder.InsertData(
                table: "Targets",
                columns: new[] { "Id", "Description", "LostTime", "OperationId", "TargetStatusId", "TargetTypeId", "Title" },
                values: new object[,]
                {
                    { 1, "Рыжий и пушистый", new DateTime(2021, 5, 8, 22, 16, 11, 633, DateTimeKind.Local).AddTicks(9425), 1, 2, 1, "Кот" },
                    { 2, "Ленточный или кольчатый", new DateTime(2021, 5, 8, 22, 16, 11, 634, DateTimeKind.Local).AddTicks(6951), 2, 3, 1, "Червь" },
                    { 3, "Фундаментальная категория философского дискурса, которая фиксирует основу существования", new DateTime(2021, 5, 8, 22, 16, 11, 634, DateTimeKind.Local).AddTicks(6963), 3, 3, 1, "Бытие" },
                    { 4, "Объективная реальность, существующая вне и независимо от человеческого сознания", new DateTime(2021, 5, 8, 22, 16, 11, 634, DateTimeKind.Local).AddTicks(6966), 3, 3, 1, "Материя" },
                    { 5, "Состояние психической жизни организма, выражающееся в субъективном переживании событий внешнего мира и тела организма", new DateTime(2021, 5, 8, 22, 16, 11, 634, DateTimeKind.Local).AddTicks(6967), 3, 3, 1, "Сознание" },
                    { 6, "Мягкий и свежий", new DateTime(2021, 5, 8, 22, 16, 11, 634, DateTimeKind.Local).AddTicks(6969), 1, 3, 1, "Хлеб" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "IsBusy", "MiddleName", "SecondName", "UserRoleId", "UserStatusId" },
                values: new object[,]
                {
                    { 1, "Андрей", false, "Алексеевич", "Подоляко", 3, 1 },
                    { 2, "Максим", false, "Сергеевич", "Кириченко", 4, 1 },
                    { 3, "Дмитрий", false, "Булатицкий", "Иванович", 2, 1 },
                    { 4, "Андрей", false, "", "Селифонтов", 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "DetectedObjects",
                columns: new[] { "Id", "Description", "ImageId", "IsDesired", "MissionId", "Title", "X", "Y" },
                values: new object[] { 5, "В чаще", 2, false, null, "Кот Баюн", "53.21204557790858", "34.17212667059104" });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 4 }
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
                table: "DetectedObjects",
                columns: new[] { "Id", "Description", "ImageId", "IsDesired", "MissionId", "Title", "X", "Y" },
                values: new object[,]
                {
                    { 1, "На Севере лукоморья", 1, false, 1, "Кот на дубе", "53.22104557790858", "34.11112667059104" },
                    { 2, "На Юго-Западе леса", 2, false, 1, "Кот в камышах", "53.21104557790858", "34.11012667059104" },
                    { 3, "В деревне", 1, true, 1, "Кот Матроскин", "53.23204557790858", "34.12212667059104" },
                    { 4, "Желает жить дружно", 2, false, 1, "Кот Леопольд", "53.23104557790858", "34.13112667059104" },
                    { 6, "На Востоке", 3, false, 2, "Кот в сапогах", "53.25104557790858", "34.16012667059104" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetectedObjects_ImageId",
                table: "DetectedObjects",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_DetectedObjects_MissionId",
                table: "DetectedObjects",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_CycleId",
                table: "Images",
                column: "CycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_UserId",
                table: "Missions",
                column: "UserId");

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
                name: "Operations");

            migrationBuilder.DropTable(
                name: "TargetStatuses");

            migrationBuilder.DropTable(
                name: "TargetTypes");

            migrationBuilder.DropTable(
                name: "Cycles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserStatuses");
        }
    }
}
