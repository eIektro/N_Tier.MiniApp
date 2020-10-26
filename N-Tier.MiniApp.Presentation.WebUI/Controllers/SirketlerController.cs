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
    public class SirketlerController : Controller
    {
        readonly string apiBaseAddress = ConfigurationManager.AppSettings["apiBaseAdress"];

        public async Task<ActionResult> Index()
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
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }

            return View(sirkets);
        }

        public async Task<ActionResult> Details(int Id)
        {

            SirketViewModel sirket = null;
            string imgBase64Data = "";
            string imgDataURL = "";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var httpResponse = await client.GetAsync($"Sirket/{Id}");

                if (httpResponse.IsSuccessStatusCode)
                {
                    sirket = await httpResponse.Content.ReadAsAsync<SirketViewModel>();
                    imgBase64Data = Convert.ToBase64String(sirket.Logo);
                    imgDataURL = string.Format("data:image/png;base64,{0}", imgBase64Data);
                    ViewBag.ImageData = imgDataURL;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }

            if (sirket == null)
            {
                return HttpNotFound();
            }

            return View(sirket);

        }

        public async Task<ActionResult> Edit(int id)
        {
            SirketViewModel sirket = null;
            string imgBase64Data = "";
            string imgDataURL = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var httpResponse = await client.GetAsync($"Sirket/{id}");

                if (httpResponse.IsSuccessStatusCode)
                {
                    sirket = await httpResponse.Content.ReadAsAsync<SirketViewModel>();
                    imgBase64Data = Convert.ToBase64String(sirket.Logo);
                    imgDataURL = string.Format("data:image/png;base64,{0}", imgBase64Data);
                    ViewBag.ImageData = imgDataURL;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            if (sirket == null)
            {
                return HttpNotFound();
            }
            return View(sirket);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, CreateSirketViewModel sirketResource)
        {
            var file = Request.Files["Image"];
            if (file != null)
            {
                byte[] fileBytes = new byte[file.ContentLength];
                file.InputStream.Read(fileBytes, 0, file.ContentLength);
                sirketResource.Logo = fileBytes;
            }
            else
            {
                // ... error handling here
            }

            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseAddress);
                    var httpResponse = await client.PutAsJsonAsync($"Sirket/{id}", sirketResource);
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
            return View(sirketResource);
        }

        public async Task<ActionResult> Delete(int id)
        {
            SirketViewModel sirket = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var httpResponse = await client.GetAsync($"Sirket/{id}");

                if (httpResponse.IsSuccessStatusCode)
                {
                    sirket = await httpResponse.Content.ReadAsAsync<SirketViewModel>();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }

            if (sirket == null)
            {
                return HttpNotFound();
            }
            return View(sirket);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var httpResponse = await client.DeleteAsync($"Sirket/{id}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                    ModelState.AddModelError(string.Empty, "Server error.");
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateSirketViewModel sirketResource)
        {
            //TO-DO: Yüklenen resimler kırpılacak. Veya yükleme kısmında Javascrip ile validasyon yapılabilir.
            var file = Request.Files["Image"];
            if (file != null)
            {
                byte[] fileBytes = new byte[file.ContentLength];
                file.InputStream.Read(fileBytes, 0, file.ContentLength);
                sirketResource.Logo = fileBytes;
            }
            else
            {
                // ... error handling here
            }

            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseAddress);

                    var httpResponse = await client.PostAsJsonAsync("Sirket", sirketResource);
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
            return View(sirketResource);
        }
    }

}