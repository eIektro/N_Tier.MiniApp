using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace N_Tier.MiniApp.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gorev",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gorevadi = table.Column<string>(type: "character varying", nullable: false),
                    gorevtanimi = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gorev", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sirket",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sirketadi = table.Column<string>(type: "character varying", nullable: false),
                    unvan = table.Column<string>(type: "character varying", nullable: true),
                    email = table.Column<string>(type: "character varying", nullable: true),
                    adres = table.Column<string>(type: "character varying", nullable: true),
                    logo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sirket", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kullanici",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    isim = table.Column<string>(type: "character varying", nullable: false),
                    soyisim = table.Column<string>(type: "character varying", nullable: false),
                    dogumtarihi = table.Column<DateTime>(type: "date", nullable: true),
                    email = table.Column<string>(type: "character varying", nullable: true),
                    pasword = table.Column<string>(type: "character varying", nullable: true),
                    gorev = table.Column<int>(nullable: true),
                    sirket = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kullanici", x => x.id);
                    table.ForeignKey(
                        name: "kullanicigorev_foreign",
                        column: x => x.gorev,
                        principalTable: "gorev",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "kullanicisirket_foreign",
                        column: x => x.sirket,
                        principalTable: "sirket",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "fki_kullanicigorev_foreign",
                table: "kullanici",
                column: "gorev");

            migrationBuilder.CreateIndex(
                name: "fki_kullanicisirket_foreign",
                table: "kullanici",
                column: "sirket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kullanici");

            migrationBuilder.DropTable(
                name: "gorev");

            migrationBuilder.DropTable(
                name: "sirket");
        }
    }
}
