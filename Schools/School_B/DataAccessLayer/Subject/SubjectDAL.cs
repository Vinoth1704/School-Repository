using School.Models;
using School.Validations;

namespace School.DAL
{
    public class SubjectDAL : ISubjectDAL
    {
        private SchoolDbContext _db;
        public SubjectDAL(SchoolDbContext dbContext)
        {
            _db = dbContext;
        }
        public bool CreateSubject(Subject subject)
        {
            Subjectvalidation.IsSubjectValid(subject);
            try
            {
                _db.Add(subject);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Internal error occured...");
            }
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            try
            {
                return (from Subject in _db.subjects select Subject);
            }
            catch
            {
                throw new Exception("Internal error occured...");
            }
        }
    }
}