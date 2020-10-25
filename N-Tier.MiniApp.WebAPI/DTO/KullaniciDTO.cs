using N_Tier.MiniApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.WebAPI.DTO
{
    public class KullaniciDTO
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public DateTime? Dogumtarihi { get; set; }
        public string Email { get; set; }
        public string Pasword { get; set; }
        public int? Gorev { get; set; }
        public int? Sirket { get; set; }

    }
}
