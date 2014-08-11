using PaleoChallenge.EnityDataAccess;

namespace PaleoChallenge.UI.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using PaleoChallenge.Business;

    /// <summary>
    /// The domain model Installer.  Registers all repositories in the application.
    /// </summary>
    public class DomainModelInstaller : IWindsorInstaller
    {
        /// <summary>
        /// The install function for the domain model.
        /// </summary>
        /// <param name="container">The castle container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining(typeof(RestRepository<>)).Pick().WithServiceAllInterfaces());
        }
    }
}