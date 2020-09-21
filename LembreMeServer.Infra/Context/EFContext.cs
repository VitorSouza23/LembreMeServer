using LembreMeServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LembreMeServer.Infra.Context
{
    public class EFContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LembreMeServer.Database;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
