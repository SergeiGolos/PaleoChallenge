using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BissellPlace.PaleoChallenge.EntityDataProvider
{
    /// <summary>
    /// The domain model Installer.  Registers all repositories in the application.
    /// </summary>
    public class PersistenceInstaller : IWindsorInstaller
    {
        /// <summary>
        /// The install function for the domain model.
        /// </summary>
        /// <param name="container">The castle container.</param>
        /// <param name="store">The configuration store.</param>    
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            
            container.AddFacility<EntityFrameworkFacility>();
        }
    }
}