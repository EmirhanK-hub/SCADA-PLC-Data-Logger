using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KocaYusuf_Telemetri.Migrations
{
    /// <inheritdoc />
    public partial class IletisimTablosuEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IletisimMesajlari",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GonderimZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OkunduMu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IletisimMesajlari", x => x.ID);
                });

           /* migrationBuilder.CreateTable(
                name: "Makineler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakineAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MakineNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makineler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Alarmlar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakineID = table.Column<int>(type: "int", nullable: false),
                    AlarmMesaji = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaslangicZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SureDakika = table.Column<int>(type: "int", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarmlar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Alarmlar_Makineler_MakineID",
                        column: x => x.MakineID,
                        principalTable: "Makineler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MakineVerileri",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakineID = table.Column<int>(type: "int", nullable: false),
                    KayitZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HidrolikBasinc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AnaHavaBasinci = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AraHavaBasinci = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HidrolikEkranDegeri = table.Column<int>(type: "int", nullable: false),
                    HavaEkranDegeri = table.Column<int>(type: "int", nullable: false),
                    AraHavaEkranDegeri = table.Column<int>(type: "int", nullable: false),
                    BalonSicakligi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PresSicakligi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalonSicaklikSet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PresSicaklikSet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GenelDurum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakineVerileri", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MakineVerileri_Makineler_MakineID",
                        column: x => x.MakineID,
                        principalTable: "Makineler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });*/

            migrationBuilder.CreateIndex(
                name: "IX_Alarmlar_MakineID",
                table: "Alarmlar",
                column: "MakineID");

            migrationBuilder.CreateIndex(
                name: "IX_MakineVerileri_MakineID",
                table: "MakineVerileri",
                column: "MakineID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alarmlar");

            migrationBuilder.DropTable(
                name: "IletisimMesajlari");

            migrationBuilder.DropTable(
                name: "MakineVerileri");

            migrationBuilder.DropTable(
                name: "Makineler");
        }
    }
}
