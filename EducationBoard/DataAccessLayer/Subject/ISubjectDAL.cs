using EducationBoard.Models;

namespace EducationBoard.DAL
{
    public interface ISubjectDAL
    {
        public bool CreateSubject(Subject subject);
        public IQueryable<Subject> GetAllSubjects();
    }
}