using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancaApi.Migrations
{
    /// <inheritdoc />
    public partial class p7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 12, 19, 9, 35, 607, DateTimeKind.Local).AddTicks(5377));

            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 12, 19, 9, 35, 607, DateTimeKind.Local).AddTicks(5419));

            migrationBuilder.UpdateData(
                table: "Operazioni",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataOperazione",
                value: new DateTime(2023, 11, 12, 19, 9, 35, 607, DateTimeKind.Local).AddTicks(5432));

            migrationBuilder.UpdateData(
                table: "Operazioni",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataOperazione",
                value: new DateTime(2023, 11, 12, 19, 9, 35, 607, DateTimeKind.Local).AddTicks(5435));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 12, 9, 6, 5, 305, DateTimeKind.Local).AddTicks(978));

            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 12, 9, 6, 5, 305, DateTimeKind.Local).AddTicks(1026));

            migrationBuilder.UpdateData(
                table: "Operazioni",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataOperazione",
                value: new DateTime(2023, 11, 12, 9, 6, 5, 305, DateTimeKind.Local).AddTicks(1048));

            migrationBuilder.UpdateData(
                table: "Operazioni",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataOperazione",
                value: new DateTime(2023, 11, 12, 9, 6, 5, 305, DateTimeKind.Local).AddTicks(1051));
        }
    }
}
