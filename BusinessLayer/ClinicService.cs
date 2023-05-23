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
		private readonly DataDbContext db;
        public ClinicService(DataDbContext db)
        {
            this.db = db;
        }
        public bool CreateClinicAnimal(ClinicAnimal ca)
		{
			db.ClinicAnimals.Add(new ClinicAnimal { 
			Name=ca.Name,
			Typology=ca.Typology,
			BirthDate=ca.BirthDate,
			RegistrationDate=ca.RegistrationDate,
			CoatColor=ca.CoatColor,
			HasMicrochip=ca.HasMicrochip,
			MicrochipNumber=ca.MicrochipNumber,
			OwnerName=ca.OwnerName,
			OwnerLastName=ca.OwnerLastName
			});
			db.SaveChanges();
			return true;
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
