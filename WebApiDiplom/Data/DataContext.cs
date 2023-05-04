using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiDiplom.Models;

namespace WebApiDiplom.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int,
                               IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
                               IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { }

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
        public DbSet<AppUser> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            modelBuilder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

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

            modelBuilder.Entity<Client>()
                .HasIndex(c => c.UserId)
                .IsUnique();
        }
    }
}
