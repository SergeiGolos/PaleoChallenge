using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.Windsor;

namespace BissellPlace.PaleoChallenge.Framework.Http
{
    /// <summary>
    /// Implements a controller activator for castle windsor.
    /// </summary>
    public class WindsorHttpControllerActivator : IHttpControllerActivator
    {
        #region Fields

        /// <summary>
        /// The container to use.
        /// </summary>
        private readonly IWindsorContainer container;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WindsorHttpControllerActivator"/> class.
        /// </summary>
        /// <param name="container">The container to use.</param>
        public WindsorHttpControllerActivator(IWindsorContainer container)
        {
            // Cache the container.
            this.container = container;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Creates a new http controller.
        /// </summary>
        /// <param name="request">The request being processed.</param>
        /// <param name="controllerDescriptor">The description of the controller.</param>
        /// <param name="controllerType">The type of controller.</param>
        /// <returns>A new controller to serve.</returns>
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            // Create the controller.
            
            var controller = (IHttpController)this.container.Resolve(controllerType);

            // Register the disposal handler.
            request.RegisterForDispose(new Release(() => this.container.Release(controller)));

            return controller;
        }

        #endregion Public Methods

        #region Inner Classes
 
        /// <summary>
        /// Implements a release handler for the controller activator.
        /// </summary>
        private class Release : IDisposable
        {
            #region Fields

            /// <summary>
            /// The release action to execute.
            /// </summary>
            private readonly Action release;

            #endregion Fields

            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="Release" /> class.
            /// </summary>
            /// <param name="release">The release action to execute.</param>
            public Release(Action release)
            {
                // Cache the handler.
                this.release = release;
            }

            #endregion Constructors

            #region Public Methods

            /// <summary>
            /// Disposes the object.
            /// </summary>
            public void Dispose()
            {
                this.release();
            }

            #endregion Public Methods
        }

        #endregion Inner Classes
    }
}