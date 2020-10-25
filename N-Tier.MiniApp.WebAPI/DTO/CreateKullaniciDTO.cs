using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.WebAPI.DTO
{
    public class CreateKullaniciDTO
    { 
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public DateTime? Dogumtarihi { get; set; }
        public string Email { get; set; }
        public string Pasword { get; set; }
        public int? Gorev { get; set; }
        public int? Sirket { get; set; }
    }
}
