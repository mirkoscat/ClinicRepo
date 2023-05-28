
using DataLayer;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer
{
	public interface IClinicService
	{
		IEnumerable<ClinicAnimal> GetClinicAnimals();
		ClinicAnimal GetClinicAnimalById(int id);
		IEnumerable<ClinicVisit> GetClinicVisitsById(int id);
		AllAnimals GetAnimalByChip(string chip);

        bool CreateClinicAnimal(ClinicAnimal ca);
		//bool EditClinicAnimal(int id, ClinicAnimal clinicAnimal);
		bool DeleteClinicAnimal(int id);

		bool CreateClinicVisit(int id, ClinicVisit cv);
		/*bool EditClinicAnimal(int id);*/
	}
}