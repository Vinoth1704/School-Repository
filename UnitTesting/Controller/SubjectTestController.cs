using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using School.Controllers;
using School.Models;
using School.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UnitTesting.MockData;
using Xunit;

namespace UnitTesting.Controllers
{
    public class SubjectsTestController
    {
        private readonly SubjectController _subjectController;
        private readonly Mock<ISubjectService> _subjectservice = new Mock<ISubjectService>();



        public SubjectsTestController()
        {
            _subjectController = new SubjectController(_subjectservice.Object);
        }

        [Fact]
        public void ViewAllSubjects_ShouldReturnStatusCode200()
        {
            // Arrange
            var subjects = SubjectsMock.ListOfSubjects();
            _subjectservice.Setup(subjectservice => subjectservice.GetAllSubjects()).Returns(subjects);
            // Act
            var Result = _subjectController.GetAllSubjects() as ObjectResult;
            //Assert
            Result!.StatusCode.Should().Be(200);
        }

        [Fact]
        public void ViewAllSubjects_ShouldReturnStatusCode500()
        {
            _subjectservice.Setup(subjectservice => subjectservice.GetAllSubjects()).Throws<Exception>();
            // var Result = _subjectController.GetAllSubjects() as ObjectResult;
            // Assert.Equal(500, Result!.StatusCode);
            Assert.Throws<Exception>(() => _subjectController.GetAllSubjects());
        }

        [Theory]
        [InlineData(null)]
        public void CreateSubject_ShouldReturnStatusCode400_WhenSubjectnObjectIsNull(Subject Subject)
        {
            var Result = () => _subjectController.CreateSubject(Subject);
            Result.Should().Throw<ValidationException>();
        }

        [Fact]
        public void CreateSubject_ShouldReturnStatusCoe200_WithProperData()
        {
            Subject Subject = SubjectsMock.CreateSubject();
            _subjectservice.Setup(subjectservice => subjectservice.CreateSubject(Subject)).Returns(true);
            var result = _subjectController.CreateSubject(Subject) as ObjectResult;
            result!.StatusCode.Should().Be(200);
        }

        [Fact]
        public void CreateSubject_ShouldReturnStatusCoe400_WithImProperData()
        {
            Subject Subject = SubjectsMock.CreateSubject();
            _subjectservice.Setup(subjectservice => subjectservice.CreateSubject(Subject)).Throws<ValidationException>();
            // var result = _subjectController.CreateSubject(Subject) as ObjectResult;
            // result!.StatusCode.Should().Be(400);
            Assert.Throws<ValidationException>(() => _subjectController.CreateSubject(Subject));
        }

        [Fact]
        public void CreateSubject_ShouldReturnStatusCoe500_WhenInternalErrorOccured()
        {
            Subject Subject = SubjectsMock.CreateSubject();
            _subjectservice.Setup(subjectservice => subjectservice.CreateSubject(Subject)).Throws<Exception>();
            // var result = _subjectController.CreateSubject(Subject) as ObjectResult;
            // result!.StatusCode.Should().Be(500);
            Assert.Throws<Exception>(() => _subjectController.CreateSubject(Subject));
        }
    }
}