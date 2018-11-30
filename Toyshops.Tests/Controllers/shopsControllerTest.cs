using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toyshops.Controllers;
using Moq;
using System.Collections.Generic;
using Toyshops.Models;
using System.Linq;
using System.Web.Mvc;

namespace Toyshops.Tests.Controllers
{
    [TestClass]
    public class shopsControllerTest
    {
        shopsController controller;
        Mock<IshopsMock> mock;
        List<shop> shops;

        [TestInitialize]
        public void TestInitalize()
        {


            // create a new mock data object to hold a fake list of albums
            mock = new Mock<IshopsMock>();

            // populate mock list
            shops = new List<shop>
            {
                new shop { id ="one", Name = "Incredibles"
                    },
        };
mock.Setup(m => m.shops).Returns(shops.AsQueryable());
controller = new shopsController(mock.Object);
        }

       
        [TestMethod]
        public void IndexReturnsshops()
        {
            // act
            var result = (List<shop>)((ViewResult)controller.Index()).Model;

            // assert
            CollectionAssert.AreEqual(shops, result);
        }
        [TestMethod]
        public void DetailsNoId()
        {
            // act
            ViewResult result = (ViewResult)controller.Details(null);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DetailsInvalidId()
        {
            // act
            ViewResult result = (ViewResult)controller.Details(null);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }
        [TestMethod]
        public void DetailsValidIdLoadsView()
        {
            // act
            ViewResult result = (ViewResult)controller.Details("one");

            // assert
            Assert.AreEqual("Details", result.ViewName);
        }
      


        [TestMethod]
        public void shopSavedAndRedirected()
        {
            //act
            var result = (RedirectToRouteResult)controller.Create(shops[0]);

            //assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
        [TestMethod]
        public void IndexLoadsView()
        {

            // act
            ViewResult result = controller.Index() as ViewResult;

            // assert
            Assert.IsNotNull( result.ViewName);
        }
        [TestMethod]
        public void idNotNull()
        {

            //act
            controller.ModelState.AddModelError("some error name", "fake error description");
            var result = (ViewResult)this.controller.Create(this.shops[0]);

            //assert
            Assert.IsNotNull(result.ViewBag.id);
        }
        [TestMethod]
        public void EditNoId()
        {
            // arrange
            int? id = null;

            // act 
            ViewResult result = (ViewResult)controller.Edit("two");
            // assert 
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void EditInvalidId()
        {
            // act 
            ViewResult result = (ViewResult)controller.Edit("two");

            // assert 
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void EditValidIdLoadsView()
        {
            // act 
            ViewResult result = (ViewResult)controller.Edit("one");

            // assert 
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditValidIdLoadsshop()
        {
            // act 
            shop result = (shop)((ViewResult)controller.Edit("one")).Model;

            // assert 
            Assert.AreEqual(shops[0], result);
        }

        [TestMethod]
        public void EditReturnsidViewBag()
        {
            // act 
            ViewResult result = controller.Edit("one") as ViewResult;

            // assert 
            Assert.IsNotNull(result.ViewBag.id);
        }

        // POST: Bikes/Edit

        [TestMethod]
        public void ModelValidIndexLoaded()
        {
            // act
            RedirectToRouteResult result = (RedirectToRouteResult)controller.Edit(shops[0]);

            // assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void ModelInvalidViewbagsRightid()
        {
            // arrange
            controller.ModelState.AddModelError("some error name", "Error description");

            // Act
            ViewResult result = (ViewResult)controller.Edit(shops[0]);

            // Assert
            Assert.IsNotNull(result.ViewBag.id);
        }

        [TestMethod]
        public void ModelInValidLoadsView()
        {
            // arrange
            controller.ModelState.AddModelError("some error name", "Error description");

            // act 
            ViewResult result = (ViewResult)controller.Edit(shops[0]);

            // assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void ModelInvalidHasshopLoaded()
        {
            // arrange
            controller.ModelState.AddModelError("some error name", "Error description");

            // act 
            shop result = (shop)((ViewResult)controller.Details("one")).Model;

            // assert
            Assert.AreEqual(shops[0], result);
        }
        [TestMethod]
        public void DeleteNoId()
        {
            // act
            ViewResult result = (ViewResult)controller.Delete(null);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteInvalidId()
        {
            // act
            ViewResult result = (ViewResult)controller.Delete("two");

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteValidIdReturnshop()
        {
            // act
           shop result = (shop)((ViewResult)controller.Delete("one")).Model;

            // assert
            Assert.AreEqual(shops[0], result);
        }
        [TestMethod]
        public void DeleteValidIdReturnView()
        {
            // act
            ViewResult result = (ViewResult)controller.Delete("one");

            // assert
            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmedNoId()
        {
            // act
            ViewResult result = (ViewResult)controller.DeleteConfirmed("two");

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmedInvalidId()
        {
            // act
            ViewResult result = (ViewResult)controller.DeleteConfirmed("two");

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteWorks()
        {
            // act
            RedirectToRouteResult result = (RedirectToRouteResult)controller.DeleteConfirmed("one");

            // assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
