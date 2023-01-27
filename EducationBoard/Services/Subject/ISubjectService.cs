using EducationBoard.Models;

namespace EducationBoard.Services
{
    public interface ISubjectService
    {
        public bool CreateSubject(Subject Subject);
        public IEnumerable<Subject> GetAllSubjects();
    }
}