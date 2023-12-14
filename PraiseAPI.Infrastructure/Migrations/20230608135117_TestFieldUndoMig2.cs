using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PraiseAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TestFieldUndoMig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestField",
                table: "CharStats");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 15, 51, 17, 596, DateTimeKind.Local).AddTicks(2824),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 15, 47, 4, 498, DateTimeKind.Local).AddTicks(2638));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "CharStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 15, 51, 17, 596, DateTimeKind.Local).AddTicks(7678),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 15, 47, 4, 498, DateTimeKind.Local).AddTicks(7434));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "CharStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 15, 51, 17, 596, DateTimeKind.Local).AddTicks(7277),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 15, 47, 4, 498, DateTimeKind.Local).AddTicks(7034));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Characters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 15, 51, 17, 596, DateTimeKind.Local).AddTicks(5366),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 15, 47, 4, 498, DateTimeKind.Local).AddTicks(5235));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Characters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 15, 51, 17, 596, DateTimeKind.Local).AddTicks(5055),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 15, 47, 4, 498, DateTimeKind.Local).AddTicks(4912));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 15, 47, 4, 498, DateTimeKind.Local).AddTicks(2638),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 15, 51, 17, 596, DateTimeKind.Local).AddTicks(2824));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "CharStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 15, 47, 4, 498, DateTimeKind.Local).AddTicks(7434),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 15, 51, 17, 596, DateTimeKind.Local).AddTicks(7678));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "CharStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 15, 47, 4, 498, DateTimeKind.Local).AddTicks(7034),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 15, 51, 17, 596, DateTimeKind.Local).AddTicks(7277));

            migrationBuilder.AddColumn<float>(
                name: "TestField",
                table: "CharStats",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Characters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 15, 47, 4, 498, DateTimeKind.Local).AddTicks(5235),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 15, 51, 17, 596, DateTimeKind.Local).AddTicks(5366));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Characters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 15, 47, 4, 498, DateTimeKind.Local).AddTicks(4912),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 15, 51, 17, 596, DateTimeKind.Local).AddTicks(5055));
        }
    }
}
