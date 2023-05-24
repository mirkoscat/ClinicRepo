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
        public IActionResult FindAnimal()
        {
            return View();
        }

        [HttpPost]
		public IActionResult FindAnimal(string chip)
		{
			var animal=cs.GetAnimalByChip(chip);
			return View(animal);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}