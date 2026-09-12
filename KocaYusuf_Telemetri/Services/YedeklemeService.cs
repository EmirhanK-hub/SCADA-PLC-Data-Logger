using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using KocaYusuf_Telemetri.Models;

namespace KocaYusuf_Telemetri.Services
{
    /// <summary>
    /// Uygulama arka planda çalışırken veritabanını düzenli aralıklarla
    /// .bak dosyası olarak yedekler. Dışarıdan Zamanlanmış Görev (Task Scheduler)
    /// veya sqlcmd gibi ek bir araca ihtiyaç duymaz.
    /// </summary>
    public class YedeklemeService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<YedeklemeService> _logger;

        // --- AYARLAR ---
        private static readonly TimeSpan YedeklemeAraligi = TimeSpan.FromHours(24);
        private const string VeritabaniAdi = "KocaYusuf_Makine";
        private const int SaklamaGunSayisi = 30; // bundan eski yedekler otomatik silinir

        public YedeklemeService(IServiceProvider serviceProvider, ILogger<YedeklemeService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        private static string YedekKlasoru()
        {
            var klasor = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "KocaYusufYedekler");

            Directory.CreateDirectory(klasor);
            return klasor;
        }

        public static string YedekAl(MakineContext context, ILogger logger)
        {
            var klasor = YedekKlasoru();
            var dosyaAdi = $"{VeritabaniAdi}_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            var tamYol = Path.Combine(klasor, dosyaAdi);

            var sql = $"BACKUP DATABASE [{VeritabaniAdi}] TO DISK = @yol WITH INIT";

            context.Database.ExecuteSqlRaw(sql, new Microsoft.Data.SqlClient.SqlParameter("@yol", tamYol));

            logger.LogInformation("Veritabanı yedeği alındı: {Yol}", tamYol);

            EskiYedekleriTemizle(klasor, logger);

            return tamYol;
        }

        private static void EskiYedekleriTemizle(string klasor, ILogger logger)
        {
            var sinirTarih = DateTime.Now.AddDays(-SaklamaGunSayisi);

            foreach (var dosya in Directory.GetFiles(klasor, "*.bak"))
            {
                var bilgi = new FileInfo(dosya);
                if (bilgi.CreationTime < sinirTarih)
                {
                    try
                    {
                        bilgi.Delete();
                        logger.LogInformation("Eski yedek silindi: {Dosya}", dosya);
                    }
                    catch (Exception ex)
                    {
                        logger.LogWarning(ex, "Eski yedek silinemedi: {Dosya}", dosya);
                    }
                }
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Uygulama açılır açılmaz bir kere yedek al, sonra periyodik devam et
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var context = scope.ServiceProvider.GetRequiredService<MakineContext>();
                    YedekAl(context, _logger);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Otomatik veritabanı yedekleme sırasında hata oluştu.");
                }

                await Task.Delay(YedeklemeAraligi, stoppingToken);
            }
        }
    }
}