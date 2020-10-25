using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N_Tier.MiniApp.Core.Models
{
    public partial class Kullanici
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public DateTime? Dogumtarihi { get; set; }
        public string Email { get; set; }
        public string Pasword { get; set; }
        public int? Gorev { get; set; }
        public int? Sirket { get; set; }

        public virtual Gorev GorevNavigation { get; set; }
        public virtual Sirket SirketNavigation { get; set; }
    }
}
