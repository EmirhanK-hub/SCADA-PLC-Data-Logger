# -*- coding: utf-8 -*-
"""
Koca Yusuf Telemetri - COM17 (Minimalmodbus RTU) & Otomatik Eşitlenmiş Sürüm
@author: emirh
"""

import time
import minimalmodbus
import serial
import pyodbc

# ==========================================
# 1. AYARLAR KISMI
# ==========================================
COM_PORT = "COM17"
SLAVE_ID = 3
BAUD_RATE = 115200
MAKINE_ID = 1

DB_CONN_STR = (
    "Driver={ODBC Driver 17 for SQL Server};"
    "Server=(localdb)\\MSSQLLocalDB;"
    "Database=KocaYusuf_Makine;"
    "Trusted_Connection=yes;"
)

YENIDEN_BAGLANMA_BEKLEME = 5  # saniye
HEARTBEAT_SANIYE = 60
ANALOG_TOLERANS = 0.05

# ==========================================
# 2. REGISTER HARİTASI (C# MODELİ İLE %100 UYUMLU)
# ==========================================

ANALOG_REGISTERS = {
    "DT5000_VeriYapisiVersiyonu": (5000, 1),
    "DT5001_MakineDurumu": (5001, 1),
    "DT5002_ManuelOtomatik": (5002, 1),
    "DT5003_AktifIslemAdimi": (5003, 1),
    
    # DÜZELTME BURADA YAPILDI: "0" gelen değerler eski çalışan adreslere çekildi
    "HidrolikBasinc": (110, 1),      # DT110 (bar x 10)
    "AnaHavaBasinci": (112, 1),      # DT112 (bar x 10)
    "BalonSicakligi": (126, 1),      # DT126 - Tabla Sıcaklığı (°C x 10)
    "PresSicakligi": (82, 1),        # DT82 - Yağ Sıcaklığı (°C x 10)
    
    "DT5010_SonCevrimSuresi": (5010, 1),
    "DT5011_AktifAlarmKodu": (5011, 1),
    "DT5012_AlarmBitMaskesi1": (5012, 1),
    "DT5013_AlarmBitMaskesi2": (5013, 1),
    "DT5014_PLCHeartbeat": (5014, 1),
    "DT5015_ProgramVersiyonu": (5015, 1),
    
    "GenelDurumKodu": (36, 1),
    "AraHavaBasinci": (206, 40),
    "DT60_IstenenHMIMesaji": (60, 1),
    "DT61_MevcutHMISayfasi": (61, 1),
    "DT1000_HidrolikRaw": (1000, 1),
    "DT1001_HavaRaw": (1001, 1),
    "DT1002_AraHavaRaw": (1002, 1),
    "DT32538_PresSicaklikSet": (32538, 1),
    "DT32539_PresSicaklikHisterezis": (32539, 1),
    "DT110_HidrolikBasincHMI": (110, 1),
    "DT112_AnaHavaBasinciHMI": (112, 1),
    "DT212_AraHavaBasinciHMI": (212, 1),
}

COIL_REGISTERS = {
    "R5_MakineCalisiyor": 2053,
    "R7_MakineHazir": 2055,
    "R16_CevrimAktif": 2070,
    "R36_CevrimTamamlandi": 2102,
    "R300_ManuelMod": 2528,
    "R301_OtomatikMod": 2529,
    "R32_GenelHata": 2098,
    "R98_AcilStopHafizasi": 2200,
    "R9D_OranFazla": 2205,
    "R9E_GenelHata2": 2206,
    "R135_TermikAtti": 2261,
    
    "R2485_CalismaTipi1": 2485,
    "R2486_CalismaTipi2": 2486,
    "R2487_CalismaTipi3": 2487,
    "R248A_ProsesSarti": 2481,

    "Y1_HidrolikBasincMotoru": 1,
    "Y60_VakumPompasi": 96,
    "Y61_YagSirkulasyonPompasi": 97,
    "Y62_YagIsitici": 98,
    "Y63_HavaIsitici": 99,
    "Y2_SolenoidValfS1": 2,
    "Y3_SolenoidValfS2": 3,
    "Y4_SolenoidValfS3": 4,
    "YC_SolenoidValfS11": 12,
    "YD_SolenoidValfS12": 13,
    "YE_SolenoidValfS13": 14,
    "YF_SolenoidValfS14": 15,
    "Y64_SolenoidValfS16": 100,
}

