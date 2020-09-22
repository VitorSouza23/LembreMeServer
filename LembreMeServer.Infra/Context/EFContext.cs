using LembreMeServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskDomain = LembreMeServer.Domain.Entities.Task;


namespace LembreMeServer.Infra.Context
{
    public class EFContext : DbContext, IAppContext
    {
        public DbSet<TaskDomain> Tasks { get; set; }
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
