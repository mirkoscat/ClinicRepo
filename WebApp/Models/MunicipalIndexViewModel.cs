using DataLayer;

namespace WebApp.Models
{
	public class MunicipalIndexViewModel
	{
		public List<MunicipalAnimal> Animals { get; set; } = new List<MunicipalAnimal>();
		public List<MunicipalVisit> Visits { get; set; } = new List<MunicipalVisit>();
	}
}
