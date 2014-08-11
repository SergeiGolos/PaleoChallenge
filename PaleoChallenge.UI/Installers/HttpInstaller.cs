using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace PaleoChallenge.UI.Installers
{
    using System.Web.Mvc;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    /// <summary>
    /// Registers the HTTP controllers with the container.
    /// </summary>
    public class HttpControllerInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Adds the HTTP controllers to the container.
        /// </summary>
        /// <param name="container">The container to configure.</param>
        /// <param name="store">The configuration store to use.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "This is handled by the framework")]
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Set the controller factory to use.
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));
            // Set the controller factory to use.
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorHttpControllerActivator(container));

            container.Register(Classes.FromThisAssembly().BasedOn<IHttpController>().LifestyleTransient());
            container.Register(Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient());
        }
    }
}