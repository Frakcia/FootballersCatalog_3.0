using FootballersCatalog.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballersCatalog.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Team> Teams { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
           new Country[]
           {
                new Country { Id=1, Name="Russia"},
                new Country { Id=2, Name="USA"},
                new Country { Id=3, Name="Italy"}
           });

            modelBuilder.Entity<Team>().HasData(
           new Team[]
           {
                new Team { Id=1, Name="Barsa"},
                new Team { Id=2, Name="Sparta"},
                new Team { Id=3, Name="Arka"}
           });

            modelBuilder
                .Entity<Country>()
                .HasMany(u => u.Footballers)
                .WithOne(p => p.Country);

            modelBuilder
                .Entity<Team>()
                .HasMany(u => u.Footballers)
                .WithOne(p => p.Team);
        }
    }
}
