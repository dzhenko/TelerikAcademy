namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;

    using Cars.Tests.JustMock.Mocks;


    [TestClass]
    public class CarsControllerTests
    {
        private ICarsRepository carsData;
        private CarsController controller;

        // change to MoqCarsRepository() if you want to check use of moq library
        public CarsControllerTests()
            : this(new JustMockCarsRepository())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GettingDetailsViewForUnexistingIdShouldThrowArgumentNullException()
        {
            var model = (Car)GetModel(() => this.controller.Details(-1));
        }

        [TestMethod]
        public void GettingDetailsViewShouldReturnProperView()
        {
            var model = (Car)GetModel(() => this.controller.Details(1));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        public void GettingSearchViewShouldReturnProperView()
        {
            var model = (List<Car>)GetModel(() => this.controller.Search("BMW"));

            Assert.AreEqual("BMW", model[0].Make);
            Assert.AreEqual("BMW", model[1].Make);
        }

        [TestMethod]
        public void GettingSortByMakeViewShouldReturnProperView()
        {
            var modelList = (List<Car>)GetModel(() => this.controller.Sort("make"));

            Assert.AreEqual(4, modelList.Count);
        }

        [TestMethod]
        public void GettingSortByYearViewShouldReturnProperView()
        {
            var modelList = (List<Car>)GetModel(() => this.controller.Sort("year"));

            Assert.AreEqual(4, modelList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GettingSortByInvalidTypeViewShouldReturnProperView()
        {
            var modelList = (List<Car>)GetModel(() => this.controller.Sort("invalid"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GettingSortByNullTypeViewShouldReturnProperView()
        {
            var modelList = (List<Car>)GetModel(() => this.controller.Sort(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GettingSortByEmptyTypeViewShouldReturnProperView()
        {
            var modelList = (List<Car>)GetModel(() => this.controller.Sort(""));
        }

        
        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
