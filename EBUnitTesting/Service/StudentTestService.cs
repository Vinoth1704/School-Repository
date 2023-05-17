using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using EducationBoard.DAL;
using EducationBoard.Models;
using EducationBoard.Services;
using Moq;
using EBUnitTesting.MockData;
using Xunit;
using EBUnitTesting.Utility;
using AutoMapper;

namespace EBUnitTesting.Service
{
    public class StudentTestService
    {
        private readonly StudentService _studentService;
        // private readonly IMapper _mapper;
        private readonly Mock<IStudentDAL> _studentDAL;
        private readonly Mock<IMapper> _mapper;
        public StudentTestService()
        {
            _studentDAL = new Mock<IStudentDAL>();
            _mapper = new Mock<IMapper>();
            _studentService = new StudentService(_studentDAL.Object, _mapper.Object);
        }

        [Fact]
        public void CreateStudent_ShouldReturnStatusCode200()
        {
            var students = StudentsMock.CreateStudent();
            _studentDAL.Setup(studentDAL => studentDAL.CreateStudent(students)).Returns(true);
            var Result = _studentService.CreateStudent(students);
            Result!.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        public void CreateStudent_ShouldReturnStatusCode400_WhenStudetnObjectIsNull(Student student)
        {
            var result = () => _studentService.CreateStudent(student);
            result.Should().Throw<ValidationException>();
        }

        [Fact]
        public void CreateStudent_ShouldReturnStatusCoe500_WhenInternalErrorOccured()
        {
            var students = StudentsMock.CreateStudent();
            _studentDAL.Setup(studentService => studentService.CreateStudent(students)).Returns(false);
            var Result = _studentService.CreateStudent(students);
            Result!.Should().BeFalse();
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
            var students = StudentsMock.GetAllStudents();
            var studentsDTO = StudentsMock.ListOfStudents();
            _mapper.Setup(m => m.Map<IEnumerable<StudentsDTO>>(students)).Returns(studentsDTO);
            _studentDAL.Setup(studentDAL => studentDAL.GetAllStudents()).Returns(students);
            var Result = _studentService.GetAllStudents();
            Assert.Equal(Result.Count(), students.Count());
        }

        [Fact]
        public void GGetAllStudents_ShouldReturnStatusCode500()
        {
            _studentDAL.Setup(studentDAL => studentDAL.GetAllStudents()).Throws<Exception>();
            var Result = () => _studentService.GetAllStudents();
            Result.Should().Throw<Exception>();
        }

    }
}