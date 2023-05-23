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
        public bool CreateMunicipalAnimal(MunicipalAnimal ca)
        {
            db.Animals.Add(new MunicipalAnimal
            {
                Name = ca.Name,
                Typology = ca.Typology,
                BirthDate = ca.BirthDate,
                RegistrationDate = ca.RegistrationDate,
                CoatColor = ca.CoatColor,
                Picture=ca.Picture,
                RecoveryStart = ca.RecoveryStart,
                RecoveryEnd = ca.RecoveryEnd,
                IsInHospital = ca.IsInHospital,
                MicrochipNumber = ca.MicrochipNumber,
                HasMicrochip= ca.HasMicrochip,
              
            });
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
