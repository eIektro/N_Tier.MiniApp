using N_Tier.MiniApp.Presentation.WebUI.Core;
using N_Tier.MiniApp.Presentation.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace N_Tier.MiniApp.Presentation.WebUI.Controllers
{
    public class GorevlerController : Controller
    {
        readonly string apiBaseAddress = ConfigurationManager.AppSettings["apiBaseAdress"];

        public async Task<ActionResult> Index()
        {
            ApiTransactions apiTransactions = new ApiTransactions();

            IEnumerable<GorevViewModel> gorevs = await apiTransactions.tumGorevleriGetir();

            return View(gorevs);
        }

        public async Task<ActionResult> Details(int Id)
        {

            GorevViewModel gorev = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var httpResponse = await client.GetAsync($"Gorev/{Id}");

                if (httpResponse.IsSuccessStatusCode)
                {
                    gorev = await httpResponse.Content.ReadAsAsync<GorevViewModel>();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }

            if (gorev == null)
            {
                return HttpNotFound();
            }

            return View(gorev);

        }

        public async Task<ActionResult> Edit(int id)
        {
            GorevViewModel gorev = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var httpResponse = await client.GetAsync($"Gorev/{id}");

                if (httpResponse.IsSuccessStatusCode)
                {
                    gorev = await httpResponse.Content.ReadAsAsync<GorevViewModel>();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            if (gorev == null)
            {
                return HttpNotFound();
            }
            return View(gorev);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, CreateGorevViewModel gorevResource)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseAddress);
                    var httpResponse = await client.PutAsJsonAsync($"Kullanici/{id}", gorevResource);
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
            return View(gorevResource);
        }

        public async Task<ActionResult> Delete(int id)
        {
            GorevViewModel gorev = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var httpResponse = await client.GetAsync($"Gorev/{id}");

                if (httpResponse.IsSuccessStatusCode)
                {
                    gorev = await httpResponse.Content.ReadAsAsync<GorevViewModel>();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }

            if (gorev == null)
            {
                return HttpNotFound();
            }
            return View(gorev);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var httpResponse = await client.DeleteAsync($"Gorev/{id}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                    ModelState.AddModelError(string.Empty, "Kullanıcılar tarafından referans edilen görev silinemez."); //Bu kısıma daha efektif bir çözüm getirilecek.
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateGorevViewModel gorevResource)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseAddress);

                    var httpResponse = await client.PostAsJsonAsync("Gorev", gorevResource);
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
            return View(gorevResource);
        }
    }
}