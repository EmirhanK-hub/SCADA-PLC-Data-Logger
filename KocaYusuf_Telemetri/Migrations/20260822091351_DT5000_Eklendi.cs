using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KocaYusuf_Telemetri.Migrations
{
    /// <inheritdoc />
    public partial class DT5000_Eklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DT5000_VeriYapisiVersiyonu",
                table: "MakineVerileri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DT5001_MakineDurumu",
                table: "MakineVerileri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DT5002_ManuelOtomatik",
                table: "MakineVerileri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DT5003_AktifIslemAdimi",
                table: "MakineVerileri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DT5010_SonCevrimSuresi",
                table: "MakineVerileri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DT5011_AktifAlarmKodu",
                table: "MakineVerileri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DT5012_AlarmBitMaskesi1",
                table: "MakineVerileri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DT5013_AlarmBitMaskesi2",
                table: "MakineVerileri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DT5014_PLCHeartbeat",
                table: "MakineVerileri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DT5015_ProgramVersiyonu",
                table: "MakineVerileri",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DT5000_VeriYapisiVersiyonu",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "DT5001_MakineDurumu",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "DT5002_ManuelOtomatik",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "DT5003_AktifIslemAdimi",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "DT5010_SonCevrimSuresi",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "DT5011_AktifAlarmKodu",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "DT5012_AlarmBitMaskesi1",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "DT5013_AlarmBitMaskesi2",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "DT5014_PLCHeartbeat",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "DT5015_ProgramVersiyonu",
                table: "MakineVerileri");
        }
    }
}
