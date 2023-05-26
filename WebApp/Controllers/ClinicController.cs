

using System.Data;
using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
	[Authorize(Roles = "SuperAdmin")]
	//[Authorize(Roles = "VetClinic")]
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
			var list = cs.GetClinicAnimals();
			return View(list);
		}

		// GET: ClinicController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ClinicController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection, ClinicAnimal ca)
		{
			if (ModelState.IsValid)
			{

				var result = cs.CreateClinicAnimal(ca);
				if (result != false)
					return RedirectToAction(nameof(Index));
			}

			return View(ca);
		}
		

        public ActionResult CADetails(int id)
		{
			var animal=cs.GetClinicAnimalById(id);
			var visite= cs.GetClinicVisitsById(id).ToList();
			var model = new CADetailsViewModel
			{
				ClinicAnimal = animal,
				ClinicVisitList = visite
			};

			return View(model);
		}
		public ActionResult NewClinicVisit(int id)
		{
			var animal= cs.GetClinicAnimalById(id);

			var model = new NCVisitViewModel
			{
				ClinicAnimal = animal,
				ClinicVisit= new ClinicVisit() { 
				VisitDate=DateTime.Today
				}

			};

			return View(model);
           


        }
		[HttpPost]
		public ActionResult NewClinicVisit(int id, NCVisitViewModel model)
		{
			
			if (ModelState.IsValid) {
				var idanim=id;
				var x = new ClinicVisit() { 
				VisitDate= model.ClinicVisit.VisitDate,
				ExamTypology= model.ClinicVisit.ExamTypology,
				TreatmentDescription=model.ClinicVisit.TreatmentDescription,
				DescriptionBeforeVisit=model.ClinicVisit.DescriptionBeforeVisit				
				};
				
				var result = cs.CreateClinicVisit(idanim ,x);
				if(result != false)

				return RedirectToAction("Index","Clinic");
			}
			return View(model);
		}
	

		// GET: ClinicController/Delete/5
		public ActionResult Delete(int id)
		{
			var result = cs.DeleteClinicAnimal(id);
			if (result != false)
				return RedirectToAction(nameof(Index));
			return View();
		}

		
	}
}
