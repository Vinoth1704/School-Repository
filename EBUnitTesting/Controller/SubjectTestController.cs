using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using EducationBoard.Controllers;
using EducationBoard.Models;
using EducationBoard.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using EBUnitTesting.MockData;
using Xunit;

namespace EBUnitTesting.Controllers
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
            var Result = _subjectController.GetAllSubjects() as ObjectResult;
            Assert.Equal(500, Result!.StatusCode);
        }

        [Theory]
        [InlineData(null)]
        public void CreateSubject_ShouldReturnStatusCode400_WhenSubjectnObjectIsNull(Subject Subject)
        {
            var Result = _subjectController.CreateSubject(Subject) as ObjectResult;
            Result!.StatusCode.Should().Be(400);
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
            var result = _subjectController.CreateSubject(Subject) as ObjectResult;
            result!.StatusCode.Should().Be(400);
        }

        [Fact]
        public void CreateSubject_ShouldReturnStatusCoe500_WhenInternalErrorOccured()
        {
            Subject Subject = SubjectsMock.CreateSubject();
            _subjectservice.Setup(subjectservice => subjectservice.CreateSubject(Subject)).Throws<Exception>();
            var result = _subjectController.CreateSubject(Subject) as ObjectResult;
            result!.StatusCode.Should().Be(500);
        }
    }
}