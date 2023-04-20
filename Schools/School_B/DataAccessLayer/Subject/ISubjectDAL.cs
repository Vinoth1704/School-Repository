using School.Models;

namespace School.DAL
{
    public interface ISubjectDAL
    {
        public bool CreateSubject(Subject subject);
        public IEnumerable<Subject> GetAllSubjects();
    }
}