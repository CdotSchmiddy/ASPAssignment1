using System;
using System.Web.Mvc;
using Moq;
using ASPAssignment1.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASPAssignment1.Models;
using System.Collections.Generic;
using System.Linq;

namespace ASPAssignment1.Tests.Controllers
{
    [TestClass]
    public class ShowsControllerTest
    {

        //global variables for multiple tests
        ShowsController controller;
        Mock<IShowsMock> mock;
        List<Show> shows;


        [TestInitialize]
        public void TestInitalize()
        {
            // method runs automatically prior each individual test

            // create new mock data object
            mock = new Mock<IShowsMock>();

            shows = new List<Show>
            {
                new Show {Show_id = 100, Show_theatre = "Galaxy Cinemas", Show_time = "7:30", movy = new Movy { Movie_id = 1000, Movie_title = "John Wick 2" } },
                new Show {Show_id = 200, Show_theatre = "Galaxy North", Show_time = "8:30", movy = new Movy { Movie_id = 2000, Movie_title = "The Avengers" }},
                new Show {Show_id = 300, Show_theatre = "Scotiabank Theater", Show_time = "9:30", movy = new Movy { Movie_id = 3000, Movie_title = "Sherlock Holmes" }}
            };

            mock.Setup(m => m.shows).Returns(shows.AsQueryable());
            controller = new ShowsController(mock.Object);

        }

        [TestMethod]
        public void IndexLoadsView()
        {
            // arrange - moved to TestInitialize
            // ShowsController controller = new ShowsController();

            // act
            ViewResult result = controller.Index() as ViewResult;

            // assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexReturnsShows()
        {
            // act
            var result = (List<Show>)((ViewResult)controller.Index()).Model;

            // assert
            CollectionAssert.AreEqual(shows, result);
        }

        #region

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
            ViewResult result = (ViewResult)controller.Details(104);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DetailsValidIdLoadsView()
        {
            // act
            ViewResult result = (ViewResult)controller.Details(300);

            // assert
            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void DetailsValidIdLoadsShow()
        {
            // act
            Show result = (Show)((ViewResult)controller.Details(200)).Model;

            // assert
            Assert.AreEqual(shows[1], result);
        }
        #endregion

        #region

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
            ViewResult result = (ViewResult)controller.Delete(3869);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteValidIdLoadsShow()
        {
            // act
            Show result = (Show)((ViewResult)controller.Delete(100)).Model;

            // assert
            Assert.AreEqual(shows[0], result);
        }

        [TestMethod]
        public void DeleteValidIdLoadsView()
        {
            // act
            ViewResult result = (ViewResult)controller.Delete(100);

            // assert
            Assert.AreEqual("Delete", result.ViewName);
        }

        #endregion

        // POST: Shows/Delete
        #region

        [TestMethod]
        public void DeleteConfirmedNoId()
        {
            // act
            ViewResult result = (ViewResult)controller.DeleteConfirmed(null);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmedInvalidId()
        {
            // act
            ViewResult result = (ViewResult)controller.DeleteConfirmed(2000);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteWorks()
        {
            // act
            RedirectToRouteResult result = (RedirectToRouteResult)controller.DeleteConfirmed(300);

            // assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        #endregion


        #region

        [TestMethod]
        public void EditValidIndexLoaded()
        {
            // act
            RedirectToRouteResult result = (RedirectToRouteResult)controller.Edit(shows[0]);

            // assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void EditWrongViewbagsRightMovie()
        {
            // arrange
            controller.ModelState.AddModelError("some error name", "Error description");

            // Act
            ViewResult result = (ViewResult)controller.Edit(shows[0]);

            // Assert
            Assert.IsNotNull(result.ViewBag.Movie_id);
        }

        [TestMethod]
        public void EditWrongViewbagsRightRating()
        {
            // arrange
            controller.ModelState.AddModelError("some error name", "Error description");

            // Act
            ViewResult result = (ViewResult)controller.Edit(shows[0]);

            // Assert
            Assert.IsNotNull(result.ViewBag.Show_rating);
        }

        [TestMethod]
        public void EditWrongLoadsView()
        {
            // arrange
            controller.ModelState.AddModelError("some error name", "Error description");

            // act 
            ViewResult result = (ViewResult)controller.Edit(shows[0]);

            // assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditWrongShowLoaded()
        {
            // arrange
            controller.ModelState.AddModelError("some error name", "Error description");

            // act 
            Show result = (Show)((ViewResult)controller.Details(200)).Model;

            // assert
            Assert.AreEqual(shows[1], result);
        }
        #endregion
    }
}