DISCRETE_REGISTERS = {
    "X0_StartButonu": 0,
    "X1_StopButonu": 1,
    "X2_HazirSwitch": 2,
    "X6_SonSwitch": 6,
    "X8_YagMotoruTermik": 8,
    "X9_BasincMotoruTermik": 9,
    "XA_VakumMotoruTermik": 10,
    "X60_Vakostat": 96,
}

X4_ACIL_STOP_ADRESI = 4


# ==========================================
# 3. BAĞLANTI FONKSİYONLARI
# ==========================================

def plc_baglan():
    try:
        instrument = minimalmodbus.Instrument(COM_PORT, SLAVE_ID, mode=minimalmodbus.MODE_RTU)
        instrument.serial.baudrate = BAUD_RATE
        instrument.serial.bytesize = 8
        instrument.serial.parity = serial.PARITY_NONE
        instrument.serial.stopbits = 1
        instrument.serial.timeout = 0.5
        instrument.clear_buffers_before_each_transaction = True
        instrument.close_port_after_each_call = False
        print(f"✅ PLC'ye {COM_PORT} üzerinden Modbus RTU bağlandı!")
        return instrument
    except Exception as exc:
        print(f"❌ PLC bağlantı hatası: {exc}")
        return None

def db_baglan():
    try:
        conn = pyodbc.connect(DB_CONN_STR)
        cursor = conn.cursor()
        print("✅ Veritabanına (LocalDB) bağlanıldı!")
        return conn, cursor
    except Exception as e:
        print(f"❌ Veritabanı bağlantı hatası: {e}")
        return None, None


# ==========================================
# 4. VERİ OKUMA FONKSİYONLARI
# ==========================================

def analog_oku(plc, isim, adres, olcek):
    try:
        ham = plc.read_register(registeraddress=adres, number_of_decimals=0, functioncode=3, signed=False)
        return ham / olcek
    except Exception:
        return None

def coil_oku(plc, isim, adres):
    try:
        return bool(plc.read_bit(registeraddress=adres, functioncode=1))
    except Exception:
        return None

def discrete_oku(plc, isim, adres):
    try:
        return bool(plc.read_bit(registeraddress=adres, functioncode=2))
    except Exception:
        return None

def x4_acil_stop_oku(plc):
    try:
        ham = plc.read_bit(registeraddress=X4_ACIL_STOP_ADRESI, functioncode=2)
        return not bool(ham)
    except Exception:
        return None

def tum_verileri_oku(plc):
    veri = {"MakineID": MAKINE_ID}

    for isim, (adres, olcek) in ANALOG_REGISTERS.items():
        veri[isim] = analog_oku(plc, isim, adres, olcek)

    for isim, adres in COIL_REGISTERS.items():
        veri[isim] = coil_oku(plc, isim, adres)

    for isim, adres in DISCRETE_REGISTERS.items():
        veri[isim] = discrete_oku(plc, isim, adres)

    veri["X4_AcilStop"] = x4_acil_stop_oku(plc)
    veri["GenelDurum"] = 1 if veri.get("R5_MakineCalisiyor") else 0

    return veri


# ==========================================
# 5. DEĞİŞİKLİK TESPİTİ
# ==========================================

def anlamli_degisiklik_var_mi(yeni_veri, eski_veri):
    if eski_veri is None:
        return True

    for anahtar, yeni_deger in yeni_veri.items():
        if anahtar in ("MakineID",):
            continue

        eski_deger = eski_veri.get(anahtar)

        if (yeni_deger is None) != (eski_deger is None):
            return True
        if yeni_deger is None and eski_deger is None:
            continue

        if isinstance(yeni_deger, float) or isinstance(eski_deger, float):
            if abs(float(yeni_deger) - float(eski_deger)) > ANALOG_TOLERANS:
                return True
        else:
            if yeni_deger != eski_deger:
                return True

    return False


# ==========================================
# 6. ANA DÖNGÜ VE SQL KAYIT
# ==========================================

