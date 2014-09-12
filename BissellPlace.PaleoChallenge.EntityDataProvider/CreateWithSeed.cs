using System;
using System.Data.Entity;
using BissellPlace.PaleoChallenge.Framework.DomainModel;
using System.Linq;
using Castle.Core.Internal;

namespace BissellPlace.PaleoChallenge.EntityDataProvider
{
    public class CreateWithSeed : IDatabaseInitializer<PaleoChallengeContext>
    {
        private readonly bool _forceCreate;

        public CreateWithSeed(bool forceCreate)
        {
            _forceCreate = forceCreate;
        }

        public void InitializeDatabase(PaleoChallengeContext context)
        {
            if (context.Database.Exists())
            {
                if (context.Database.CompatibleWithModel(true) && !_forceCreate)
                {
                    return; 
                }
                context.Database.Delete();                    
            }
            context.Database.Create();
            SeedData.Create(context);
        }
    }

    public static class SeedData
    {
        private static User _challenger;
        private static Random _random;

        static SeedData()
        {
            _random = new Random();
            _challenger = new User() { UserName = "SingleUser", LastAccess = DateTime.Now };
        }

        public static void Create(PaleoChallengeContext context)
        {
            Func<bool> randomBool = () => _random.Next(1, 3) % 2 == 0;

            Action<Entry> randDadat = (record) =>
            {
                if (randomBool())
                {
                    context.Set<WeightEntry>().Add(new WeightEntry()
                    {
                        Record = record,
                        Weight = _random.Next(180, 190)
                    });
                }

                if (randomBool())
                {
                    context.Set<PointEntry>().Add(new PointEntry()
                    {
                        Record = record,
                        Workout = randomBool() ? 1 : 0,
						Sleep = randomBool() ? 1 : 0,
                        Points = _random.Next(0, 4)
                    });
                }

				if (randomBool())
				{
					context.Set<CommentEntry>().Add(new CommentEntry()
					{
						Record = record,
						Comment = "Random Comment"
					});
				}
            };

            Enumerable.Range(1, 5).ForEach(value =>
            {
                var entity = new Entry()
                {
                    Challenger = _challenger,
                    TimeStamp = DateTime.Now.AddDays(-1 * value)
                };

                randDadat(entity);
                context.Set<Entry>().Add(entity);
            });

            context.SaveChanges();
        }
    }
}