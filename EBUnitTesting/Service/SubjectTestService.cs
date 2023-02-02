using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using EducationBoard.DAL;
using EducationBoard.Models;
using EducationBoard.Services;
using Moq;
using EBUnitTesting.MockData;
using Xunit;

namespace EBUnitTesting.Service
{
    public class SubjectTestService
    {
        private readonly SubjectService _SubjectService;
        private readonly Mock<ISubjectDAL> _SubjectDAL = new Mock<ISubjectDAL>();
        public SubjectTestService()
        {
            _SubjectService = new SubjectService(_SubjectDAL.Object);
        }

        [Fact]
        public void CreateSubject_ShouldReturnStatusCode200()
        {
            var Subjects = SubjectsMock.CreateSubject();
            _SubjectDAL.Setup(SubjectDAL => SubjectDAL.CreateSubject(Subjects)).Returns(true);
            var Result = _SubjectService.CreateSubject(Subjects);
            Result!.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        public void CreateSubject_ShouldReturnStatusCode400_WhenStudetnObjectIsNull(Subject Subject)
        {
            var result = () => _SubjectService.CreateSubject(Subject);
            result.Should().Throw<ValidationException>();
        }

        [Fact]
        public void CreateSubject_ShouldReturnStatusCoe500_WhenInternalErrorOccured()
        {
            var Subjects = SubjectsMock.CreateSubject();
            _SubjectDAL.Setup(SubjectService => SubjectService.CreateSubject(Subjects)).Returns(false);
            var Result = _SubjectService.CreateSubject(Subjects);
            Result!.Should().BeFalse();
        }

        [Fact]
        public void CreateSubject_ShouldReturnStatusCoe400_WithValidationException()
        {
            var Subjects = SubjectsMock.CreateSubject();
            _SubjectDAL.Setup(SubjectService => SubjectService.CreateSubject(Subjects)).Throws<ValidationException>();
            var Result = () => _SubjectService.CreateSubject(Subjects);
            Result!.Should().Throw<ValidationException>();
        }

    }
}