using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eğitim_Portalı.Migrations
{
    /// <inheritdoc />
    public partial class EğitimPortalıDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eğitimler",
                columns: table => new
                {
                    eğitimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kategori = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eğitmenBilgisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kontenjan = table.Column<int>(type: "int", nullable: false),
                    günlükFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    eğitimSüresiGün = table.Column<int>(type: "int", nullable: false),
                    oluşturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    güncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eğitimler", x => x.eğitimId);
                });

            migrationBuilder.CreateTable(
                name: "roller",
                columns: table => new
                {
                    rolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rolAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rolTanımı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    oluşturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    güncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roller", x => x.rolId);
                });

            migrationBuilder.CreateTable(
                name: "yetkiler",
                columns: table => new
                {
                    yetkiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yetkiAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yetkiTanımı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    oluşturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    güncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yetkiler", x => x.yetkiId);
                });

            migrationBuilder.CreateTable(
                name: "kullanıcılar",
                columns: table => new
                {
                    kullanıcıId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kullanıcıAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mailAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    şifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aEğitimId = table.Column<int>(type: "int", nullable: false),
                    rolId = table.Column<int>(type: "int", nullable: false),
                    oluşturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sonGiriş = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kullanıcılar", x => x.kullanıcıId);
                    table.ForeignKey(
                        name: "FK_kullanıcılar_roller_rolId",
                        column: x => x.rolId,
                        principalTable: "roller",
                        principalColumn: "rolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolYetki",
                columns: table => new
                {
                    rollerrolId = table.Column<int>(type: "int", nullable: false),
                    yetkileryetkiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolYetki", x => new { x.rollerrolId, x.yetkileryetkiId });
                    table.ForeignKey(
                        name: "FK_RolYetki_roller_rollerrolId",
                        column: x => x.rollerrolId,
                        principalTable: "roller",
                        principalColumn: "rolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolYetki_yetkiler_yetkileryetkiId",
                        column: x => x.yetkileryetkiId,
                        principalTable: "yetkiler",
                        principalColumn: "yetkiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alınanEğitimler",
                columns: table => new
                {
                    aEğitimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aEğitimAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aEğitimDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alımTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    güncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    kullanıcıId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alınanEğitimler", x => x.aEğitimId);
                    table.ForeignKey(
                        name: "FK_alınanEğitimler_kullanıcılar_kullanıcıId",
                        column: x => x.kullanıcıId,
                        principalTable: "kullanıcılar",
                        principalColumn: "kullanıcıId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_alınanEğitimler_kullanıcıId",
                table: "alınanEğitimler",
                column: "kullanıcıId");

            migrationBuilder.CreateIndex(
                name: "IX_kullanıcılar_rolId",
                table: "kullanıcılar",
                column: "rolId");

            migrationBuilder.CreateIndex(
                name: "IX_RolYetki_yetkileryetkiId",
                table: "RolYetki",
                column: "yetkileryetkiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alınanEğitimler");

            migrationBuilder.DropTable(
                name: "eğitimler");

            migrationBuilder.DropTable(
                name: "RolYetki");

            migrationBuilder.DropTable(
                name: "kullanıcılar");

            migrationBuilder.DropTable(
                name: "yetkiler");

            migrationBuilder.DropTable(
                name: "roller");
        }
    }
}
