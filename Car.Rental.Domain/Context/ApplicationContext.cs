using Car.Rental.Domain.Entities;
using Car.Rental.Domain.EntitiesMapping;
using Microsoft.EntityFrameworkCore;

namespace Car.Rental.Domain.Context
{
    public partial class ApplicationContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Address> Address { get; set; }

        public ApplicationContext()
        {
        }
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
        }
    }
}
