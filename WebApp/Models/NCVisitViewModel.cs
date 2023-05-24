using System.ComponentModel.DataAnnotations;
using DataLayer;

namespace WebApp.Models
{
	public class NCVisitViewModel
	{
		public ClinicAnimal ClinicAnimal { get ; set; } = new ClinicAnimal();
		public ClinicVisit ClinicVisit { get; set; } = new ClinicVisit();
	}
}
