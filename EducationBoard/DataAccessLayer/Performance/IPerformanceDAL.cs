using EducationBoard.Models;

namespace EducationBoard.DAL
{
    public interface IPerformanceDAL
    {
        public IEnumerable<Performance> GetAllScores();  
        public bool InsertMark(Performance performance);  
        // public IEnumerable<Performance> GetAverage();
        public IQueryable GetAverage();
        
    }
}