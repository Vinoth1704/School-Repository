using School.Models;

namespace School.DAL
{
    public interface IScoreDAL
    {
        public bool CreateScore(Score Score);
        public IEnumerable<Score> GetAllScores();
    }
}