using System;
using System.IO;
using System.Web.Mvc;
using System.Web.Routing;
using BissellPlace.PaleoChallenge.Framework.Http;
using Castle.MicroKernel;
using FakeItEasy;
using Xunit;
using System.Web;
namespace BissellPlace.PaleoChallenge.Framework.Tests.Http
{
    public class WindsorControllerFactoryTests
    {

        public class TestWindsorControllerFactory : WindsorControllerFactory
        {
            public TestWindsorControllerFactory(IKernel kernel) : base(kernel)
            {
            }

            public IController TestGetControllerInstance(RequestContext requestContext, Type controllerType)
            {
                return base.GetControllerInstance(requestContext, controllerType);
            }
        }

        private IKernel _kernel;

        public WindsorControllerFactoryTests()
        {
            _kernel = A.Fake<IKernel>();
        }

        [Fact]
        public void CanCreateControllerFactory()
        {
            var factory = new WindsorControllerFactory(_kernel);
            Assert.NotNull(factory);
        }

        [Fact]
        public void CanReleaseController()
        {
            var factory = new TestWindsorControllerFactory(_kernel);
            factory.ReleaseController(A<IController>.Ignored);

            A.CallTo(() => _kernel.ReleaseComponent(A<IController>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);                        
        }


        [Fact]
        public void CanRegisterController()
        {
            var factory = new TestWindsorControllerFactory(_kernel);
            var resolve = A.CallTo(() => _kernel.Resolve(A<Type>._));
            resolve.Returns(A<IController>._);
            
            factory.TestGetControllerInstance(A<RequestContext>._, typeof(string));
            resolve.MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void CanFailRegisterController()
        {
            TextWriter writer = new StringWriter();
            var request = new RequestContext()
            {
                HttpContext =
                    new HttpContextWrapper(new HttpContext(
                        new HttpRequest("test", @"http://google.com", ""),
                        new HttpResponse(writer)))
            };
            var factory = new TestWindsorControllerFactory(_kernel);
            

            Assert.Throws<HttpException>(() => factory.TestGetControllerInstance(request, null));                        
        }
    }
}