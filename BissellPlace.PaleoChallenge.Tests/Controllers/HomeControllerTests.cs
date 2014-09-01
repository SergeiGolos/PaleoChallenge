using System.Web.Mvc;
using BissellPlace.PaleoChallenge.Controllers;
using FakeItEasy;
using Xunit;
using BissellPlace.PaleoChallenge.Framework;

namespace BissellPlace.PaleoChallenge.Tests.Controllers
{    
    public class HomeControllerTests
    {
        [Fact]
        public void Index()
        {
            // Arrange
            var controller = new HomeController(A<ISecurityUser>._);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Home Page", result.ViewBag.Title);
        }
    }
}
