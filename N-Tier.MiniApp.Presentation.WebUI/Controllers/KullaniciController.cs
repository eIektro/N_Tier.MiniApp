using N_Tier.MiniApp.Core.Models;
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
    
    public class KullaniciController : Controller
    {
        readonly string apiBaseAddress = ConfigurationManager.AppSettings["apiBaseAdress"];

        // GET: Kullanici
        public async Task <ActionResult> Index()
        {
            IEnumerable<Kullanici> kullanicilar = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var result = await client.GetAsync("Kullanici");

                if (result.IsSuccessStatusCode)
                {
                    kullanicilar = await result.Content.ReadAsAsync<IList<Kullanici>>();
                }
                else
                {
                    kullanicilar = Enumerable.Empty<Kullanici>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(kullanicilar);
        }

        // GET: Kullanici/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Kullanici kullanici = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var result = await client.GetAsync($"Kullanici/Details/{id}");

                if (result.IsSuccessStatusCode)
                {
                    kullanici = await result.Content.ReadAsAsync<Kullanici>();
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

        // GET: Kullanici/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kullanici/Create
        [HttpPost]
        public async Task< ActionResult> Create([Bind(Include = "Id,Isim,Soyisim,Dogumtarihi,Email,Pasword, Gorev, Sirket")] Kullanici kullanici)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(apiBaseAddress);

                        var response = await client.PostAsJsonAsync("Kullanici", kullanici);
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Server error.");
                        }
                    }
                }
                return View(kullanici);

                
            }
            catch
            {
                return View();
            }
        }

        // GET: Kullanici/Edit/5
        public async Task<ActionResult> Edit(int Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var result = await client.GetAsync($"Kullanici/{Id}");

                if (result.IsSuccessStatusCode)
                {
                    kullanici = await result.Content.ReadAsAsync<Kullanici>();
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

       
        // POST: Kullanici/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Edit([Bind(Include = "Id,Isim,Soyisim,Dogumtarihi,Email,Pasword, Gorev, Sirket")] Kullanici kullanici)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(apiBaseAddress);
                        var response = await client.PutAsJsonAsync("Kullanici/{id}", kullanici);
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Server error.");
                        }
                    }
                    return RedirectToAction("Index");
                }
                return View(kullanici);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kullanici/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kullanici/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
