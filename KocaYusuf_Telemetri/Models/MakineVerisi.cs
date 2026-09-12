using System;

namespace KocaYusuf_Telemetri.Models
{
    public class MakineVerisi
    {
        public int ID { get; set; }
        public int MakineID { get; set; }
        public DateTime? KayitZamani { get; set; } = DateTime.Now;

        // =========================================================================
        // --- 1. YENİ MERKEZİ PLC BLOĞU (DT5000 SERİSİ) ---
        // PLC'ci tüm dağınık verileri bu bloğa toplamış. Haberleşme kalbi burası!
        // =========================================================================
        public int? DT5000_VeriYapisiVersiyonu { get; set; } // DT5000
        public int? DT5001_MakineDurumu { get; set; }        // DT5001 (Durum kodu)
        public int? DT5002_ManuelOtomatik { get; set; }      // DT5002 (0: Manuel, 1: Otomatik)
        public int? DT5003_AktifIslemAdimi { get; set; }     // DT5003

        // Frontend sayfaları patlamasın diye eski değişken isimlerini koruduk ama artık yeni adreslere bakıyorlar
        public double? HidrolikBasinc { get; set; } // YENİ ADRES: DT5004 (Gelen değer 10'a bölünecek: bar x 10)
        public double? AnaHavaBasinci { get; set; } // YENİ ADRES: DT5005 (Gelen değer 10'a bölünecek: bar x 10)
        public double? BalonSicakligi { get; set; } // YENİ ADRES: DT5006 (Tabla Sıcaklığı) (Gelen değer 10'a bölünecek)
        public double? PresSicakligi { get; set; }  // YENİ ADRES: DT5007 (Yağ Sıcaklığı) (Gelen değer 10'a bölünecek)

        public int? UretimAdedi { get; set; }       // YENİ ADRES: DT5008-DT5009 (32 bit Günlük Çevrim Sayısı)
        public int? DT5010_SonCevrimSuresi { get; set; }     // DT5010 (Saniye)

        public int? DT5011_AktifAlarmKodu { get; set; }      // DT5011 (Integer - Ekrana alarm basmak için)
        public int? DT5012_AlarmBitMaskesi1 { get; set; }    // DT5012 (16 bit - Tüm hata R'leri buraya toplanmış olabilir)
        public int? DT5013_AlarmBitMaskesi2 { get; set; }    // DT5013 (16 bit)
        public int? DT5014_PLCHeartbeat { get; set; }        // DT5014 (Artan sayaç - Haberleşme testi)
        public int? DT5015_ProgramVersiyonu { get; set; }    // DT5015

        // =========================================================================
        // --- 2. HMI VE RAW REGISTER'LAR (Eskiden kalanlar) ---
        // =========================================================================
        public int? GenelDurum { get; set; }        // 1: Çalışıyor, 0: Beklemede
        public int? GenelDurumKodu { get; set; }    // DT36
        public double? AraHavaBasinci { get; set; } // DT206

        public int? DT60_IstenenHMIMesaji { get; set; }
        public int? DT61_MevcutHMISayfasi { get; set; }

        public double? DT1000_HidrolikRaw { get; set; }
        public double? DT1001_HavaRaw { get; set; }
        public double? DT1002_AraHavaRaw { get; set; }

        public double? DT32538_PresSicaklikSet { get; set; }
        public double? DT32539_PresSicaklikHisterezis { get; set; }

        public double? DT110_HidrolikBasincHMI { get; set; }
        public double? DT112_AnaHavaBasinciHMI { get; set; }
        public double? DT212_AraHavaBasinciHMI { get; set; }

        // =========================================================================
        // --- 3. DURUM BİTLERİ (R) --- 
        // (DT5012 maskesine geçilmiş olsa da, views patlamasın diye kalıyor)
        // =========================================================================
        public bool? R5_MakineCalisiyor { get; set; }
        public bool? R7_MakineHazir { get; set; }
        public bool? R16_CevrimAktif { get; set; }
        public bool? R36_CevrimTamamlandi { get; set; }
        public bool? R300_ManuelMod { get; set; }
        public bool? R301_OtomatikMod { get; set; }
        public bool? R32_GenelHata { get; set; }
        public bool? R98_AcilStopHafizasi { get; set; }
        public bool? R9D_OranFazla { get; set; }
        public bool? R9E_GenelHata2 { get; set; }
        public bool? R135_TermikAtti { get; set; }

        public bool? R2485_CalismaTipi1 { get; set; }
        public bool? R2486_CalismaTipi2 { get; set; }
        public bool? R2487_CalismaTipi3 { get; set; }
        public bool? R248A_ProsesSarti { get; set; }

        // =========================================================================
        // --- 4. DİJİTAL GİRİŞLER (X) ---
        // =========================================================================
        public bool? X0_StartButonu { get; set; }
        public bool? X1_StopButonu { get; set; }
        public bool? X2_HazirSwitch { get; set; }
        public bool? X4_AcilStop { get; set; }
        public bool? X6_SonSwitch { get; set; }
        public bool? X8_YagMotoruTermik { get; set; }
        public bool? X9_BasincMotoruTermik { get; set; }
        public bool? XA_VakumMotoruTermik { get; set; }
        public bool? X60_Vakostat { get; set; }

        // =========================================================================
        // --- 5. DİJİTAL ÇIKIŞLAR (Y) ---
        // =========================================================================
        public bool? Y1_HidrolikBasincMotoru { get; set; }
        public bool? Y60_VakumPompasi { get; set; }
        public bool? Y61_YagSirkulasyonPompasi { get; set; }
        public bool? Y62_YagIsitici { get; set; }
        public bool? Y63_HavaIsitici { get; set; }
        public bool? Y2_SolenoidValfS1 { get; set; }
        public bool? Y3_SolenoidValfS2 { get; set; }
        public bool? Y4_SolenoidValfS3 { get; set; }
        public bool? YC_SolenoidValfS11 { get; set; }
        public bool? YD_SolenoidValfS12 { get; set; }
        public bool? YE_SolenoidValfS13 { get; set; }
        public bool? YF_SolenoidValfS14 { get; set; }
        public bool? Y64_SolenoidValfS16 { get; set; }

        // İlişki (Navigation Property)
        public virtual Makine? Makine { get; set; }
    }
}