using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PraiseAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MinLvlMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 20, 4, 20, 365, DateTimeKind.Local).AddTicks(5144),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 20, 1, 54, 802, DateTimeKind.Local).AddTicks(4609));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "CharStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 20, 4, 20, 365, DateTimeKind.Local).AddTicks(9753),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 20, 1, 54, 802, DateTimeKind.Local).AddTicks(9403));

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "CharStats",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "CharStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 20, 4, 20, 365, DateTimeKind.Local).AddTicks(9403),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 20, 1, 54, 802, DateTimeKind.Local).AddTicks(9001));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Characters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 20, 4, 20, 365, DateTimeKind.Local).AddTicks(7650),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 20, 1, 54, 802, DateTimeKind.Local).AddTicks(7171));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Characters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 20, 4, 20, 365, DateTimeKind.Local).AddTicks(7296),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 20, 1, 54, 802, DateTimeKind.Local).AddTicks(6854));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 20, 1, 54, 802, DateTimeKind.Local).AddTicks(4609),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 20, 4, 20, 365, DateTimeKind.Local).AddTicks(5144));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "CharStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 20, 1, 54, 802, DateTimeKind.Local).AddTicks(9403),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 20, 4, 20, 365, DateTimeKind.Local).AddTicks(9753));

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "CharStats",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "CharStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 20, 1, 54, 802, DateTimeKind.Local).AddTicks(9001),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 20, 4, 20, 365, DateTimeKind.Local).AddTicks(9403));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Characters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 20, 1, 54, 802, DateTimeKind.Local).AddTicks(7171),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 20, 4, 20, 365, DateTimeKind.Local).AddTicks(7650));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Characters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 20, 1, 54, 802, DateTimeKind.Local).AddTicks(6854),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 20, 4, 20, 365, DateTimeKind.Local).AddTicks(7296));
        }
    }
}
