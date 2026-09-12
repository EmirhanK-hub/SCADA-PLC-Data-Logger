using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KocaYusuf_Telemetri.Migrations
{
    /// <inheritdoc />
    public partial class R280Silindi_IsimlerDuzenlendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "R1E0_ManuelMod",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "R1E1_OtomatikMod",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "R280_ManuelOtomatikHatasi",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "RD5_TermikAtti",
                table: "MakineVerileri");

            migrationBuilder.AlterColumn<bool>(
                name: "YF_SolenoidValfS14",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "YE_SolenoidValfS13",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "YD_SolenoidValfS12",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "YC_SolenoidValfS11",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Y64_SolenoidValfS16",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Y63_HavaIsitici",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Y62_YagIsitici",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Y61_YagSirkulasyonPompasi",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Y60_VakumPompasi",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Y4_SolenoidValfS3",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Y3_SolenoidValfS2",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Y2_SolenoidValfS1",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Y1_HidrolikBasincMotoru",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "XA_VakumMotoruTermik",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "X9_BasincMotoruTermik",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "X8_YagMotoruTermik",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "X6_SonSwitch",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "X60_Vakostat",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "X4_AcilStop",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "X2_HazirSwitch",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "X1_StopButonu",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "X0_StartButonu",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "UretimAdedi",
                table: "MakineVerileri",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "R9E_GenelHata2",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "R9D_OranFazla",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "R98_AcilStopHafizasi",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "R7_MakineHazir",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "R5_MakineCalisiyor",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "R36_CevrimTamamlandi",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "R32_GenelHata",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "R16_CevrimAktif",
                table: "MakineVerileri",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<double>(
                name: "PresSicakligi",
                table: "MakineVerileri",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitZamani",
                table: "MakineVerileri",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<double>(
                name: "HidrolikBasinc",
                table: "MakineVerileri",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "GenelDurumKodu",
                table: "MakineVerileri",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GenelDurum",
                table: "MakineVerileri",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "DT212_AraHavaBasinciHMI",
                table: "MakineVerileri",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "DT112_AnaHavaBasinciHMI",
                table: "MakineVerileri",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "DT110_HidrolikBasincHMI",
                table: "MakineVerileri",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "BalonSicakligi",
                table: "MakineVerileri",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "AraHavaBasinci",
                table: "MakineVerileri",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "AnaHavaBasinci",
                table: "MakineVerileri",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<double>(
                name: "DT1000_HidrolikRaw",
                table: "MakineVerileri",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DT1001_HavaRaw",
                table: "MakineVerileri",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DT1002_AraHavaRaw",
                table: "MakineVerileri",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DT32538_PresSicaklikSet",
                table: "MakineVerileri",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DT32539_PresSicaklikHisterezis",
                table: "MakineVerileri",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DT60_IstenenHMIMesaji",
                table: "MakineVerileri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DT61_MevcutHMISayfasi",
                table: "MakineVerileri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "R135_TermikAtti",
                table: "MakineVerileri",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "R2485_CalismaTipi1",
                table: "MakineVerileri",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "R2486_CalismaTipi2",
                table: "MakineVerileri",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "R2487_CalismaTipi3",
                table: "MakineVerileri",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "R248A_ProsesSarti",
                table: "MakineVerileri",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "R300_ManuelMod",
                table: "MakineVerileri",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "R301_OtomatikMod",
                table: "MakineVerileri",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DT1000_HidrolikRaw",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "DT1001_HavaRaw",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "DT1002_AraHavaRaw",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "DT32538_PresSicaklikSet",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "DT32539_PresSicaklikHisterezis",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "DT60_IstenenHMIMesaji",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "DT61_MevcutHMISayfasi",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "R135_TermikAtti",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "R2485_CalismaTipi1",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "R2486_CalismaTipi2",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "R2487_CalismaTipi3",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "R248A_ProsesSarti",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "R300_ManuelMod",
                table: "MakineVerileri");

            migrationBuilder.DropColumn(
                name: "R301_OtomatikMod",
                table: "MakineVerileri");

            migrationBuilder.AlterColumn<bool>(
                name: "YF_SolenoidValfS14",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "YE_SolenoidValfS13",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "YD_SolenoidValfS12",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "YC_SolenoidValfS11",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Y64_SolenoidValfS16",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Y63_HavaIsitici",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Y62_YagIsitici",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Y61_YagSirkulasyonPompasi",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Y60_VakumPompasi",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Y4_SolenoidValfS3",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Y3_SolenoidValfS2",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Y2_SolenoidValfS1",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Y1_HidrolikBasincMotoru",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "XA_VakumMotoruTermik",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "X9_BasincMotoruTermik",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "X8_YagMotoruTermik",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "X6_SonSwitch",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "X60_Vakostat",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "X4_AcilStop",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "X2_HazirSwitch",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "X1_StopButonu",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "X0_StartButonu",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UretimAdedi",
                table: "MakineVerileri",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "R9E_GenelHata2",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "R9D_OranFazla",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "R98_AcilStopHafizasi",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "R7_MakineHazir",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "R5_MakineCalisiyor",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "R36_CevrimTamamlandi",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "R32_GenelHata",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "R16_CevrimAktif",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PresSicakligi",
                table: "MakineVerileri",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitZamani",
                table: "MakineVerileri",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "HidrolikBasinc",
                table: "MakineVerileri",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenelDurumKodu",
                table: "MakineVerileri",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenelDurum",
                table: "MakineVerileri",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "DT212_AraHavaBasinciHMI",
                table: "MakineVerileri",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "DT112_AnaHavaBasinciHMI",
                table: "MakineVerileri",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "DT110_HidrolikBasincHMI",
                table: "MakineVerileri",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "BalonSicakligi",
                table: "MakineVerileri",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AraHavaBasinci",
                table: "MakineVerileri",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AnaHavaBasinci",
                table: "MakineVerileri",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "R1E0_ManuelMod",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "R1E1_OtomatikMod",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "R280_ManuelOtomatikHatasi",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RD5_TermikAtti",
                table: "MakineVerileri",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
