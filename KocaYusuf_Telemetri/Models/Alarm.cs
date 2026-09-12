using System;

namespace KocaYusuf_Telemetri.Models
{
    public class Alarm
    {
        public int ID { get; set; }
        public int MakineID { get; set; }
        public string? AlarmMesaji { get; set; }
        public DateTime BaslangicZamani { get; set; }
        public DateTime? BitisZamani { get; set; }
        public int? SureDakika { get; set; }
        public bool AktifMi { get; set; }

        public Makine? Makine { get; set; }
    }
}