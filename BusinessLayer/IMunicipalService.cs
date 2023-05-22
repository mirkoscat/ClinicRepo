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
		bool CreateMunicipalAnimal();
		bool DeleteMunicipalAnimal();
	}
}
