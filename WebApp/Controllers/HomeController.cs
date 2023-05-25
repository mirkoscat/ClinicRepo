using System.Diagnostics;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IClinicService cs;

		public HomeController(ILogger<HomeController> logger, IClinicService cs)
		{
			_logger = logger;
			this.cs = cs;
		}

		public IActionResult Index()
		{
			return View();
		}
        public IActionResult FindAnimal(string? id)
        {
			if (id != null) {
				
			var animal=cs.GetAnimalByChip(id);
			return View(animal);
            }
            return View();
           
        }

	}
}