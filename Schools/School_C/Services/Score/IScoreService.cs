using School.Models;

namespace School.Services
{
    public interface IScoreService
    {
        public bool CreateScore(Score score);
        public IEnumerable<ScoreDTO> GetAllScores();
        // public object GetAllScores();
    }
}