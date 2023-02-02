using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using EducationBoard.DAL;
using EducationBoard.Models;
using Xunit;
using EBUnitTesting.Utility;


namespace EBUnitTesting.DAL
{
    public class SubjectTestDAL
    {
        private readonly EducationBoardDbContext _db;
        private readonly ISubjectDAL _SubjectDAL;
        public SubjectTestDAL()
        {
            _db = DbUtility.GetInMemoryDbContext();
            _SubjectDAL = new SubjectDAL(_db);
        }

        [Fact]
        public void CreateSubject_ShouldReturnTrue()
        {
            Subject Subject = new Subject() { SubjectName = "Tamil"};
            var result = _SubjectDAL.CreateSubject(Subject);
            result.Should().BeTrue();
        }

        [Fact]
        public void CreateSubject_ShouldReturnStatusCoe400_WithValidationException()
        {
            Subject Subject = new Subject() { SubjectName = "" };
            var result = () => _SubjectDAL.CreateSubject(Subject);
            result.Should().Throw<ValidationException>();
        }
    }
}