using System.Diagnostics;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IClinicService _clinicService;

		public HomeController(ILogger<HomeController> logger, IClinicService cs)
		{
			_logger = logger;
			_clinicService = cs;
		}

		public IActionResult Index()
		{
			return View();
		}
        public IActionResult FindAnimal(string? id)
        {
			if (id != null) {
				
			var animal=_clinicService.GetAnimalByChip(id);
			return View(animal);
            }
            return View();
           
        }

	}
}