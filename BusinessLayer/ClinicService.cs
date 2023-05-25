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
		private readonly DataDbContext db;
        public ClinicService(DataDbContext db)
        {
            this.db = db;
        }
        public bool CreateClinicAnimal(ClinicAnimal ca)
		{
			db.Animals.Add(ca);
			db.SaveChanges();
			return true;
		}

		public bool DeleteClinicAnimal(int id)
        { 
			var animal= db.Animals.FirstOrDefault(c => c.Id==id);
			db.Animals.Remove(animal);
			db.SaveChanges();
			return true;

		}

		public ClinicAnimal GetClinicAnimalById(int id) => db.ClinicAnimals.Single(x=>x.Id==id);
        public IEnumerable<ClinicAnimal> GetClinicAnimals() => db.ClinicAnimals.ToList();
        public IEnumerable<ClinicVisit> GetClinicVisitsById(int id)
        {
			var animal = db.ClinicAnimals.Include(a => a.ClinicVisits).FirstOrDefault(a => a.Id == id);

			if (animal != null)
			{
				var visits = animal.ClinicVisits.ToList();
				return visits;
			}

			return Enumerable.Empty<ClinicVisit>();
		}

		public AllAnimals GetAnimalByChip(string chip) {
			var animals= new AllAnimals();	
			
			animals.ClinicAnimal = db.ClinicAnimals.FirstOrDefault(x => x.MicrochipNumber == chip);
            animals.MunicipalAnimal = db.MunicipalAnimals.FirstOrDefault(x => x.MicrochipNumber == chip);

			return animals;


        }
		

        public bool CreateClinicVisit(int id,ClinicVisit cv)
        {
			var animal = db.ClinicAnimals.Single(x=>x.Id==id);
			animal.ClinicVisits.Add(cv);	
			db.SaveChanges();
			return true;
        }
   //     public void Upload(int id, IFormFile image)
   //     {
			//var img = image;
			//var animal=db.MunicipalAnimals.Single(x => x.Id == id);
			//animal.Picture = img;
   //         db.SaveChanges();
   //     }
    }
}
