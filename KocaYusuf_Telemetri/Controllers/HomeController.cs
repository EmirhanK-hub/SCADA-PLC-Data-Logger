using System;
using System.IO;
using System.Collections.Generic;
using KocaYusuf_Telemetri.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace KocaYusuf_Telemetri.Controllers
{
    public class HomeController : Controller
    {
        private readonly MakineContext _context;

        public HomeController(MakineContext context)
        {
            _context = context;
        }

        // --- DÝÐER SAYFALARIN (Index, Hakkýmýzda vs.) ---

        public IActionResult Index()
        {
            var makineler = _context.Makineler.Include(m => m.Veriler).ToList();
            return View(makineler);
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }

        public IActionResult MakineHakkinda()
        {
            return View();
        }

        public IActionResult ServisIO()
        {
            var kargoKutusu = _context.Makineler.Include(m => m.Veriler).ToList();
            return View(kargoKutusu);
        }

        // --- DÝJÝTAL ÝKÝZ / CANLI ÝZLEME SAYFASI ---
        public IActionResult CanliIzleme()
        {
            var sonVeri = _context.MakineVerileri
                .Where(v => v.KayitZamani != null)
                .OrderByDescending(v => v.KayitZamani)
                .FirstOrDefault();

            if (sonVeri == null)
            {
                sonVeri = new MakineVerisi();
            }

            return View(sonVeri);
        }

        // --- GEÇMÝÞ VERÝLER SAYFASI ---
        public IActionResult GecmisVeriler()
        {
            return View();
        }

        // --- ÝLETÝÞÝM FORMU VE LOGLAMA KODLARI ---
        [HttpGet]
        public IActionResult Iletisim()
        {
            return View(new IletisimMesaji());
        }

        [HttpPost]
        public IActionResult IletisimGonder(IletisimMesaji model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.IletisimMesajlari.Add(model);
                    _context.SaveChanges();

                    string logMesaji = $"[{DateTime.Now}] BAÞARILI - Yeni Ýletiþim - {model.AdSoyad} ({model.Telefon}): {model.Mesaj}";
                    LogYaz(logMesaji);

                    TempData["MesajBasarili"] = "Mesajýnýz baþarýyla iletildi! En kýsa sürede dönüþ yapýlacaktýr.";
                    return RedirectToAction("Iletisim");
                }
                catch (Exception ex)
                {
                    string asilHata = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    string hataLogMesaji = $"[{DateTime.Now}] HATA - Ýletiþim Kaydý Baþarýsýz! Kullanýcý: {model.AdSoyad} | Hata Detayý: {asilHata}";

                    LogYaz(hataLogMesaji);

                    TempData["MesajHata"] = "Sistemsel bir arýza nedeniyle mesajýnýz iletilemedi. Ekiplerimiz durumdan haberdar edildi.";
                    return RedirectToAction("Iletisim");
                }
            }
            return View("Iletisim", model);
        }

        private void LogYaz(string mesaj)
        {
            string logYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs", "iletisim_loglari.txt");
            string? klasorYolu = Path.GetDirectoryName(logYolu);

            if (!string.IsNullOrEmpty(klasorYolu))
            {
                Directory.CreateDirectory(klasorYolu);
            }

            System.IO.File.AppendAllText(logYolu, mesaj + Environment.NewLine);
        }

        // --- DETAY SAYFASI ---
        public IActionResult Detay(int id)
        {
            var makine = _context.Makineler.Include(m => m.Veriler).FirstOrDefault(m => m.ID == id);

            if (makine == null)
            {
                return RedirectToAction("Index");
            }

            return View(makine);
        }

        // --- CANLI YAYIN (AJAX) ÝÇÝN GÝZLÝ TÜNEL ---
        [HttpGet]
        public IActionResult CanliVeriGetir()
        {
            var sonVeri = _context.MakineVerileri
                .Where(v => v.KayitZamani != null)
                .OrderByDescending(v => v.KayitZamani)
                .FirstOrDefault();

            return Json(sonVeri);
        }

        [HttpGet]
        public IActionResult GunlukUretimGetir()
        {
            var bugun = DateTime.Today;
            var yarin = bugun.AddDays(1);

            var sonKayit = _context.MakineVerileri
                .Where(v => v.KayitZamani >= bugun && v.KayitZamani < yarin)
                .OrderByDescending(v => v.KayitZamani)
                .FirstOrDefault();

            int uretim = sonKayit?.UretimAdedi ?? 0;

            return Json(new { GunlukUretim = uretim });
        }

        // --- GEÇMÝÞ VERÝLERÝ TARÝH ARALIÐINA GÖRE SORGULAMA ---
        [HttpGet]
        public IActionResult GecmisVeriGetir(DateTime baslangic, DateTime bitis)
        {
            var bitisDahil = bitis.Date.AddDays(1);

            var veriler = _context.MakineVerileri
                .Where(v => v.KayitZamani >= baslangic.Date && v.KayitZamani < bitisDahil)
                .OrderBy(v => v.KayitZamani)
                .Select(v => new
                {
                    v.KayitZamani,
                    v.HidrolikBasinc,
                    v.AnaHavaBasinci,
                    v.AraHavaBasinci,
                    v.BalonSicakligi,
                    v.PresSicakligi,
                    v.R5_MakineCalisiyor,
                    v.R36_CevrimTamamlandi,
                    v.R32_GenelHata,
                    v.DT60_IstenenHMIMesaji
                })
                .ToList();

            return Json(veriler);
        }

        // --- HATA/ALARM GEÇMÝÞÝ SAYFASI ---
        public IActionResult AlarmGecmisi()
        {
            return View();
        }

        // --- HATA/ALARM GEÇMÝÞÝ VERÝSÝ ---
        [HttpGet]
        public IActionResult AlarmGecmisiGetir(DateTime baslangic, DateTime bitis)
        {
            var bitisDahil = bitis.Date.AddDays(1);

            var kayitlar = _context.MakineVerileri
                .Where(v => v.KayitZamani >= baslangic.Date && v.KayitZamani < bitisDahil)
                .OrderBy(v => v.KayitZamani)
                .Select(v => new
                {
                    v.KayitZamani,
                    v.R32_GenelHata,
                    v.R9E_GenelHata2,
                    v.R98_AcilStopHafizasi,
                    v.R135_TermikAtti, // DÜZELTÝLDÝ: Modeldeki doðru isim (R135) kullanýldý
                    v.R9D_OranFazla,
                    v.X8_YagMotoruTermik,
                    v.X9_BasincMotoruTermik,
                    v.XA_VakumMotoruTermik,
                    v.DT60_IstenenHMIMesaji
                })
                .ToList();

            var olaylar = new List<object>();

            bool? oncekiR32 = null, oncekiR9E = null, oncekiR98 = null, oncekiR135 = null, oncekiR9D = null;
            int? oncekiDT60 = null;

            foreach (var k in kayitlar)
            {
                if (k.R32_GenelHata == true && oncekiR32 != true)
                    olaylar.Add(new { Zaman = k.KayitZamani, Tur = "Genel Hata", Detay = "R32 Aktif", Kod = "R32" });

                if (k.R9E_GenelHata2 == true && oncekiR9E != true)
                    olaylar.Add(new { Zaman = k.KayitZamani, Tur = "Genel Hata 2", Detay = "R9E Aktif", Kod = "R9E" });

                if (k.R98_AcilStopHafizasi == true && oncekiR98 != true)
                {
                    string acilStopDetay = k.DT60_IstenenHMIMesaji != null ? $"Acil Stop Basýldý. Ýlgili HMI Kodu: {k.DT60_IstenenHMIMesaji}" : "Acil Stop Basýldý";
                    olaylar.Add(new { Zaman = k.KayitZamani, Tur = "Acil Stop", Detay = acilStopDetay, Kod = "R98" });
                }

                // DÜZELTÝLDÝ: R135_TermikAtti kontrolü
                if (k.R135_TermikAtti == true && oncekiR135 != true)
                {
                    var motorlar = new List<string>();
                    if (k.X8_YagMotoruTermik == true) motorlar.Add("M1 - Yað Motoru (X8)");
                    if (k.X9_BasincMotoruTermik == true) motorlar.Add("M2 - Basýnç Motoru (X9)");
                    if (k.XA_VakumMotoruTermik == true) motorlar.Add("M3 - Vakum Motoru (XA)");

                    string detay = motorlar.Count > 0 ? string.Join(" + ", motorlar) : "Kaynak belirlenemedi";
                    olaylar.Add(new { Zaman = k.KayitZamani, Tur = "Termik Attý", Detay = detay, Kod = "R135" });
                }

                if (k.R9D_OranFazla == true && oncekiR9D != true)
                    olaylar.Add(new { Zaman = k.KayitZamani, Tur = "Oran Fazla / Stop", Detay = "", Kod = "R9D" });

                if (k.DT60_IstenenHMIMesaji != null && k.DT60_IstenenHMIMesaji > 0 && k.DT60_IstenenHMIMesaji != oncekiDT60)
                {
                    olaylar.Add(new { Zaman = k.KayitZamani, Tur = "HMI Sistem Uyarýsý", Detay = $"Yeni HMI Mesaj Kodu Ýletildi: K{k.DT60_IstenenHMIMesaji}", Kod = "DT60" });
                }

                oncekiR32 = k.R32_GenelHata;
                oncekiR9E = k.R9E_GenelHata2;
                oncekiR98 = k.R98_AcilStopHafizasi;
                oncekiR135 = k.R135_TermikAtti;
                oncekiR9D = k.R9D_OranFazla;
                oncekiDT60 = k.DT60_IstenenHMIMesaji;
            }

            olaylar.Reverse();

            return Json(olaylar);
        }

        // --- EXCEL ÝNDÝRME KODU ---
        [HttpGet]
        public IActionResult ExportToExcel()
        {
            var veriler = _context.MakineVerileri.OrderByDescending(v => v.KayitZamani).ToList();

            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Makine Verileri");

                worksheet.Cell(1, 1).Value = "Kayýt Zamaný";
                worksheet.Cell(1, 2).Value = "Makine Durumu";
                worksheet.Cell(1, 3).Value = "Üretim Adedi";
                worksheet.Cell(1, 4).Value = "Hidrolik Basýnç (bar)";
                worksheet.Cell(1, 5).Value = "Ana Hava Basýncý (bar)";
                worksheet.Cell(1, 6).Value = "Ara Hava Basýncý (bar)";
                worksheet.Cell(1, 7).Value = "Balon Sýcaklýðý (°C)";
                worksheet.Cell(1, 8).Value = "Pres Sýcaklýðý (°C)";
                worksheet.Cell(1, 9).Value = "Genel Hata";
                worksheet.Cell(1, 10).Value = "Acil Stop Durumu";
                worksheet.Cell(1, 11).Value = "Termik Durumu";
                worksheet.Cell(1, 12).Value = "Aktif HMI Kodu";

                worksheet.Range("A1:L1").Style.Font.Bold = true;

                int row = 2;
                foreach (var item in veriler)
                {
                    worksheet.Cell(row, 1).Value = item.KayitZamani?.ToString() ?? "";
                    worksheet.Cell(row, 2).Value = item.GenelDurum == 1 ? "Çalýþýyor" : "Beklemede";
                    worksheet.Cell(row, 3).Value = item.UretimAdedi ?? 0;
                    worksheet.Cell(row, 4).Value = item.DT110_HidrolikBasincHMI;
                    worksheet.Cell(row, 5).Value = item.DT112_AnaHavaBasinciHMI;
                    worksheet.Cell(row, 6).Value = item.DT212_AraHavaBasinciHMI;
                    worksheet.Cell(row, 7).Value = item.BalonSicakligi;
                    worksheet.Cell(row, 8).Value = item.PresSicakligi;

                    worksheet.Cell(row, 9).Value = (item.R32_GenelHata == true) ? "HATA VAR" : "Normal";
                    worksheet.Cell(row, 10).Value = (item.R98_AcilStopHafizasi == true) ? "BASILDI" : "Normal";

                    // DÜZELTÝLDÝ: R135_TermikAtti kullanýldý
                    worksheet.Cell(row, 11).Value = (item.R135_TermikAtti == true) ? "ATTI" : "Normal";
                    worksheet.Cell(row, 12).Value = item.DT60_IstenenHMIMesaji != null ? "K" + item.DT60_IstenenHMIMesaji.ToString() : "Yok";

                    if (item.R32_GenelHata == true) worksheet.Cell(row, 9).Style.Font.FontColor = ClosedXML.Excel.XLColor.Red;
                    if (item.R98_AcilStopHafizasi == true) worksheet.Cell(row, 10).Style.Font.FontColor = ClosedXML.Excel.XLColor.Red;
                    if (item.R135_TermikAtti == true) worksheet.Cell(row, 11).Style.Font.FontColor = ClosedXML.Excel.XLColor.Red;

                    row++;
                }

                worksheet.Columns().AdjustToContents();

                using (var stream = new System.IO.MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    var dosyaAdi = $"KocaYusuf_Ozet_Rapor_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";

                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", dosyaAdi);
                }
            }
        }

        [HttpPost]
        public IActionResult ManuelYedekAl()
        {
            try
            {
                var yol = KocaYusuf_Telemetri.Services.YedeklemeService.YedekAl(_context, Microsoft.Extensions.Logging.Abstractions.NullLogger.Instance);
                TempData["YedekMesaji"] = $"Yedek baþarýyla alýndý: {yol}";
            }
            catch (Exception ex)
            {
                TempData["YedekMesaji"] = $"Yedekleme baþarýsýz oldu: {ex.Message}";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult VerileriSifirla()
        {
            try
            {
                _context.Database.ExecuteSqlRaw("TRUNCATE TABLE MakineVerileri");
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}