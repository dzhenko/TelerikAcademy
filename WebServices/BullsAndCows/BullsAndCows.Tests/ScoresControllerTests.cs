using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using BullsAndCows.Models;
using BullsAndCows.Data.Repositories;
using System.Linq;
using BullsAndCows.Web.Controllers;
using BullsAndCows.Data;
using System.Web.Http;
using System.Net.Http;
using System.Threading;
using BullsAndCows.Web.DataModels;
using System.Collections.Generic;
using System.Web.Http.Routing;
using BullsAndCows.Web.Controllers;
using System;
using System.Web.Http;
using BullsAndCows.Data.Repositories;

namespace BullsAndCows.Tests
{
    [TestClass]
    public class GamesControllerTests
    {
        [TestMethod]
        public void GetAll_WhenScoresInDb_ShouldReturnScores()
        {
            var repo = Mock.Create<IRepository<Game>>();
            Mock.Arrange(() => repo.All())
                .Returns(() => new List<Game>().AsQueryable());

            var data = Mock.Create<IBullsAndCowsData>();

            Mock.Arrange(() => data.Games)
                .Returns(() => repo);

            var controller = new GamesController(data, null, null, null);
            this.SetupController(controller);

            var actionResult = controller.Get();

            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;

            var actual = response.Content.ReadAsStringAsync().Result;

            var expected = "[]"; //empty array

            Assert.AreEqual(actual, expected);
        }
        
        private void SetupController(ApiController controller)
        {
            string serverUrl = "http://test-url.com";

            //Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            //Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            //Apply the routes of the controller
            controller.RequestContext.RouteData =
                new HttpRouteData(
                    route: new HttpRoute(),
                    values: new HttpRouteValueDictionary
                    {
                        { "controller", "scores" }
                    });
        }

    }
}
