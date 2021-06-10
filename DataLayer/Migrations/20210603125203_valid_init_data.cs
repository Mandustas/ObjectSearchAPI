using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class valid_init_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Объект #1");

            migrationBuilder.UpdateData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Объект #2");

            migrationBuilder.UpdateData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Объект #3");

            migrationBuilder.UpdateData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "Объект #4");

            migrationBuilder.UpdateData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 5,
                column: "Title",
                value: "Объект #5");

            migrationBuilder.UpdateData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 6,
                column: "Title",
                value: "Объект #6");

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Поиск семьи");

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Поиск туристов");

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Поиск грибников");

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Особые приметы: черная куртка и белые штаны", "Мужчина 40 лет" });

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Особые приметы: высокий рост и корзина для грибов", "Женщина 28 лет" });

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Цвет красный, внедорожник", "Автомобиль Renaut" });

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Цвет красный, внедорожник", "Автомобиль Lada" });

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Цвет красный, внедорожник", "Автомобиль Ford" });

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Цвет черный, седан", "Автомобиль Lada" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Кот на дубе");

            migrationBuilder.UpdateData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Кот в камышах");

            migrationBuilder.UpdateData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Кот Матроскин");

            migrationBuilder.UpdateData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "Кот Леопольд");

            migrationBuilder.UpdateData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 5,
                column: "Title",
                value: "Кот Баюн");

            migrationBuilder.UpdateData(
                table: "DetectedObjects",
                keyColumn: "Id",
                keyValue: 6,
                column: "Title",
                value: "Кот в сапогах");

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Поиск кота");

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Поиск червя");

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Поиск себя");

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Рыжий и пушистый", "Кот" });

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Ленточный или кольчатый", "Червь" });

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Фундаментальная категория философского дискурса, которая фиксирует основу существования", "Бытие" });

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Объективная реальность, существующая вне и независимо от человеческого сознания", "Материя" });

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Состояние психической жизни организма, выражающееся в субъективном переживании событий внешнего мира и тела организма", "Сознание" });

            migrationBuilder.UpdateData(
                table: "Targets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Мягкий и свежий", "Хлеб" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5b323cb3-6875-4419-a1ad-834cc31941c2", "168c5ad1-a0a7-4f42-b2b0-30b4611c59b5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "467d005f-d3f6-494e-bed0-ca6c8a4a1916", "1b90e5a5-5cbc-4870-89b7-76d7f0d7fab2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f6bf1f3f-3425-442a-9ed7-b22a71beda63", "7bf6a74c-41ce-47f2-bee7-e377760e8865" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "07784f67-e794-4b47-b400-b43a15d98d4a", "d8b85405-1af4-4f9c-976c-0a4d6d630ed4" });
        }
    }
}
