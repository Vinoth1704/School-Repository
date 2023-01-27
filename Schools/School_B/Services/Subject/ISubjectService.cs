using School.Models;

namespace School.Services
{
    public interface ISubjectService
    {
        public bool CreateSubject(Subject Subject);
        public IEnumerable<Subject> GetAllSubjects();
    }
}