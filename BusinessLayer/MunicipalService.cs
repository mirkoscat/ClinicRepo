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
        private readonly DataDbContext _context;
        public MunicipalService(DataDbContext db)
        {
            _context = db;
        }
        public bool CreateMunicipalAnimal(MunicipalAnimal ma)
        {//modificare
            _context.Animals.Add(ma);

            _context.SaveChanges();
            return true;
        }

        public bool CreateMunicipalVisit(int id, MunicipalVisit cv)
        {
            var animal = _context.MunicipalAnimals.Single(x => x.Id == id);
            animal.MunicipalVisits.Add(cv);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteMunicipalAnimal()
        {
            throw new NotImplementedException();
        }

        public Image GetImageById(int id)
        {
            var x = _context.MunicipalAnimals.Single(x => x.Id == id);
            return new Image { Data = x.Picture, Extension = x.FileExtension };
        }
        public MunicipalAnimal GetMunicipalAnimalById(int id) => _context.MunicipalAnimals.Include(x => x.MunicipalVisits).Single(x => x.Id == id);

        public IEnumerable<MunicipalAnimal> GetMunicipalAnimals() => _context.MunicipalAnimals.ToList();

        public IEnumerable<MunicipalVisit> GetMunicipalVisitsInRecovery() => _context.MunicipalVisits.Include(x=>x.MunicipalAnimals).Where(x=>x.Status==(RecoveryStatus)1).OrderByDescending(x=>x.VisitDate).ToList();


		public MunicipalVisit GetMunicipalVisitById(int id)
        {
            var animal = _context.MunicipalAnimals.Include(a => a.MunicipalVisits).FirstOrDefault(a => a.Id == id);
            var visit = animal.MunicipalVisits.FirstOrDefault(a => a.Id == id);
            return visit;

        }
      
    }
}
