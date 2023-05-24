using DataLayer;

namespace WebApp.Models
{
	public class CADetailsViewModel
	{
        public ClinicAnimal ClinicAnimal { get; set; }
    
        public List<ClinicVisit> ClinicVisitList { get; set; }=new List<ClinicVisit>();
    }
}
