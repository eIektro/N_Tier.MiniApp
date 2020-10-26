using N_Tier.MiniApp.Presentation.WebUI.Core;
using N_Tier.MiniApp.Presentation.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace N_Tier.MiniApp.Presentation.WebUI.Controllers
{
    public class KullanicilarController : Controller
    {
        readonly string apiBaseAddress = ConfigurationManager.AppSettings["apiBaseAdress"];

        public async Task<ActionResult> Index()
        {
            IEnumerable<KullaniciViewModel> kullanicis = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var httpResponse = await client.GetAsync("Kullanici");

                if (httpResponse.IsSuccessStatusCode)
                {
                    kullanicis = await httpResponse.Content.ReadAsAsync<IList<KullaniciViewModel>>();
                    
                }
                else
                {
                    kullanicis = Enumerable.Empty<KullaniciViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }

            
            return View(kullanicis);
        }

        public async Task<ActionResult> Details(int Id)
        {

            KullaniciViewModel kullanici = null;
            SirketViewModel sirket = null;
            GorevViewModel gorev = null;

            String sirketAdi = "";
            String gorevAdi = "";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var httpResponseKullanici = await client.GetAsync($"Kullanici/{Id}");
                

                if (httpResponseKullanici.IsSuccessStatusCode)
                {
                    kullanici = await httpResponseKullanici.Content.ReadAsAsync<KullaniciViewModel>();

                    var httpResponseSirket = await client.GetAsync($"Sirket/{kullanici.Sirket}");

                    if (httpResponseSirket.IsSuccessStatusCode)
                    {
                        sirket = await httpResponseSirket.Content.ReadAsAsync<SirketViewModel>();
                        sirketAdi = sirket.SirketAdi;
                        ViewBag.SirketAdi = sirketAdi;
                    }

                    if (kullanici.Gorev != null)
                    {
                        var httpResponseGorev = await client.GetAsync($"Gorev/{kullanici.Gorev}");

                        if (httpResponseGorev.IsSuccessStatusCode)
                        {
                            gorev = await httpResponseGorev.Content.ReadAsAsync<GorevViewModel>();
                            gorevAdi = gorev.GorevAdi;
                            ViewBag.GorevAdi = gorevAdi;
                        } 
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }

            if (kullanici == null)
            {
                return HttpNotFound();
            }

            return View(kullanici);

        }

        public async Task<ActionResult> Edit(int id)
        {
            ApiTransactions apiTransactions = new ApiTransactions();
            IEnumerable < SirketViewModel > sirkets = await apiTransactions.tumSirketleriGetir();
            IEnumerable<GorevViewModel> gorevs = await apiTransactions.tumGorevleriGetir();
            KullaniciViewModel kullanici = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var httpResponse = await client.GetAsync($"Kullanici/{id}");

                if (httpResponse.IsSuccessStatusCode)
                {
                    kullanici = await httpResponse.Content.ReadAsAsync<KullaniciViewModel>();
                    kullanici.SirketViewModel = sirkets;
                    kullanici.GorevViewModel = gorevs;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, CreateKullaniciViewModel kullaniciResource)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseAddress);
                    var httpResponse = await client.PutAsJsonAsync($"Kullanici/{id}", kullaniciResource);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error try after some time.");
                    }
                }
                return RedirectToAction("Index");
            }
            return View(kullaniciResource);
        }

        public async Task<ActionResult> Delete(int id)
        {
            KullaniciViewModel kullanici = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var httpResponse = await client.GetAsync($"Kullanici/{id}");

                if (httpResponse.IsSuccessStatusCode)
                {
                    kullanici = await httpResponse.Content.ReadAsAsync<KullaniciViewModel>();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }

            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var httpResponse = await client.DeleteAsync($"Kullanici/{id}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                    ModelState.AddModelError(string.Empty, "Server error.");
            }
            return View();
        }

        public async Task<ActionResult> Create()
        {
            ApiTransactions apiTransactions = new ApiTransactions();
            IEnumerable<SirketViewModel> sirkets = await apiTransactions.tumSirketleriGetir();
            IEnumerable<GorevViewModel> gorevs = await apiTransactions.tumGorevleriGetir();
            var model = new CreateKullaniciViewModel();
            model.GorevViewModel = gorevs;
            model.SirketViewModel = sirkets;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateKullaniciViewModel kullaniciResource)
        {
          
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseAddress);
                    
                    var httpResponse = await client.PostAsJsonAsync("Kullanici", kullaniciResource);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error.");
                    }
                }
            }
            return View(kullaniciResource);
        }

    }
}