using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Microsoft.Ajax.Utilities;
using IDependencyResolver = System.Web.Http.Dependencies.IDependencyResolver;

namespace PaleoChallenge.UI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected IWindsorContainer container;

        protected void Application_Start()
        {            
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            container = new WindsorContainer();
            container.Install(FromAssembly.This());                
        }

        protected void Application_Stop()
        {
            if (container != null)
            {
                container.Dispose();
                container = null;
            }
        }
    }
}
