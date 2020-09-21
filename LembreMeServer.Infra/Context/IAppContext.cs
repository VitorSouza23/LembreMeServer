using LembreMeServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace LembreMeServer.Infra.Context
{
    public interface IAppContext : IDisposable
    {
        DbSet<Task> Tasks { get; set; }
        DbSet<Location> Locations { get; set; }
        int SaveChanges();
        EntityEntry<T> Entry<T>(T entity) where T : class;
        DbSet<T> Set<T>() where T : class;
    }
}
