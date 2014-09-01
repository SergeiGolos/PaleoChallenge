using AutoMapper;
using BissellPlace.PaleoChallenge.Framework.DomainModel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BissellPlace.PaleoChallenge.Installers
{
    /// <summary>
    /// The domain model Installer.  Registers all repositories in the application.
    /// </summary>
    public class MapperInstaller : IWindsorInstaller
    {
        /// <summary>
        /// The install function for the domain model.
        /// </summary>
        /// <param name="container">The castle container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Mapper.CreateMap<User, User>().ForMember(n => n.Id, config => config.Ignore());
            Mapper.CreateMap<Entry, Entry>().ForMember(n => n.Id, config => config.Ignore());

            container.Register(Component.For<IMappingEngine>().UsingFactoryMethod(()=> Mapper.Engine));
        }
    }
}