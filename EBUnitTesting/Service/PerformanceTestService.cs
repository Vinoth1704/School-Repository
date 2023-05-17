using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using EducationBoard.DAL;
using EducationBoard.Models;
using EducationBoard.Services;
using Moq;
using EBUnitTesting.MockData;
using Xunit;
using EBUnitTesting.Utility;

namespace EBUnitTesting.Service
{
    public class PerformanceTestService
    {
        private readonly PerformanceService _PerformanceService;
        private readonly Mock<IPerformanceDAL> _PerformanceDAL = new Mock<IPerformanceDAL>();
        public PerformanceTestService()
        {
            _PerformanceService = new PerformanceService(_PerformanceDAL.Object);
        }

        [Fact]
        public void GetAllScores_ShouldReturnStatusCode200()
        {
            var performances = PerformancesMock.ListOfPerformances();
            _PerformanceDAL.Setup(PerformanceDAL => PerformanceDAL.GetAllScores()).Returns(performances);
            var Result = _PerformanceService.GetAllScores();
            Assert.Equal(Result.Count(), performances.Count());
        }

        [Fact]
        public void GetAllScores_ShouldReturnStatusCode500()
        {
            _PerformanceDAL.Setup(PerformanceDAL => PerformanceDAL.GetAllScores()).Throws<Exception>();
            var Result = () => _PerformanceService.GetAllScores();
            Result.Should().Throw<Exception>();
        }


    }
}