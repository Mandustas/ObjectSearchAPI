using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class fulldb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Operations",
                newName: "Title");

            migrationBuilder.AddColumn<bool>(
                name: "IsBusy",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserStatusId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TargetStatusId",
                table: "Targets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TargetTypeId",
                table: "Targets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoordinatorId",
                table: "Operations",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Missions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ObjectStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectStatuses", x => x.Id);
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
                name: "UserPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Y = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPositions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    QtyFindObject = table.Column<int>(type: "int", nullable: false),
                    TimeCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QtyVerifiedObject = table.Column<int>(type: "int", nullable: false),
                    CycleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Cycles_CycleId",
                        column: x => x.CycleId,
                        principalTable: "Cycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetectedObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    MissionId = table.Column<int>(type: "int", nullable: true),
                    ObjectStatusId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_DetectedObjects_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetectedObjects_ObjectStatuses_ObjectStatusId",
                        column: x => x.ObjectStatusId,
                        principalTable: "ObjectStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserStatusId",
                table: "Users",
                column: "UserStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Targets_TargetStatusId",
                table: "Targets",
                column: "TargetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Targets_TargetTypeId",
                table: "Targets",
                column: "TargetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DetectedObjects_ImageId",
                table: "DetectedObjects",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_DetectedObjects_MissionId",
                table: "DetectedObjects",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_DetectedObjects_ObjectStatusId",
                table: "DetectedObjects",
                column: "ObjectStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_CycleId",
                table: "Images",
                column: "CycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_UserId",
                table: "Missions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPositions_UserId",
                table: "UserPositions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Targets_TargetStatuses_TargetStatusId",
                table: "Targets",
                column: "TargetStatusId",
                principalTable: "TargetStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Targets_TargetTypes_TargetTypeId",
                table: "Targets",
                column: "TargetTypeId",
                principalTable: "TargetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserStatuses_UserStatusId",
                table: "Users",
                column: "UserStatusId",
                principalTable: "UserStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Targets_TargetStatuses_TargetStatusId",
                table: "Targets");

            migrationBuilder.DropForeignKey(
                name: "FK_Targets_TargetTypes_TargetTypeId",
                table: "Targets");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserStatuses_UserStatusId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "DetectedObjects");

            migrationBuilder.DropTable(
                name: "TargetStatuses");

            migrationBuilder.DropTable(
                name: "TargetTypes");

            migrationBuilder.DropTable(
                name: "UserPositions");

            migrationBuilder.DropTable(
                name: "UserStatuses");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "ObjectStatuses");

            migrationBuilder.DropTable(
                name: "Cycles");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserStatusId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Targets_TargetStatusId",
                table: "Targets");

            migrationBuilder.DropIndex(
                name: "IX_Targets_TargetTypeId",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "IsBusy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserStatusId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TargetStatusId",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "TargetTypeId",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "CoordinatorId",
                table: "Operations");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Operations",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
