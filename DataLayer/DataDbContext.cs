﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
	public class DataDbContext:DbContext
	{
        public DbSet<Animal> Animals { get; set; }
        public DbSet<ClinicAnimal> ClinicAnimals { get; set; }
        public DbSet<MunicipalAnimal> MunicipalAnimals { get; set; }
        public DbSet<ClinicVisit> ClinicVisits { get; set; }
        public DbSet<MunicipalVisit> MunicipalVisits { get; set; }

        public DataDbContext(DbContextOptions<DataDbContext> opt):base(opt) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClinicAnimal>().ToTable("ClinicAnimal");
            modelBuilder.Entity<MunicipalAnimal> ().ToTable("MunicipalAnimal");
            modelBuilder.Entity<MunicipalVisit> ().ToTable("MunicipalVisit");
        }
    }
}
