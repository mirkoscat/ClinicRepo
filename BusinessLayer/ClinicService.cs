using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
	public class ClinicService : IClinicService
	{
		public bool CreateClinicAnimal()
		{
			throw new NotImplementedException();
		}

		public bool DeleteClinicAnimal()
		{
			throw new NotImplementedException();
		}

		public ClinicAnimal GetClinicAnimalById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ClinicAnimal> GetClinicAnimals()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ClinicVisit> GetClinicVisitsById(int id)
		{
			throw new NotImplementedException();
		}
		public Animal GetAnimalByChip(string chip)
        {
            throw new NotImplementedException();
        }
    }
}
