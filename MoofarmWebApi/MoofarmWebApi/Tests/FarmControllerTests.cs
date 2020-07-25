using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApiExample.Controller;

namespace WebApiExample.Tests
{
    [TestClass]
    public class FarmControllerTests
    {
        [TestMethod]
        public void postContestDataTest()
        {
            // Set up Prerequisites   
            var controller = new FarmController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            var response = controller.postContestData(1,1,20);
            // Assert the result  
            Assert.AreEqual(response.StatusCode,System.Net.HttpStatusCode.Conflict);
        }
        [TestMethod]
        public void postContestDataOKTest()
        {
            // Set up Prerequisites   
            var controller = new FarmController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            var response = controller.postContestData(4, 1, 20);
            // Assert the result  
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }
        [TestMethod]
        public void userNotFoundTest()
        {
            // Set up Prerequisites   
            var controller = new FarmController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            var response = controller.postContestData(10, 1, 20);
            // Assert the result  
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.NotFound);
        }
        [TestMethod]
        public void moreEntryFeesTest()
        {
            // Set up Prerequisites   
            var controller = new FarmController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            var response = controller.postContestData(7, 1, 10);
            // Assert the result  
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.PreconditionFailed);
        }
    }
}