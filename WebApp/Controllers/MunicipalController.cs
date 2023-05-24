using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class MunicipalController : Controller
    {
        private static int fileCounter = 0;
        private readonly IMunicipalService ms;
        public MunicipalController(IMunicipalService ms)
        {
            this.ms = ms;
        }
        // GET: MunicipalController
        public ActionResult Index()
        {
            var list=ms.GetMunicipalAnimals();
            return View(list);
        }

        // GET: MunicipalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult CreateMunAnimal()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateMunAnimal(UploadMunicipalAnimal ma)
        {
            if (ModelState.IsValid)
            {
                byte[] foto;
                using (var memoryStream = new MemoryStream())
                {
                    ma.Picture.CopyTo(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin); // Riavvolge lo stream all'inizio

                    var fieldName = $"Picture{fileCounter++}";

                    foto = memoryStream.ToArray();
                }

                // cs.Upload(ma.Id, ma.Picture);


                var municipalAnimal = new MunicipalAnimal
                {
                    Name = ma.Name,
                    Typology = ma.Typology,
                    CoatColor = ma.CoatColor,
                    RecoveryStart = ma.RecoveryStart,
                    RecoveryEnd = ma.RecoveryEnd,
                    IsInHospital = ma.IsInHospital,
                    Picture = foto

                };

                var result = ms.CreateMunicipalAnimal(municipalAnimal);
                if (result)
                    return RedirectToAction(nameof(Index));
            }

            return View(ma);
        }




        // GET: MunicipalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MunicipalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MunicipalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MunicipalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
