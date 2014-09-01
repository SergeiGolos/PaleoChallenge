using System;
using System.IO;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Routing;
using BissellPlace.PaleoChallenge.Framework.Http;
using Castle.MicroKernel;
using Castle.Windsor;
using FakeItEasy;
using Xunit;
using System.Web;
using System.Web.Http.Controllers;
namespace BissellPlace.PaleoChallenge.Framework.Tests.Http
{
    public class WindsorHttpControllerActivatorTests
    {

        private IWindsorContainer _container;

        public WindsorHttpControllerActivatorTests()
        {
            _container = A.Fake<IWindsorContainer>();
        }

        [Fact]
        public void CanCreateControllerFactory()
        {
            var factory = new WindsorHttpControllerActivator(_container);
            Assert.NotNull(factory);
        }

        [Fact]
        public void CanCreateController()
        {
            var factory = new WindsorHttpControllerActivator(_container);
            var resolve = A.CallTo(() => _container.Resolve(A<Type>.Ignored));
            resolve.Returns(A<IController>._);

            factory.Create(A.Fake<HttpRequestMessage>(), A<HttpControllerDescriptor>._, typeof(string));
            resolve.MustHaveHappened(Repeated.Exactly.Once);                        
        }


        //[Fact]
        //public void CanReleaseController()
        //{
        //    var factory = new WindsorHttpControllerActivator(_container);
        //    var resolve = A.CallTo(() => _container.Resolve(A<Type>.Ignored));
        //    var requestMessage = A.Fake<HttpRequestMessage>();
    
        //    A.CallTo(() => requestMessage.RegisterForDispose(A<IDisposable>._)).Invokes(n => ((IDisposable)n.Arguments[0]).Dispose());

        //    resolve.Returns(A<IController>._);
        //    factory.Create(requestMessage, A<HttpControllerDescriptor>._, typeof(string));
                            
        //    resolve.MustHaveHappened(Repeated.Exactly.Once);
        //    A.CallTo(()=>_container.Release(A<IController>._)).MustHaveHappened(Repeated.Exactly.Once);
        //}        
    }
}