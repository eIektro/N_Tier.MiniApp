using N_Tier.MiniApp.Presentation.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace N_Tier.MiniApp.Presentation.WebUI.Core
{
    public class ApiTransactions
    {
        readonly string apiBaseAddress = ConfigurationManager.AppSettings["apiBaseAdress"];
        public async Task<IEnumerable<SirketViewModel>> tumSirketleriGetir()
        {
            IEnumerable<SirketViewModel> sirkets = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var httpResponse = await client.GetAsync("Sirket");

                if (httpResponse.IsSuccessStatusCode)
                {
                    sirkets = await httpResponse.Content.ReadAsAsync<IList<SirketViewModel>>();

                }
                else
                {
                    sirkets = Enumerable.Empty<SirketViewModel>();
                }
            }

            return sirkets;
        }

        public async Task<IEnumerable<GorevViewModel>> tumGorevleriGetir()
        {
            IEnumerable<GorevViewModel> gorevs = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var httpResponse = await client.GetAsync("Gorev");

                if (httpResponse.IsSuccessStatusCode)
                {
                    gorevs = await httpResponse.Content.ReadAsAsync<IList<GorevViewModel>>();

                }
                else
                {
                    gorevs = Enumerable.Empty<GorevViewModel>();
                    
                }
            }

            return gorevs;
        }

    }
}