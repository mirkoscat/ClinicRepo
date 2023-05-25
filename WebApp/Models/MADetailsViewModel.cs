using DataLayer;

namespace WebApp.Models
{
	public class MADetailsViewModel
	{
        public MunicipalAnimal MunicipalAnimal { get; set; }=new MunicipalAnimal();
    
        public List<MunicipalVisit> MunicipalVisits { get; set; }=new List<MunicipalVisit>();
    }
}
