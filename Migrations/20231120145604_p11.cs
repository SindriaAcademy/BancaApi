using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancaApi.Migrations
{
    public partial class p11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "C8nSHYA7gGfupj2SPuCc5s7rkaTvh7MprbLItngs1aaKePyKAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "KLdMRP2VpxNnUWYMaIwgOpbo2X2t2Dqhw0ZlCn+/JfflWSN1AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "f0frJxBd87l0hepRKCtVcVG1h1cgsmLnPPPAx8cwIWruY3t+AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "UwYcMU+OlpdtLr85F2PPxZmjfLx5aV1R65FMdpxBgIjvu6Z1AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=");

            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 20, 15, 56, 4, 368, DateTimeKind.Local).AddTicks(9955));

            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 20, 15, 56, 4, 368, DateTimeKind.Local).AddTicks(9993));

            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 20, 15, 56, 4, 368, DateTimeKind.Local).AddTicks(9995));

            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 20, 15, 56, 4, 368, DateTimeKind.Local).AddTicks(9997));

            migrationBuilder.UpdateData(
                table: "Operazioni",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataOperazione",
                value: new DateTime(2023, 11, 20, 15, 56, 4, 369, DateTimeKind.Local).AddTicks(18));

            migrationBuilder.UpdateData(
                table: "Operazioni",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataOperazione",
                value: new DateTime(2023, 11, 20, 15, 56, 4, 369, DateTimeKind.Local).AddTicks(20));

            migrationBuilder.UpdateData(
                table: "Utenti",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "MpYulXUsX0dp1dsSxZqWlDZ+Dz69yAYpAV1AEBG1ibRSiatYAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=");

            migrationBuilder.UpdateData(
                table: "Utenti",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "/JfppxLR572j6rLxyrJtoaBBe/bQ5mI+t1UntuCWzkSKKEneAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=");

            migrationBuilder.UpdateData(
                table: "Utenti",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "oO1v+kWFvNSNDU6OqhOiRkf/8JvRpNt0+FZ8WzBi34HBnu9RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=");

            migrationBuilder.UpdateData(
                table: "Utenti",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "5NbYuRHS7btFRbFOqo0XCIo1hQNg3w3QI9MKnGp8tZeMnG1LAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "admin");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "admin1");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "admin2");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "admin3");

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

            migrationBuilder.UpdateData(
                table: "Utenti",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "dario");

            migrationBuilder.UpdateData(
                table: "Utenti",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "sidy");

            migrationBuilder.UpdateData(
                table: "Utenti",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "sandro");

            migrationBuilder.UpdateData(
                table: "Utenti",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "sara");
        }
    }
}
