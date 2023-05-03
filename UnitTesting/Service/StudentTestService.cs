using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using School.DAL;
using School.Models;
using School.Services;
using Moq;
using UnitTesting.MockData;
using Xunit;
using Microsoft.Extensions.Configuration;

namespace UnitTesting.Service
{
    public class StudentTestService
    {
        private readonly StudentService _studentService;
        private readonly Mock<IStudentDAL> _studentDAL = new Mock<IStudentDAL>();
        private readonly Mock<IMessagingService> _messagingService = new Mock<IMessagingService>();
        private readonly IConfiguration _config;
        private int _schoolCode;

        public StudentTestService()
        {
            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
            _schoolCode = Convert.ToInt32(_config.GetSection("SchoolSettings").GetSection("SchoolCode").Value);
            _studentService = new StudentService(_studentDAL.Object, _messagingService.Object, _config);
        }

        [Fact]
        public async void CreateStudent_ShouldReturnStatusCode200()
        {
            var students = StudentsMock.CreateStudent();
            var studentDetails = StudentsMock.LastStudent();
            _studentDAL.Setup(studentDAL => studentDAL.CreateStudent(students)).Returns(true);
            _studentDAL.Setup(StudentDAL => StudentDAL.GetLastSavedStudent()).Returns(studentDetails);
            // _messagingService.Setup(studentDAL => studentDAL.ReceiveMessage()).Returns(true);
            var Result = _studentService.CreateStudent(students);
            var EndResult = await Result;
            Assert.True(EndResult);
        }

        [Theory]
        [InlineData(null)]
        public void CreateStudent_ShouldReturnStatusCode400_WhenStudetnObjectIsNull(Student student)
        {
            var result = () => _studentService.CreateStudent(student);
            result.Should().ThrowAsync<ValidationException>();
        }

        [Fact]
        public void CreateStudent_ShouldReturnStatusCoe500_WhenInternalErrorOccured()
        {
            var students = StudentsMock.CreateStudent();
            _studentDAL.Setup(studentService => studentService.CreateStudent(students)).Returns(false);
            // var Result = _studentService.CreateStudent(students);
            Assert.Throws<Exception>(() => _studentService.CreateStudent(students));
        }

        [Fact]
        public void CreateStudent_ShouldReturnStatusCoe400_WithValidationException()
        {
            var students = StudentsMock.CreateStudent();
            _studentDAL.Setup(studentService => studentService.CreateStudent(students)).Throws<ValidationException>();
            var Result = () => _studentService.CreateStudent(students);
            Result!.Should().Throw<ValidationException>();
        }
        [Fact]
        public void GetAllStudents_ShouldReturnStatusCode200()
        {
            var students = StudentsMock.ListOfStudents();
            _studentDAL.Setup(studentDAL => studentDAL.GetAllStudents()).Returns(students);
            var Result = _studentService.GetAllStudents();
            Assert.Equal(Result.Count(), students.Count);
        }

        [Fact]
        public void GetAllStudents_ShouldReturnStatusCode500()
        {
            _studentDAL.Setup(studentDAL => studentDAL.GetAllStudents()).Throws<Exception>();
            var Result = () => _studentService.GetAllStudents();
            Result.Should().Throw<Exception>();
        }

    }
}