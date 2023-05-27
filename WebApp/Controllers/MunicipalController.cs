using System.Data;
using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using WebApp.Models;

namespace WebApp.Controllers
{
	[Authorize(Roles = "SuperAdmin")]

	public class MunicipalController : Controller
    {
        private static int fileCounter = 0;
        private readonly IMunicipalService _munService;
        public MunicipalController(IMunicipalService ms)
        {
            _munService = ms;
        }
		// GET: MunicipalController
		public ActionResult Index()
		{// must create model
            var list = _munService.GetMunicipalAnimals().Where(x=>x.IsInHospital==true);
            //var list = _munService.GetMunicipalVisitsInRecovery().ToList();
            //var animals = _munService.GetMunicipalAnimals().Where(x=>x.IsInHospital==true).ToList();
            //var model = new MunicipalIndexViewModel { 
            //Visits=list,
            //Animals=animals
            //};

			return View(list);
		}
		public ActionResult NewMunicipalVisit(int id)
		{
			var animal = _munService.GetMunicipalAnimalById(id);

            var model = new NMVisitViewModel
            {
				MunicipalAnimal = animal,
				MunicipalVisit = new MunicipalVisit() { 
                VisitDate = DateTime.Today,
                PaymentDate = DateTime.Today
				}
            };

            return View(model);
           
           
		}

        [HttpPost]
        public ActionResult NewMunicipalVisit(int id, NMVisitViewModel model)
        {
                var animal = _munService.GetMunicipalAnimalById(id);

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
              
               _munService.CreateMunicipalVisit(animal.Id, x);
                

               return RedirectToAction("Index", "Municipal");
          
        }
		public ActionResult MADetails(int id)
		{
			var animal = _munService.GetMunicipalAnimalById(id);
			var visite = animal.MunicipalVisits.OrderByDescending(x=>x.VisitDate).ToList();
			var model = new MADetailsViewModel
			{
				MunicipalAnimal = animal,
				MunicipalVisits = visite
			};

			return View(model);
		}
        [AllowAnonymous]
		public IActionResult GetImage(int id)
        {
            var img = _munService.GetImageById(id);
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
                    memoryStream.Seek(0, SeekOrigin.Begin); 
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
                    FileExtension=ma.Picture.ContentType,
                    MicrochipNumber = ma.MicrochipNumber,
                    HasMicrochip = ma.HasMicrochip
                   
                };

                var result = _munService.CreateMunicipalAnimal(municipalAnimal);
                if (result)
                    return RedirectToAction(nameof(Index));
            }

            return View(ma);
        }

    }
}
