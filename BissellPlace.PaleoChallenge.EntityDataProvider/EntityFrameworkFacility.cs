using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;

namespace BissellPlace.PaleoChallenge.EntityDataProvider
{
    public class EntityFrameworkFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(
                Component.For<IDbContext>()
                    .ImplementedBy<PaleoChallengeContext>()
                    .LifestylePerWebRequest(),
                Classes.FromAssemblyContaining(typeof(RestRepository<>))
                    .Pick()
                    .WithServiceAllInterfaces()
                    .LifestylePerWebRequest());
        }
    }
}