using EducationBoard.DAL;
using EducationBoard.Models;
using EducationBoard.Validations;

namespace EducationBoard.Services
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
            try
            {
                return _SubjectDAL.CreateSubject(subject) ? true : false;
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