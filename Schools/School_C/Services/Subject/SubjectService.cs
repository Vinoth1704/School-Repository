using School.DAL;
using School.Models;

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
            try
            {
                _SubjectDAL.CreateSubject(subject);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return _SubjectDAL.GetAllSubjects();
        }
    }
}