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
    public class StudentsTestController
    {
        private readonly StudentController _studentController;
        private readonly Mock<IStudentService> _studentService = new Mock<IStudentService>();



        public StudentsTestController()
        {
            _studentController = new StudentController(_studentService.Object);
        }

        [Fact]
        public void ViewAllStudents_ShouldReturnStatusCode200()
        {
            // Arrange
            var students = StudentsMock.ListOfStudents();
            _studentService.Setup(studentService => studentService.GetAllStudents()).Returns(students);
            // Act
            var Result = _studentController.GetAllStudents() as ObjectResult;
            //Assert
            Result!.StatusCode.Should().Be(200);
        }

        [Fact]
        public void ViewAllStudents_ShouldReturnStatusCode500()
        {
            _studentService.Setup(studentService => studentService.GetAllStudents()).Throws<Exception>();
            // var Result = _studentController.GetAllStudents() as ObjectResult;
            Assert.Throws<Exception>(() => _studentController.GetAllStudents());
        }

        [Theory]
        [InlineData(null)]
        public void CreateStudent_ShouldReturnStatusCode400_WhenStudetnObjectIsNull(Student student)
        {
            var Result = () => _studentController.CreateStudent(student);
            Result.Should().Throw<ValidationException>();
        }

        [Fact]
        public void CreateStudent_ShouldReturnStatusCoe200_WithProperData()
        {
            Student student = StudentsMock.CreateStudent();
            _studentService.Setup(studentService => studentService.CreateStudent(student)).Returns(true);
            var result = _studentController.CreateStudent(student) as ObjectResult;
            result!.StatusCode.Should().Be(200);
        }

        [Fact]
        public void CreateStudent_ShouldReturnStatusCoe400_WithImProperData()
        {
            Student student = StudentsMock.CreateStudent();
            _studentService.Setup(studentService => studentService.CreateStudent(student)).Throws<ValidationException>();
            Assert.Throws<ValidationException>(() => _studentController.CreateStudent(student));
        }

        [Fact]
        public void CreateStudent_ShouldReturnStatusCoe500_WhenInternalErrorOccured()
        {
            Student student = StudentsMock.CreateStudent();
            _studentService.Setup(studentService => studentService.CreateStudent(student)).Throws<Exception>();
            Assert.Throws<Exception>(() => _studentController.CreateStudent(student));
        }
    }
}