using KocaYusuf_Telemetri.Models;
using KocaYusuf_Telemetri.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MVC mimarisini projeye dahil ediyoruz
builder.Services.AddControllersWithViews();

// ÝÞTE ANA ÞALTER: SQL Veritabaný köprümüzü (Context) sisteme tanýtýyoruz
builder.Services.AddDbContext<MakineContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Otomatik günlük veritabaný yedekleme servisini kaydediyoruz
builder.Services.AddHostedService<YedeklemeService>();

var app = builder.Build();

// Hata yönetimi ve yönlendirmeler
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Varsayýlan açýlýþ sayfasýný belirliyoruz
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();