using DataLayer;

namespace WebApp.Models
{
	public class ClinicAnimalViewModel
	{
		public ICollection<ClinicAnimal> ClinicAnimals { get; set; }= new List<ClinicAnimal>();	
	}
}
