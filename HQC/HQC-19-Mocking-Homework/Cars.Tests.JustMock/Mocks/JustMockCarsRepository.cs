namespace Cars.Tests.JustMock.Mocks
{
    using Cars.Contracts;
    using Cars.Models;
    using System.Linq;
    using Telerik.JustMock;

    public class JustMockCarsRepository : CarRepositoryMock, ICarsRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            this.CarsData = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => this.CarsData.Add(Arg.IsAny<Car>())).DoNothing();
            Mock.Arrange(() => this.CarsData.All()).Returns(this.FakeCarCollection);
            Mock.Arrange(() => this.CarsData.Search(Arg.AnyString)).Returns(this.FakeCarCollection.Where(c => c.Make == "BMW").ToList());

            // homework
            Mock.Arrange(() => this.CarsData.GetById(Arg.Matches<int>(x => x != -1))).Returns(this.FakeCarCollection.First());

            Mock.Arrange(() => this.CarsData.GetById(Arg.Is<int>(-1))).Returns((Car)null);

            Mock.Arrange(() => this.CarsData.TotalCars).Returns(this.FakeCarCollection.Count);

            Mock.Arrange(() => this.CarsData.Remove(Arg.IsAny<Car>())).DoNothing();

            Mock.Arrange(() => this.CarsData.SortedByMake()).Returns(this.FakeCarCollection);

            Mock.Arrange(() => this.CarsData.SortedByYear()).Returns(this.FakeCarCollection);
        }
    }
}
