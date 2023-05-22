
using DataLayer;

namespace BusinessLayer
{
	public interface IClinicService
	{
		IEnumerable<ClinicAnimal> GetClinicAnimals();
		ClinicAnimal GetClinicAnimalById(int id);
		IEnumerable<ClinicVisit> GetClinicVisitsById(int id);
		bool CreateClinicAnimal();
		bool DeleteClinicAnimal();


	}
}