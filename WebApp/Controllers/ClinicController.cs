using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ClinicController : Controller
    {
        private readonly IClinicService cs;
        private readonly IMunicipalService ms;
        public ClinicController(IClinicService cs, IMunicipalService ms)
        {
            this.cs = cs;
            this.ms = ms;

        }
        // GET: ClinicController
        public ActionResult Index()
        {
            var list= cs.GetClinicAnimals();
            return View(list);
        }

        // GET: ClinicController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClinicController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClinicController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection,ClinicAnimal ca)
        {
            if (ModelState.IsValid) {
                
                var result = cs.CreateClinicAnimal(ca);
                if (result != false)
                    return RedirectToAction(nameof(Index));
            }
              
           return View(ca);
        }
        public ActionResult CreateMunAnimal()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateMunAnimal(MunicipalAnimal ma)
        {
            if (ModelState.IsValid)
            {

                var result = ms.CreateMunicipalAnimal(ma);
                if (result != false)
                    return RedirectToAction(nameof(Index));
            }
            return View();
        }
		public ActionResult CADetails(int id)
		{
          //  lista delle visite dell'animale in ordine cronologico inverso
         // var list= cs.GetClinicVisitsById(id);
			return View();
		}

		// GET: ClinicController/Edit/5
		public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClinicController/Edit/5
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

        // GET: ClinicController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClinicController/Delete/5
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
