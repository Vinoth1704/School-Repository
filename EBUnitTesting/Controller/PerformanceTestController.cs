using FluentAssertions;
using EducationBoard.Controllers;
using EducationBoard.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using EBUnitTesting.MockData;
using Xunit;

namespace EBUnitTesting.Controllers
{
    public class PerformancesTestController
    {
        private readonly PerformanceController _PerformanceController;
        private readonly Mock<IPerformanceService> _Performanceservice = new Mock<IPerformanceService>();



        public PerformancesTestController()
        {
            _PerformanceController = new PerformanceController(_Performanceservice.Object);
        }

        [Fact]
        public void ViewAllPerformances_ShouldReturnStatusCode200()
        {
            // Arrange
            var Performances = PerformancesMock.ListOfPerformances();
            _Performanceservice.Setup(Performanceservice => Performanceservice.GetAllScores()).Returns(Performances);
            // Act
            var Result = _PerformanceController.GetAllScores() as ObjectResult;
            //Assert
            Result!.StatusCode.Should().Be(200);
        }

        [Fact]
        public void ViewAllPerformances_ShouldReturnStatusCode500()
        {
            _Performanceservice.Setup(Performanceservice => Performanceservice.GetAllScores()).Throws<Exception>();
            var Result = _PerformanceController.GetAllScores() as ObjectResult;
            Assert.Equal(500, Result!.StatusCode);
        }
        [Fact]
        public void GetAverage_ShouldReturnStatusCode200()
        {
            var Performances = PerformancesMock.ListOfPerformances();
            _Performanceservice.Setup(Performanceservice => Performanceservice.GetAverage()).Returns(Performances);
            var Result = _PerformanceController.GetAverage() as ObjectResult;
            Result!.StatusCode.Should().Be(200);
        }

        [Fact]
        public void GetAverage_ShouldReturnStatusCode500()
        {
            _Performanceservice.Setup(Performanceservice => Performanceservice.GetAverage()).Throws<Exception>();
            var Result = _PerformanceController.GetAverage() as ObjectResult;
            Result!.StatusCode.Should().Be(500);
        }




    }
}