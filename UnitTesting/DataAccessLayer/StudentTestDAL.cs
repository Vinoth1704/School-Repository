using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using School.DAL;
using School.Models;
using Xunit;
using UnitTesting.Utility;


namespace UnitTesting.DAL
{
    public class StudentTestDAL
    {
        private readonly SchoolDbContext _db;
        private readonly IStudentDAL _studentDAL;
        public StudentTestDAL()
        {
            _db = DbUtility.GetInMemoryDbContext();
            _studentDAL = new StudentDAL(_db);
        }

        [Fact]
        public void CreateStudent_ShouldReturnTrue()
        {
            Student student = new Student() { StudentName = "Alex", RollNumber = 10000, Address = "Coimbatore" };
            var result = _studentDAL.CreateStudent(student);
            result.Should().BeTrue();
        }

        [Fact]
        public void CreateStudent_ShouldReturnStatusCoe400_WithValidationException()
        {
            Student student = new Student() { StudentName = "", Address = "Coimbatore", RollNumber = 10000 };
            var result = () => _studentDAL.CreateStudent(student);
            result.Should().Throw<ValidationException>();
        }
    }
}