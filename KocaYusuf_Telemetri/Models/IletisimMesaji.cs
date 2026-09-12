using System;
using System.ComponentModel.DataAnnotations;

namespace KocaYusuf_Telemetri.Models
{
    public class IletisimMesaji
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Ad Soyad alanı zorunludur.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Ad Soyad 3 ile 100 karakter arasında olmalıdır.")]
        [RegularExpression(@"^[a-zA-ZçÇğĞıİöÖşŞüÜ\s]+$", ErrorMessage = "Ad Soyad yalnızca harf ve boşluk içerebilir.")]
        public string? AdSoyad { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [RegularExpression(@"^(\+90|0)?5[0-9]{9}$", ErrorMessage = "Geçerli bir telefon numarası giriniz (Örn: 05554443322).")]
        public string? Telefon { get; set; }

        [Required(ErrorMessage = "Mesaj alanı zorunludur.")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Mesaj en az 10, en fazla 1000 karakter olmalıdır.")]
        public string? Mesaj { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime GonderimZamani { get; set; } = DateTime.Now;

        public bool OkunduMu { get; set; } = false;
    }
}