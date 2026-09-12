using Microsoft.EntityFrameworkCore;

namespace KocaYusuf_Telemetri.Models
{
    public class MakineContext : DbContext
    {
        public MakineContext(DbContextOptions<MakineContext> options) : base(options)
        {
        }

        public DbSet<Makine> Makineler { get; set; }
        public DbSet<MakineVerisi> MakineVerileri { get; set; }
        public DbSet<Alarm> Alarmlar { get; set; }

        public DbSet<IletisimMesaji> IletisimMesajlari { get; set; }
    }
}