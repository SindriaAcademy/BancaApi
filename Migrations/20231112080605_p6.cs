using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;


namespace BancaApi.Migrations
{
    /// <inheritdoc />
    public partial class p6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdBanca = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Banche_IdBanca",
                        column: x => x.IdBanca,
                        principalTable: "Banche",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "IdBanca", "Password", "Username" },
                values: new object[,]
                {
                    { 1, 1, "admin", "admin" },
                    { 2, 2, "admin", "admin" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Admins_IdBanca",
                table: "Admins",
                column: "IdBanca");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 9, 15, 2, 50, 531, DateTimeKind.Local).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "Conti",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataUltimaOperazione",
                value: new DateTime(2023, 11, 9, 15, 2, 50, 531, DateTimeKind.Local).AddTicks(6343));

            migrationBuilder.UpdateData(
                table: "Operazioni",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataOperazione",
                value: new DateTime(2023, 11, 9, 15, 2, 50, 531, DateTimeKind.Local).AddTicks(6353));

            migrationBuilder.UpdateData(
                table: "Operazioni",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataOperazione",
                value: new DateTime(2023, 11, 9, 15, 2, 50, 531, DateTimeKind.Local).AddTicks(6355));
        }
    }
}
