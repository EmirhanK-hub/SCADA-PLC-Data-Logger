using System.Collections.Generic;
using System.Security.Claims;

namespace KocaYusuf_Telemetri.Models
{
    public class Makine
    {
        public int ID { get; set; }
        public string? MakineAdi { get; set; }
        public string? MakineNo { get; set; }
        public string? Durum { get; set; }
        public ICollection<MakineVerisi> Veriler { get; set; } = new List<MakineVerisi>();
        public ICollection<Alarm> Alarmlar { get; set; } = new List<Alarm>();
    }
}