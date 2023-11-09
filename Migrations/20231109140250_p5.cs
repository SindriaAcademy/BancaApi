using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;


namespace BancaApi.Migrations
{
    /// <inheritdoc />
    public partial class p5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Banche",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banche", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Funzionalita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funzionalita", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdBanca = table.Column<int>(type: "int", nullable: false),
                    NomeUtente = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bloccato = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utenti_Banche_IdBanca",
                        column: x => x.IdBanca,
                        principalTable: "Banche",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BancheFunzionalita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdBanca = table.Column<int>(type: "int", nullable: false),
                    IdFunzionalita = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BancheFunzionalita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BancheFunzionalita_Banche_IdBanca",
                        column: x => x.IdBanca,
                        principalTable: "Banche",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BancheFunzionalita_Funzionalita_IdFunzionalita",
                        column: x => x.IdFunzionalita,
                        principalTable: "Funzionalita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Conti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUtente = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataUltimaOperazione = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conti_Utenti_IdUtente",
                        column: x => x.IdUtente,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Operazioni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdBanca = table.Column<int>(type: "int", nullable: false),
                    IdUtente = table.Column<int>(type: "int", nullable: false),
                    Funzionalita = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantita = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataOperazione = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operazioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operazioni_Banche_IdBanca",
                        column: x => x.IdBanca,
                        principalTable: "Banche",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operazioni_Utenti_IdUtente",
                        column: x => x.IdUtente,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Banche",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Banca Uno" },
                    { 2, "Banca Due" }
                });

            migrationBuilder.InsertData(
                table: "Funzionalita",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Versamento" },
                    { 2, "Prelievo" },
                    { 3, "Saldo" },
                    { 4, "Registro Operazioni" }
                });

            migrationBuilder.InsertData(
                table: "BancheFunzionalita",
                columns: new[] { "Id", "IdBanca", "IdFunzionalita" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Utenti",
                columns: new[] { "Id", "Bloccato", "IdBanca", "NomeUtente", "Password" },
                values: new object[,]
                {
                    { 1, false, 1, "dario", "dario" },
                    { 2, false, 2, "sidy", "sidy" },
                    { 3, true, 2, "sandro", "sandro" }
                });

            migrationBuilder.InsertData(
                table: "Conti",
                columns: new[] { "Id", "DataUltimaOperazione", "IdUtente", "Saldo" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 9, 15, 2, 50, 531, DateTimeKind.Local).AddTicks(6302), 1, 1000m },
                    { 2, new DateTime(2023, 11, 9, 15, 2, 50, 531, DateTimeKind.Local).AddTicks(6343), 2, 2000m }
                });

            migrationBuilder.InsertData(
                table: "Operazioni",
                columns: new[] { "Id", "DataOperazione", "Funzionalita", "IdBanca", "IdUtente", "Quantita" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 9, 15, 2, 50, 531, DateTimeKind.Local).AddTicks(6353), "Deposito", 1, 1, 500m },
                    { 2, new DateTime(2023, 11, 9, 15, 2, 50, 531, DateTimeKind.Local).AddTicks(6355), "Prelievo", 2, 2, 300m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BancheFunzionalita_IdBanca",
                table: "BancheFunzionalita",
                column: "IdBanca");

            migrationBuilder.CreateIndex(
                name: "IX_BancheFunzionalita_IdFunzionalita",
                table: "BancheFunzionalita",
                column: "IdFunzionalita");

            migrationBuilder.CreateIndex(
                name: "IX_Conti_IdUtente",
                table: "Conti",
                column: "IdUtente");

            migrationBuilder.CreateIndex(
                name: "IX_Operazioni_IdBanca",
                table: "Operazioni",
                column: "IdBanca");

            migrationBuilder.CreateIndex(
                name: "IX_Operazioni_IdUtente",
                table: "Operazioni",
                column: "IdUtente");

            migrationBuilder.CreateIndex(
                name: "IX_Utenti_IdBanca",
                table: "Utenti",
                column: "IdBanca");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BancheFunzionalita");

            migrationBuilder.DropTable(
                name: "Conti");

            migrationBuilder.DropTable(
                name: "Operazioni");

            migrationBuilder.DropTable(
                name: "Funzionalita");

            migrationBuilder.DropTable(
                name: "Utenti");

            migrationBuilder.DropTable(
                name: "Banche");
        }
    }
}
