using LembreMeServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading;
using System.Threading.Tasks;
using TaskDomain = LembreMeServer.Domain.Entities.Task;

namespace LembreMeServer.Infra.Context
{
    public interface IAppContext : IDisposable
    {
        DbSet<TaskDomain> Tasks { get; set; }
        DbSet<Location> Locations { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry<T> Entry<T>(T entity) where T : class;
        DbSet<T> Set<T>() where T : class;
    }
}
