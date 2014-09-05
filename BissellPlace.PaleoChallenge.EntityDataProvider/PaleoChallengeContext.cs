using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BissellPlace.PaleoChallenge.Framework.DomainModel;

namespace BissellPlace.PaleoChallenge.EntityDataProvider
{
    public class CreateWithSeed : CreateDatabaseIfNotExists<PaleoChallengeContext>
    {
        public override void InitializeDatabase(PaleoChallengeContext context)
        {
            base.InitializeDatabase(context);
            context.Set<Entry>()
                .Add(new Entry()
                {
                    Challenger = new User() { UserName = "SingleUser", LastAccess = DateTime.Now },
                    Data = "1",
                    Type = "Points",
                    TimeStamp = DateTime.Now.AddDays(-1)
                });

            context.SaveChanges();
        }
    }


    public class PaleoChallengeContext : DbContext, IDbContext
    {
        public PaleoChallengeContext()
            : base("PaleoChallengeContext")
        {
            Database.SetInitializer(new CreateWithSeed());
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
