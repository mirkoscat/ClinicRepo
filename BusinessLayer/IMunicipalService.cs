using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
	public interface IMunicipalService
	{
		IEnumerable<MunicipalAnimal> GetMunicipalAnimals();
		MunicipalAnimal GetMunicipalAnimalById(int id);
		bool CreateMunicipalAnimal(MunicipalAnimal ma);
		bool DeleteMunicipalAnimal();
        Image GetImageById(int id);
		MunicipalVisit GetMunicipalVisitById(int id);
		bool CreateMunicipalVisit(int id, MunicipalVisit cv);

		IEnumerable<MunicipalAnimal> GetMunicipalAnimalsInRecovery();
		//IEnumerable<MunicipalVisit> GetMunicipalVisitsByAnimal(int id);
	}
}
