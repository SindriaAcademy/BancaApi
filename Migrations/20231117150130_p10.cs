using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancaApi.Migrations
{

    public partial class p10 : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 17, 16, 1, 30, 206, DateTimeKind.Local).AddTicks(2054));

            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 17, 16, 1, 30, 206, DateTimeKind.Local).AddTicks(2137));

            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 17, 16, 1, 30, 206, DateTimeKind.Local).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 17, 16, 1, 30, 206, DateTimeKind.Local).AddTicks(2142));

            migrationBuilder.UpdateData(
                table: "Operazioni",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataOperazione",
                value: new DateTime(2023, 11, 17, 16, 1, 30, 206, DateTimeKind.Local).AddTicks(2155));

            migrationBuilder.UpdateData(
                table: "Operazioni",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataOperazione",
                value: new DateTime(2023, 11, 17, 16, 1, 30, 206, DateTimeKind.Local).AddTicks(2158));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
