using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N_Tier.MiniApp.Presentation.WebUI.ViewModels
{
    public class KullaniciViewModel
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public DateTime? Dogumtarihi { get; set; }
        public string Email { get; set; }
        public string Pasword { get; set; }
        public int? Gorev { get; set; }
        public int? Sirket { get; set; }

        public IEnumerable<SirketViewModel> SirketViewModel { get; set; }
        public IEnumerable<GorevViewModel> GorevViewModel { get; set; }
    }
}