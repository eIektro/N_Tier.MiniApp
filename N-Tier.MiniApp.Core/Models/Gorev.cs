using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N_Tier.MiniApp.Core.Models
{
    public partial class Gorev
    {
        public Gorev()
        {
            Kullanici = new HashSet<Kullanici>();
        }

        public int Id { get; set; }
        public string Gorevadi { get; set; }
        public string Gorevtanimi { get; set; }

        public virtual ICollection<Kullanici> Kullanici { get; set; }
    }
}
