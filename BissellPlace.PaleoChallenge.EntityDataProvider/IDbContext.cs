using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BissellPlace.PaleoChallenge.EntityDataProvider
{
    public interface IDbContext : IDisposable
    {
        Database Database { get; }
        DbEntityEntry Entry(object entity);
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}