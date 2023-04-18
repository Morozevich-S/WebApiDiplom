using Microsoft.EntityFrameworkCore;
using WebApiDiplom.Models;

namespace WebApiDiplom.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<BrandCar>  BrandCars { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientBrandCar> ClientBrandCars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<RentalContract> RentalContracts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<CarModel> CarModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientBrandCar>()
                .HasKey(cbc => new { cbc.ClientId, cbc.BrandCarId });
            modelBuilder.Entity<ClientBrandCar>()
                .HasOne(c => c.Client)
                .WithMany(cbc => cbc.ClientBrandCars)
                .HasForeignKey(c => c.ClientId);
            modelBuilder.Entity<ClientBrandCar>()
             .HasOne(b => b.BrandCar)
             .WithMany(cbc => cbc.ClientBrandCars)
             .HasForeignKey(b => b.BrandCarId);
        }
    }
}
