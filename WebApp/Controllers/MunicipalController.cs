﻿using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
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
		{//creare visita municipale
			var list = ms.GetMunicipalAnimals();
			return View(list);
		}
		public ActionResult NewMunicipalVisit(int id)
		{
			var animal = ms.GetMunicipalAnimalById(id);

            var model = new NMVisitViewModel
            {
				MunicipalAnimal = animal,
				MunicipalVisit = new MunicipalVisit() { 
                VisitDate = DateTime.Today,
                PaymentDate = DateTime.Today
				}
            };

            return View(model);
            //var list = ms.GetMunicipalAnimals().Where(x=>x.IsInHospital);
           
		}

        [HttpPost]
        public ActionResult NewMunicipalVisit(int id,[Bind("Id")] NMVisitViewModel model)
        {

            if (ModelState.IsValid)
            {
                var idanim = id;
                var x = new MunicipalVisit()
                {
                    VisitDate = model.MunicipalVisit.VisitDate,
                    ExamTypology = model.MunicipalVisit.ExamTypology,
                    TreatmentDescription = model.MunicipalVisit.TreatmentDescription,
                    DescriptionBeforeVisit = model.MunicipalVisit.DescriptionBeforeVisit,
                    Price=model.MunicipalVisit.Price,
                    Status=model.MunicipalVisit.Status,
                    PaymentDate=model.MunicipalVisit.PaymentDate
                 
                };

                var result = ms.CreateMunicipalVisit(idanim, x);
                if (result != false)

                    return RedirectToAction("Index", "Municipal");
            }
            return View(model);
        }
        public IActionResult GetImage(int id)
        {
            var img = ms.GetImageById(id);

			// trasformare l'immagine in file 
			// per restituirla al browser
			return File(img.Data,img.Extension);
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

            
                var municipalAnimal = new MunicipalAnimal
                {
                    Name = ma.Name,
                    Typology = ma.Typology,
                    CoatColor = ma.CoatColor,
                    RecoveryStart = ma.RecoveryStart,
                    RecoveryEnd = ma.RecoveryEnd,
                    IsInHospital = ma.IsInHospital,
                    Picture = foto,
                    FileExtension=ma.Picture.ContentType

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
