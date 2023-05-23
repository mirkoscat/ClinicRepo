﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.EntityFrameworkCore;

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
			db.Animals.Add(new ClinicAnimal { 
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

		public bool DeleteClinicAnimal(int id)
        { 
			var animal= db.ClinicAnimals.FirstOrDefault(c => c.Id==id);
			db.ClinicAnimals.Remove(animal);
			db.SaveChanges();
			return true;

		}

		public ClinicAnimal GetClinicAnimalById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ClinicAnimal> GetClinicAnimals() => db.Animals.Select(c=> new ClinicAnimal {
		Name = c.Name,Typology=c.Typology, BirthDate=c.BirthDate,RegistrationDate=c.RegistrationDate,
		CoatColor=c.CoatColor, HasMicrochip=c.HasMicrochip, MicrochipNumber=c.MicrochipNumber,
		OwnerName=c.OwnerName,OwnerLastName=c.OwnerLastName
		});
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
