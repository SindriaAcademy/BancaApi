using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BancaApi.Migrations
{
    /// <inheritdoc />
    public partial class p8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Username" },
                values: new object[] { "admin1", "admin1" });

            migrationBuilder.UpdateData(
                table: "Banche",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nome",
                value: "Fineco");

            migrationBuilder.UpdateData(
                table: "Banche",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nome",
                value: "BPM");

            migrationBuilder.InsertData(
                table: "Banche",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 3, "Che Banche!" },
                    { 4, "Intesa San Paolo" },
                    { 5, "Credit Agricole" }
                });

            migrationBuilder.UpdateData(
                table: "BancheFunzionalita",
                keyColumn: "Id",
                keyValue: 2,
                column: "IdBanca",
                value: 2);

            migrationBuilder.InsertData(
                table: "BancheFunzionalita",
                columns: new[] { "Id", "IdBanca", "IdFunzionalita" },
                values: new object[,]
                {
                    { 3, 2, 1 },
                    { 4, 1, 3 },
                    { 7, 1, 2 }
                });

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

            migrationBuilder.InsertData(
                table: "Conti",
                columns: new[] { "Id", "DataUltimaOperazione", "IdUtente", "Saldo" },
                values: new object[] { 3, new DateTime(2023, 11, 13, 11, 17, 51, 595, DateTimeKind.Local).AddTicks(6342), 3, 2000m });

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

            migrationBuilder.UpdateData(
                table: "Utenti",
                keyColumn: "Id",
                keyValue: 3,
                column: "IdBanca",
                value: 3);

            migrationBuilder.InsertData(
                table: "Utenti",
                columns: new[] { "Id", "Bloccato", "IdBanca", "NomeUtente", "Password" },
                values: new object[] { 4, true, 2, "sara", "sara" });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "IdBanca", "Password", "Username" },
                values: new object[,]
                {
                    { 3, 3, "admin2", "admin2" },
                    { 4, 4, "admin3", "admin3" }
                });

            migrationBuilder.InsertData(
                table: "BancheFunzionalita",
                columns: new[] { "Id", "IdBanca", "IdFunzionalita" },
                values: new object[,]
                {
                    { 5, 3, 2 },
                    { 6, 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "Conti",
                columns: new[] { "Id", "DataUltimaOperazione", "IdUtente", "Saldo" },
                values: new object[] { 4, new DateTime(2023, 11, 13, 11, 17, 51, 595, DateTimeKind.Local).AddTicks(6343), 4, 2000m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Banche",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BancheFunzionalita",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BancheFunzionalita",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BancheFunzionalita",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BancheFunzionalita",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BancheFunzionalita",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Banche",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Banche",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Utenti",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Username" },
                values: new object[] { "admin", "admin" });

            migrationBuilder.UpdateData(
                table: "Banche",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nome",
                value: "Banca Uno");

            migrationBuilder.UpdateData(
                table: "Banche",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nome",
                value: "Banca Due");

            migrationBuilder.UpdateData(
                table: "BancheFunzionalita",
                keyColumn: "Id",
                keyValue: 2,
                column: "IdBanca",
                value: 1);

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

            migrationBuilder.UpdateData(
                table: "Utenti",
                keyColumn: "Id",
                keyValue: 3,
                column: "IdBanca",
                value: 2);
        }
    }
}
