using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PraiseAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CharStatsMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CharStats_CharacterId",
                table: "CharStats");

            migrationBuilder.DropColumn(
                name: "IsCurrent",
                table: "CharStats");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 10, 14, 50, 29, 529, DateTimeKind.Local).AddTicks(8912),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 15, 51, 17, 596, DateTimeKind.Local).AddTicks(2824));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "CharStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 10, 14, 50, 29, 530, DateTimeKind.Local).AddTicks(4898),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 15, 51, 17, 596, DateTimeKind.Local).AddTicks(7678));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "CharStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 10, 14, 50, 29, 530, DateTimeKind.Local).AddTicks(4500),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 15, 51, 17, 596, DateTimeKind.Local).AddTicks(7277));

            migrationBuilder.AddColumn<float>(
                name: "LevelUpExp",
                table: "CharStats",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Characters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 10, 14, 50, 29, 530, DateTimeKind.Local).AddTicks(1463),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 15, 51, 17, 596, DateTimeKind.Local).AddTicks(5366));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Characters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 10, 14, 50, 29, 530, DateTimeKind.Local).AddTicks(1117),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 15, 51, 17, 596, DateTimeKind.Local).AddTicks(5055));

            migrationBuilder.AddColumn<bool>(
                name: "IsNpc",
                table: "Characters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_CharStats_CharacterId_LevelUpDate",
                table: "CharStats",
                columns: new[] { "CharacterId", "LevelUpDate" },
                unique: true,
                filter: "[LevelUpDate] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CharStats_CharacterId_LevelUpDate",
                table: "CharStats");

            migrationBuilder.DropColumn(
                name: "LevelUpExp",
                table: "CharStats");

            migrationBuilder.DropColumn(
                name: "IsNpc",
                table: "Characters");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 15, 51, 17, 596, DateTimeKind.Local).AddTicks(2824),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 10, 14, 50, 29, 529, DateTimeKind.Local).AddTicks(8912));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "CharStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 15, 51, 17, 596, DateTimeKind.Local).AddTicks(7678),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 10, 14, 50, 29, 530, DateTimeKind.Local).AddTicks(4898));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "CharStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 15, 51, 17, 596, DateTimeKind.Local).AddTicks(7277),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 10, 14, 50, 29, 530, DateTimeKind.Local).AddTicks(4500));

            migrationBuilder.AddColumn<bool>(
                name: "IsCurrent",
                table: "CharStats",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Characters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 15, 51, 17, 596, DateTimeKind.Local).AddTicks(5366),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 10, 14, 50, 29, 530, DateTimeKind.Local).AddTicks(1463));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Characters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 15, 51, 17, 596, DateTimeKind.Local).AddTicks(5055),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 10, 14, 50, 29, 530, DateTimeKind.Local).AddTicks(1117));

            migrationBuilder.CreateIndex(
                name: "IX_CharStats_CharacterId",
                table: "CharStats",
                column: "CharacterId");
        }
    }
}
