using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using EducationBoard.DAL;
using EducationBoard.Models;
using Xunit;
using EBUnitTesting.Utility;


namespace EBUnitTesting.DAL
{
    public class StudentTestDAL
    {
        private readonly EducationBoardDbContext _db;
        private readonly IStudentDAL _studentDAL;
        public StudentTestDAL()
        {
            _db = DbUtility.GetInMemoryDbContext();
            _studentDAL = new StudentDAL(_db);
        }

        [Fact]
        public void CreateStudent_ShouldReturnTrue()
        {
            Student student = new Student() { StudentName = "Alex", SchoolID = 1, RollNumber = 10000 };
            var result = _studentDAL.CreateStudent(student);
            result.Should().BeTrue();
        }

        [Fact]
        public void CreateStudent_ShouldReturnStatusCoe400_WithValidationException()
        {
            Student student = new Student() { StudentName = "", SchoolID = 1, RollNumber = 10000 };
            var result = () => _studentDAL.CreateStudent(student);
            result.Should().Throw<ValidationException>();
        }
    }
}