def main():
    print(f"🚀 KocaYusuf Kuryesi Başlatılıyor ({COM_PORT} RTU & Otomatik Eşitlenmiş)...")
    print(f"Port: {COM_PORT} | Slave ID: {SLAVE_ID} | Hız: {BAUD_RATE}")
    print("-" * 50)

    plc = None
    db_conn = None
    db_cursor = None
    son_kaydedilen_veri = None
    son_kayit_zamani = 0

    from datetime import date
    uretim_sayaci = 0
    uretim_gunu = date.today()
    onceki_r36 = None

    while True:
        if plc is None:
            plc = plc_baglan()
            if plc is None:
                time.sleep(YENIDEN_BAGLANMA_BEKLEME)
                continue

        if db_conn is None:
            db_conn, db_cursor = db_baglan()
            if db_conn is None:
                time.sleep(YENIDEN_BAGLANMA_BEKLEME)
                continue

        try:
            veri = tum_verileri_oku(plc)

            bugun = date.today()
            if bugun != uretim_gunu:
                uretim_sayaci = 0
                uretim_gunu = bugun

            if veri.get("R36_CevrimTamamlandi") is True and onceki_r36 is not True:
                uretim_sayaci += 1
            onceki_r36 = veri.get("R36_CevrimTamamlandi")

            veri["UretimAdedi"] = uretim_sayaci

            simdi = time.time()
            degisti = anlamli_degisiklik_var_mi(veri, son_kaydedilen_veri)
            heartbeat_zamani_geldi = (simdi - son_kayit_zamani) >= HEARTBEAT_SANIYE

            if not degisti and not heartbeat_zamani_geldi:
                time.sleep(1)
                continue

            # Sütun listesi ve değerler tam olarak eşleştirildi
            sutunlar = [
                "MakineID",
                "DT5000_VeriYapisiVersiyonu", "DT5001_MakineDurumu", "DT5002_ManuelOtomatik", "DT5003_AktifIslemAdimi",
                "HidrolikBasinc", "AnaHavaBasinci", "BalonSicakligi", "PresSicakligi",
                "UretimAdedi", "DT5010_SonCevrimSuresi", "DT5011_AktifAlarmKodu", "DT5012_AlarmBitMaskesi1",
                "DT5013_AlarmBitMaskesi2", "DT5014_PLCHeartbeat", "DT5015_ProgramVersiyonu",
                "GenelDurum", "GenelDurumKodu", "AraHavaBasinci",
                "DT60_IstenenHMIMesaji", "DT61_MevcutHMISayfasi",
                "DT1000_HidrolikRaw", "DT1001_HavaRaw", "DT1002_AraHavaRaw",
                "DT32538_PresSicaklikSet", "DT32539_PresSicaklikHisterezis",
                "DT110_HidrolikBasincHMI", "DT112_AnaHavaBasinciHMI", "DT212_AraHavaBasinciHMI",
                "R5_MakineCalisiyor", "R7_MakineHazir", "R16_CevrimAktif", "R36_CevrimTamamlandi",
                "R300_ManuelMod", "R301_OtomatikMod", "R32_GenelHata", "R98_AcilStopHafizasi",
                "R9D_OranFazla", "R9E_GenelHata2", "R135_TermikAtti",
                "R2485_CalismaTipi1", "R2486_CalismaTipi2", "R2487_CalismaTipi3", "R248A_ProsesSarti",
                "X0_StartButonu", "X1_StopButonu", "X2_HazirSwitch", "X4_AcilStop", "X6_SonSwitch",
                "X8_YagMotoruTermik", "X9_BasincMotoruTermik", "XA_VakumMotoruTermik", "X60_Vakostat",
                "Y1_HidrolikBasincMotoru", "Y60_VakumPompasi", "Y61_YagSirkulasyonPompasi", "Y62_YagIsitici", "Y63_HavaIsitici",
                "Y2_SolenoidValfS1", "Y3_SolenoidValfS2", "Y4_SolenoidValfS3",
                "YC_SolenoidValfS11", "YD_SolenoidValfS12", "YE_SolenoidValfS13", "YF_SolenoidValfS14", "Y64_SolenoidValfS16"
            ]

            degerler = (
                veri.get("MakineID"),
                veri.get("DT5000_VeriYapisiVersiyonu"), veri.get("DT5001_MakineDurumu"), veri.get("DT5002_ManuelOtomatik"), veri.get("DT5003_AktifIslemAdimi"),
                veri.get("HidrolikBasinc"), veri.get("AnaHavaBasinci"), veri.get("BalonSicakligi"), veri.get("PresSicakligi"),
                veri.get("UretimAdedi"), veri.get("DT5010_SonCevrimSuresi"), veri.get("DT5011_AktifAlarmKodu"), veri.get("DT5012_AlarmBitMaskesi1"),
                veri.get("DT5013_AlarmBitMaskesi2"), veri.get("DT5014_PLCHeartbeat"), veri.get("DT5015_ProgramVersiyonu"),
                veri.get("GenelDurum"), veri.get("GenelDurumKodu"), veri.get("AraHavaBasinci"),
                veri.get("DT60_IstenenHMIMesaji"), veri.get("DT61_MevcutHMISayfasi"),
                veri.get("DT1000_HidrolikRaw"), veri.get("DT1001_HavaRaw"), veri.get("DT1002_AraHavaRaw"),
                veri.get("DT32538_PresSicaklikSet"), veri.get("DT32539_PresSicaklikHisterezis"),
                veri.get("DT110_HidrolikBasincHMI"), veri.get("DT112_AnaHavaBasinciHMI"), veri.get("DT212_AraHavaBasinciHMI"),
                veri.get("R5_MakineCalisiyor"), veri.get("R7_MakineHazir"), veri.get("R16_CevrimAktif"), veri.get("R36_CevrimTamamlandi"),
                veri.get("R300_ManuelMod"), veri.get("R301_OtomatikMod"), veri.get("R32_GenelHata"), veri.get("R98_AcilStopHafizasi"),
                veri.get("R9D_OranFazla"), veri.get("R9E_GenelHata2"), veri.get("R135_TermikAtti"),
                veri.get("R2485_CalismaTipi1"), veri.get("R2486_CalismaTipi2"), veri.get("R2487_CalismaTipi3"), veri.get("R248A_ProsesSarti"),
                veri.get("X0_StartButonu"), veri.get("X1_StopButonu"), veri.get("X2_HazirSwitch"), veri.get("X4_AcilStop"), veri.get("X6_SonSwitch"),
                veri.get("X8_YagMotoruTermik"), veri.get("X9_BasincMotoruTermik"), veri.get("XA_VakumMotoruTermik"), veri.get("X60_Vakostat"),
                veri.get("Y1_HidrolikBasincMotoru"), veri.get("Y60_VakumPompasi"), veri.get("Y61_YagSirkulasyonPompasi"), veri.get("Y62_YagIsitici"), veri.get("Y63_HavaIsitici"),
                veri.get("Y2_SolenoidValfS1"), veri.get("Y3_SolenoidValfS2"), veri.get("Y4_SolenoidValfS3"),
                veri.get("YC_SolenoidValfS11"), veri.get("YD_SolenoidValfS12"), veri.get("YE_SolenoidValfS13"), veri.get("YF_SolenoidValfS14"), veri.get("Y64_SolenoidValfS16")
            )

            placeholders = ", ".join(["?"] * len(degerler))
            sutun_str = ", ".join(sutunlar)
            sql_sorgu = f"INSERT INTO MakineVerileri ({sutun_str}, KayitZamani) VALUES ({placeholders}, GETDATE())"

            db_cursor.execute(sql_sorgu, degerler)
            db_conn.commit()

            son_kaydedilen_veri = veri
            son_kayit_zamani = simdi

            sebep = "değişiklik var" if degisti else "heartbeat (60sn)"
            print(f"📡 SQL'e Yazıldı ({sebep}) -> Hidrolik: {veri.get('HidrolikBasinc')} bar | Üretim: {veri.get('UretimAdedi')} adet")

        except (serial.SerialException, OSError) as exc:
            print(f"❌ Seri port bağlantısı koptu: {exc}")
            try:
                plc.serial.close()
            except Exception:
                pass
            plc = None
            time.sleep(YENIDEN_BAGLANMA_BEKLEME)
            continue

        except pyodbc.Error as exc:
            print(f"❌ Veritabanı bağlantısı koptu: {exc}")
            try:
                db_conn.close()
            except Exception:
                pass
            db_conn = None
            db_cursor = None
            time.sleep(YENIDEN_BAGLANMA_BEKLEME)
            continue

        except Exception as exc:
            print(f"⚠️ Beklenmeyen hata: {exc}")

        time.sleep(1)


if __name__ == "__main__":
    try:
        main()
    except KeyboardInterrupt:
        print("\n🛑 Kurye manuel olarak durduruldu.")