using DataLayer;

namespace WebApp.Models
{
    public class EditMunicipalAnimalViewModel
    {
        public MunicipalAnimal MunicipalAnimal { get; set; }= new MunicipalAnimal();
        public MunicipalVisit MunicipalVisit { get; set; } = new MunicipalVisit();
    
    }
}
