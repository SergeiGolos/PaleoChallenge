using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using BissellPlace.PaleoChallenge.Framework.DomainModel;
using System.Collections.Generic;
using Castle.Core.Internal;
using BissellPlace.PaleoChallenge.Framework;

namespace BissellPlace.PaleoChallenge.EntityDataProvider
{
    public class PaleoChallengeContext : DbContext, IDbContext
    {
        public PaleoChallengeContext(ISystemConfiguration config)
            : base("PaleoChallengeContext")
        {
            Database.SetInitializer(new CreateWithSeed(config.CreateNewDatabase));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Entry> Entries { get; set; }

        public DbSet<WeightEntry> Weights { get; set; }
        public DbSet<PointEntry> Points { get; set; }
        public DbSet<CommentEntry> Comments { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        /// <summary>
        /// Makes sure all the changes are commited tot
        /// </summary>
        public new void Dispose()
        {        
            
            base.Dispose();
        }
    }
}
