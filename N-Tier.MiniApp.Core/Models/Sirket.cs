using System;
using System.Collections.Generic;

namespace N_Tier.MiniApp.Core.Models
{
    public partial class Sirket
    {
        public Sirket()
        {
            Kullanici = new HashSet<Kullanici>();
        }

        public int Id { get; set; }
        public string Sirketadi { get; set; }
        public string Unvan { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public byte[] Logo { get; set; }

        public virtual ICollection<Kullanici> Kullanici { get; set; }
    }
}
