using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BissellPlace.PaleoChallenge.Framework.DomainModel;

namespace BissellPlace.PaleoChallenge.EntityDataProvider
{  
    public class PaleoChallengeContext : DbContext, IDbContext
    {
        public PaleoChallengeContext()
            : base("PaleoChallengeContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PaleoChallengeContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Entry> Entries { get; set; }

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
