using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Owner>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PortfolioItem>().Property(p => p.Id).HasDefaultValueSql("NEWID()");

            var addressId = Guid.Parse("11111111-1111-1111-1111-111111111111");

            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = addressId,
                    City = "Alex",
                    Street = "Al-Tahreer",
                    Number = 10
                });

            modelBuilder.Entity<Owner>().HasData(
                new Owner
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    FullName = "Youssef Waeel",
                    Avatar = "Avatar.jpg",
                    profile = "Asp.Net Developer",
                    AddressId = addressId,
                });

        }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PortfolioItem> portfolioItems { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
