using School.DAL;
using School.Models;
using School.Validations;

namespace School.Services
{
    public class SubjectService : ISubjectService
    {
        private ISubjectDAL _SubjectDAL;
        public SubjectService(ISubjectDAL subjectDAL)
        {
            _SubjectDAL = subjectDAL;
        }
        public bool CreateSubject(Subject subject)
        {
            Subjectvalidation.IsSubjectValid(subject);
            if (_SubjectDAL.CreateSubject(subject)) return true; else throw new Exception("Internal error occured...");
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return _SubjectDAL.GetAllSubjects();
        }
    }
}