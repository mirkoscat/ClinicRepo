
using DataLayer;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer
{
	public interface IClinicService
	{
		IEnumerable<ClinicAnimal> GetClinicAnimals();
		ClinicAnimal GetClinicAnimalById(int id);
		IEnumerable<ClinicVisit> GetClinicVisitsById(int id);
		Animal GetAnimalByChip(string chip);

        bool CreateClinicAnimal(ClinicAnimal ca);
		bool DeleteClinicAnimal(int id);

		bool CreateClinicVisit(int id, ClinicVisit cv);
		//void Upload(int id,IFormFile file);
		

	}
}