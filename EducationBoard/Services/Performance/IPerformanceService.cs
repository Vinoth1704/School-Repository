using EducationBoard.Models;

namespace EducationBoard.Services
{
    public interface IPerformanceService
    {
        public IEnumerable<Performance> GetAllScores();
        public bool InsertMark(Performance performance);
        public object GetAverage();
    }

}