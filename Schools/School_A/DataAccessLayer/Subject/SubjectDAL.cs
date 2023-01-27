using School.Models;

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
            try
            {
                _db.Add(subject);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<Subject> GetAllSubjects()
        {
            try
            {
                return (from Subject in _db.subjects select Subject);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}