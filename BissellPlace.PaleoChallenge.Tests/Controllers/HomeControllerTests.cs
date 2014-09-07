using System.Collections.Generic;
using System.Web.Mvc;
using BissellPlace.PaleoChallenge.Controllers;
using BissellPlace.PaleoChallenge.Framework.Providers;
using FakeItEasy;
using Xunit;
using BissellPlace.PaleoChallenge.Framework;
using BissellPlace.PaleoChallenge.Models.View;

namespace BissellPlace.PaleoChallenge.Tests.Controllers
{    
    public class HomeControllerTests
    {
        [Fact]
        public void Index()
        {
            // Arrange
            var summaryProvider = A.Fake<IViewSummaryProvider>();
            var controller = new HomeController(A<ISecurityUser>._,summaryProvider);
            A.CallTo(() => summaryProvider.GetWeekSummary()).Returns(A<List<EntrySummary>>._);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Home Page", result.ViewBag.Title);
        }
    }
}
