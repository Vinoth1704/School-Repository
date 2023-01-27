using EducationBoard.DAL;
using EducationBoard.Models;

namespace EducationBoard.Services
{
    public class PerformanceService : IPerformanceService
    {
        private IPerformanceDAL _performanceDAL;
        public PerformanceService(IPerformanceDAL performanceDAL)
        {
            _performanceDAL = performanceDAL;
        }
        public IEnumerable<Performance> GetAllScores()
        {
            return _performanceDAL.GetAllScores();
        }

        public object GetAverage()
        {
            try
            {
                // var performance = new List<Performance>();
                // performance = (List<Performance>)_performanceDAL.GetAverage();
                // return performance;
                return _performanceDAL.GetAverage();
            }
            catch
            {
                throw;
            }
        }

        public bool InsertMark(Performance performance)
        {
            try
            {
                _performanceDAL.InsertMark(performance);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}