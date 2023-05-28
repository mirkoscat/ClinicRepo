
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
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ProductCart> ProductCarts { get; set; }
        //public DbSet<CheckOutOrder> CheckOutOrders { get; set; }
       


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
