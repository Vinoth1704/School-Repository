using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.DAL
{
    public class ScoreDAL : IScoreDAL
    {
        private SchoolDbContext _db;
        public ScoreDAL(SchoolDbContext dbContext)
        {
            _db = dbContext;
        }
        public bool CreateScore(Score Score)
        {
            try
            {
                _db.Add(Score);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Internal error occured...");
            }
        }

        public IEnumerable<Score> GetAllScores()
        {
            try
            {
                return (from Score in _db.scores!.Include(s => s.student).Include(s => s.subject) select Score);
            }
            catch
            {
                throw new Exception("Internal error occured...");
            }
        }
    }
}