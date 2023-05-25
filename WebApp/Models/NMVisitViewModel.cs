using DataLayer;

namespace WebApp.Models
{
	public class NMVisitViewModel
	{
		public MunicipalAnimal MunicipalAnimal { get; set; } = new MunicipalAnimal();
		public MunicipalVisit MunicipalVisit { get; set; } = new MunicipalVisit();
	}
}
