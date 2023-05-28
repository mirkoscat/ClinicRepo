using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLayer
{
	public class ClinicService : IClinicService
	{
		private readonly DataDbContext _context;
        public ClinicService(DataDbContext db)
        {
            _context = db;
        }
        public bool CreateClinicAnimal(ClinicAnimal ca)
		{
			_context.Animals.Add(ca);
			_context.SaveChanges();
			return true;
		}

		public bool DeleteClinicAnimal(int id)
        { 
			var animal= _context.Animals.FirstOrDefault(c => c.Id==id);
			_context.Animals.Remove(animal);
			_context.SaveChanges();
			return true;

		}

		public ClinicAnimal GetClinicAnimalById(int id) => _context.ClinicAnimals.Single(x=>x.Id==id);
        public IEnumerable<ClinicAnimal> GetClinicAnimals() => _context.ClinicAnimals.ToList();
        public IEnumerable<ClinicVisit> GetClinicVisitsById(int id)
        {
			var animal = _context.ClinicAnimals.Include(a => a.ClinicVisits).FirstOrDefault(a => a.Id == id);

			if (animal != null)
			{
				var visits = animal.ClinicVisits.ToList();
				return visits;
			}

			return Enumerable.Empty<ClinicVisit>();
		}

		public AllAnimals GetAnimalByChip(string chip) {
			var animals= new AllAnimals();	
			
			animals.ClinicAnimal = _context.ClinicAnimals.FirstOrDefault(x => x.MicrochipNumber == chip);
            animals.MunicipalAnimal = _context.MunicipalAnimals.FirstOrDefault(x => x.MicrochipNumber == chip);

			return animals;


        }
		

        public bool CreateClinicVisit(int id,ClinicVisit clinicVisit)
        {
			var animal = _context.ClinicAnimals.Single(x=>x.Id==id);
			animal.ClinicVisits.Add(clinicVisit);	
			_context.SaveChanges();
			return true;
        }



		public bool EditClinicAnimal(int id, ClinicAnimal clinicAnimal)
		{
			var animal = _context.ClinicAnimals.Single(x => x.Id == id);
			animal.Name = clinicAnimal.Name;
			animal.OwnerName= clinicAnimal.OwnerName;
			animal.OwnerLastName = clinicAnimal.OwnerLastName;
			animal.HasMicrochip = clinicAnimal.HasMicrochip;
			animal.MicrochipNumber = clinicAnimal.MicrochipNumber;
			_context.SaveChanges();
			return true;
		}


	}
}
