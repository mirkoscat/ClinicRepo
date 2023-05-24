using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

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

        public bool DeleteMunicipalAnimal()
        {
            throw new NotImplementedException();
        }

        public MunicipalAnimal GetMunicipalAnimalById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MunicipalAnimal> GetMunicipalAnimals()
        {
            throw new NotImplementedException();
        }
    }
}
