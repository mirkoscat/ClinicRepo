using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class MunicipalService : IMunicipalService
    {
        private readonly DataDbContext db;
        public MunicipalService(DataDbContext db)
        {
            this.db = db;
        }
        public bool CreateMunicipalAnimal(MunicipalAnimal ma)
        {//modificare
            db.Animals.Add(ma);

            db.SaveChanges();
            return true;
        }

        public bool CreateMunicipalVisit(int id, MunicipalVisit cv)
        {
            var animal = db.MunicipalAnimals.Single(x => x.Id == id);
            animal.MunicipalVisits.Add(cv);
            db.SaveChanges();
            return true;
        }

        public bool DeleteMunicipalAnimal()
        {
            throw new NotImplementedException();
        }

        public Image GetImageById(int id)
        {
            var x = db.MunicipalAnimals.Single(x => x.Id == id);
            return new Image { Data = x.Picture, Extension = x.FileExtension };
        }
        public MunicipalAnimal GetMunicipalAnimalById(int id) => db.MunicipalAnimals.Include(x => x.MunicipalVisits).Single(x => x.Id == id);

        public IEnumerable<MunicipalAnimal> GetMunicipalAnimals() => db.MunicipalAnimals.ToList();

        public IEnumerable<MunicipalAnimal> GetMunicipalAnimalsInRecovery()
        {//work in progress
            var animals = db.MunicipalAnimals.Where(x => x.IsInHospital == true);
          //  var visits = db.MunicipalVisits.Where(x=>x.Status==(RecoveryStatus)1);
            return animals;
        }

        public MunicipalVisit GetMunicipalVisitById(int id)
        {
            var animal = db.MunicipalAnimals.Include(a => a.MunicipalVisits).FirstOrDefault(a => a.Id == id);


            var visit = animal.MunicipalVisits.FirstOrDefault(a => a.Id == id);
            return visit;

        }
        //public IEnumerable<MunicipalVisit> GetMunicipalVisitsByAnimal(int id) { 
        //var animal=GetMunicipalAnimalById(id);
        
        //}
    }
}
