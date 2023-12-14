using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PraiseAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DefaultCharXPMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 20, 0, 5, 971, DateTimeKind.Local).AddTicks(4254),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 19, 55, 43, 868, DateTimeKind.Local).AddTicks(5678));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "CharStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 20, 0, 5, 971, DateTimeKind.Local).AddTicks(9014),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 19, 55, 43, 868, DateTimeKind.Local).AddTicks(9996));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "CharStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 20, 0, 5, 971, DateTimeKind.Local).AddTicks(8615),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 19, 55, 43, 868, DateTimeKind.Local).AddTicks(9629));

            migrationBuilder.AlterColumn<float>(
                name: "CharExp",
                table: "CharStats",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Characters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 20, 0, 5, 971, DateTimeKind.Local).AddTicks(6828),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 19, 55, 43, 868, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Characters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 20, 0, 5, 971, DateTimeKind.Local).AddTicks(6508),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 19, 55, 43, 868, DateTimeKind.Local).AddTicks(7759));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 19, 55, 43, 868, DateTimeKind.Local).AddTicks(5678),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 20, 0, 5, 971, DateTimeKind.Local).AddTicks(4254));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "CharStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 19, 55, 43, 868, DateTimeKind.Local).AddTicks(9996),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 20, 0, 5, 971, DateTimeKind.Local).AddTicks(9014));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "CharStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 19, 55, 43, 868, DateTimeKind.Local).AddTicks(9629),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 20, 0, 5, 971, DateTimeKind.Local).AddTicks(8615));

            migrationBuilder.AlterColumn<float>(
                name: "CharExp",
                table: "CharStats",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Characters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 19, 55, 43, 868, DateTimeKind.Local).AddTicks(8040),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 20, 0, 5, 971, DateTimeKind.Local).AddTicks(6828));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Characters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 19, 55, 43, 868, DateTimeKind.Local).AddTicks(7759),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 20, 0, 5, 971, DateTimeKind.Local).AddTicks(6508));
        }
    }
}
