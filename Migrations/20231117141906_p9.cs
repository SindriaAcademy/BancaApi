using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancaApi.Migrations
{
    public partial class p9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Utenti",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Utenti",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Utenti",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Admins",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Admins",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Role", "Token" },
                values: new object[] { "admin", "" });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Role", "Token" },
                values: new object[] { "admin", "" });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Role", "Token" },
                values: new object[] { "admin", "" });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Role", "Token" },
                values: new object[] { "admin", "" });

            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 17, 15, 19, 5, 841, DateTimeKind.Local).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 17, 15, 19, 5, 841, DateTimeKind.Local).AddTicks(4774));

            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 17, 15, 19, 5, 841, DateTimeKind.Local).AddTicks(4777));

            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 17, 15, 19, 5, 841, DateTimeKind.Local).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "Operazioni",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataOperazione",
                value: new DateTime(2023, 11, 17, 15, 19, 5, 841, DateTimeKind.Local).AddTicks(4803));

            migrationBuilder.UpdateData(
                table: "Operazioni",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataOperazione",
                value: new DateTime(2023, 11, 17, 15, 19, 5, 841, DateTimeKind.Local).AddTicks(4807));

            migrationBuilder.UpdateData(
                table: "Utenti",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Role", "Token" },
                values: new object[] { "teacher", "" });

            migrationBuilder.UpdateData(
                table: "Utenti",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Role", "Token" },
                values: new object[] { "student", "" });

            migrationBuilder.UpdateData(
                table: "Utenti",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Role", "Token" },
                values: new object[] { "student", "" });

            migrationBuilder.UpdateData(
                table: "Utenti",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Role", "Token" },
                values: new object[] { "student", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Admins");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Utenti",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 13, 11, 17, 51, 595, DateTimeKind.Local).AddTicks(6297));

            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 13, 11, 17, 51, 595, DateTimeKind.Local).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 13, 11, 17, 51, 595, DateTimeKind.Local).AddTicks(6342));

            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 13, 11, 17, 51, 595, DateTimeKind.Local).AddTicks(6343));

            migrationBuilder.UpdateData(
                table: "Operazioni",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataOperazione",
                value: new DateTime(2023, 11, 13, 11, 17, 51, 595, DateTimeKind.Local).AddTicks(6358));

            migrationBuilder.UpdateData(
                table: "Operazioni",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataOperazione",
                value: new DateTime(2023, 11, 13, 11, 17, 51, 595, DateTimeKind.Local).AddTicks(6361));
        }
    }
}
