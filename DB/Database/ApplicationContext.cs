using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>()
                .HasKey(b => b.BeerID);
            modelBuilder.Entity<Brand>()
                .HasKey(b => b.BrandID);
            modelBuilder.Entity<Beer>()
                .HasOne(b => b.Brand)
                .WithMany(b => b.Beers)
                .HasForeignKey(b => b.BrandID);
        }
    }
}
