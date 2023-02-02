using EducationBoard.Models;
using EducationBoard.Validations;

namespace EducationBoard.DAL
{
    public class SubjectDAL : ISubjectDAL
    {
        private EducationBoardDbContext _db;
        public SubjectDAL(EducationBoardDbContext dbContext)
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
                throw new Exception("Internal error occured");
            }
        }

        public IQueryable<Subject> GetAllSubjects()
        {
            try
            {
                return (from Subject in _db.subjects select Subject);
            }
            catch
            {
                throw new Exception("Internal error occured");
            }
        }
    }
}