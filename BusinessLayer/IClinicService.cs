
using DataLayer;

namespace BusinessLayer
{
	public interface IClinicService
	{
		IEnumerable<ClinicAnimal> GetClinicAnimals();
		ClinicAnimal GetClinicAnimalById(int id);
		IEnumerable<ClinicVisit> GetClinicVisitsById(int id);
		Animal GetAnimalByChip(string chip);

        bool CreateClinicAnimal(ClinicAnimal ca);
		bool DeleteClinicAnimal();


	}
}