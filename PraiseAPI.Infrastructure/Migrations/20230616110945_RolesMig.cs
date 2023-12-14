using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PraiseAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RolesMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 16, 13, 9, 45, 640, DateTimeKind.Local).AddTicks(768),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 10, 14, 50, 29, 529, DateTimeKind.Local).AddTicks(8912));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "CharStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 16, 13, 9, 45, 640, DateTimeKind.Local).AddTicks(7353),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 10, 14, 50, 29, 530, DateTimeKind.Local).AddTicks(4898));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "CharStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 16, 13, 9, 45, 640, DateTimeKind.Local).AddTicks(6941),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 10, 14, 50, 29, 530, DateTimeKind.Local).AddTicks(4500));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Characters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 16, 13, 9, 45, 640, DateTimeKind.Local).AddTicks(3620),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 10, 14, 50, 29, 530, DateTimeKind.Local).AddTicks(1463));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Characters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 16, 13, 9, 45, 640, DateTimeKind.Local).AddTicks(3275),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 10, 14, 50, 29, 530, DateTimeKind.Local).AddTicks(1117));

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 6, 16, 13, 9, 45, 640, DateTimeKind.Local).AddTicks(9375))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 10, 14, 50, 29, 529, DateTimeKind.Local).AddTicks(8912),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 16, 13, 9, 45, 640, DateTimeKind.Local).AddTicks(768));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "CharStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 10, 14, 50, 29, 530, DateTimeKind.Local).AddTicks(4898),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 16, 13, 9, 45, 640, DateTimeKind.Local).AddTicks(7353));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "CharStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 10, 14, 50, 29, 530, DateTimeKind.Local).AddTicks(4500),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 16, 13, 9, 45, 640, DateTimeKind.Local).AddTicks(6941));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Characters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 10, 14, 50, 29, 530, DateTimeKind.Local).AddTicks(1463),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 16, 13, 9, 45, 640, DateTimeKind.Local).AddTicks(3620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Characters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 10, 14, 50, 29, 530, DateTimeKind.Local).AddTicks(1117),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 16, 13, 9, 45, 640, DateTimeKind.Local).AddTicks(3275));
        }
    }
}
