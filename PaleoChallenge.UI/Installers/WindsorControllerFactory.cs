using System;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel;

namespace PaleoChallenge.UI.Installers
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        #region Fields

        /// <summary>
        /// The culture to use for string formatting.
        /// </summary>
        private readonly CultureInfo culture = CultureInfo.CurrentCulture;

        /// <summary>
        /// The core kernel to use for dependency resolution.
        /// </summary>
        private readonly IKernel kernel;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WindsorControllerFactory" /> class.
        /// </summary>
        /// <param name="kernel">The kernel to use for dependency resolution.</param>
        public WindsorControllerFactory(IKernel kernel)
        {
            // Cache the kernel.
            this.kernel = kernel;
        }

        #endregion Constructors

        #region Overrides

        /// <inheritdoc />
        public override void ReleaseController(IController controller)
        {
            this.kernel.ReleaseComponent(controller);
        }

        /// <inheritdoc />
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "This is handled by the framework")]
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format(this.culture, "The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }

            return (IController)this.kernel.Resolve(controllerType);
        }

        #endregion Overrides
    }
}