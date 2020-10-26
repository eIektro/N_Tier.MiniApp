using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N_Tier.MiniApp.Presentation.WebUI.ViewModels
{
    public class SirketViewModel
    {
        public int Id { get; set; }
        public string SirketAdi { get; set; }
        public string Unvan { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public byte[] Logo { get; set; }
    }
}