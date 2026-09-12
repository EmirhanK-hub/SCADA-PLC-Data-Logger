using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KocaYusuf_Telemetri.Migrations
{
    /// <inheritdoc />
    public partial class VeriTipleriSenkronize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AraHavaEkranDegeri",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "BalonSicaklikSet",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "HavaEkranDegeri",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "PresSicaklikSet",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "HidrolikEkranDegeri",
                table: "MakineVerileri");

            migrationBuilder.AlterColumn<double>(
                name: "PresSicakligi",
                table: "MakineVerileri",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "HidrolikBasinc",
                table: "MakineVerileri",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "BalonSicakligi",
                table: "MakineVerileri",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "AraHavaBasinci",
                table: "MakineVerileri",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "AnaHavaBasinci",
                table: "MakineVerileri",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            // Veritabanında ZATEN VAR OLAN R, X, Y bitlerinin AddColumn komutları temizlendi!

            migrationBuilder.AlterColumn<string>(
                name: "Mesaj",
                table: "IletisimMesajlari",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Down metodundaki çakışan DropColumn'lar da temizlendi

            migrationBuilder.RenameColumn(
                name: "GenelDurumKodu",
                table: "MakineVerileri",
                newName: "HidrolikEkranDegeri");

            migrationBuilder.AlterColumn<decimal>(
                name: "PresSicakligi",
                table: "MakineVerileri",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "HidrolikBasinc",
                table: "MakineVerileri",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "BalonSicakligi",
                table: "MakineVerileri",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "AraHavaBasinci",
                table: "MakineVerileri",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "AnaHavaBasinci",
                table: "MakineVerileri",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "AraHavaEkranDegeri",
                table: "MakineVerileri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "BalonSicaklikSet",
                table: "MakineVerileri",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "HavaEkranDegeri",
                table: "MakineVerileri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PresSicaklikSet",
                table: "MakineVerileri",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Mesaj",
                table: "IletisimMesajlari",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);
        }
    }
}