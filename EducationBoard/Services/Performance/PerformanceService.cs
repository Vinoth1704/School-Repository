using AutoMapper;
using EducationBoard.DAL;
using EducationBoard.Models;

namespace EducationBoard.Services
{
    public class PerformanceService : IPerformanceService
    {
        private IPerformanceDAL _performanceDAL;
        private IMapper _mapper;

        public PerformanceService(IPerformanceDAL performanceDAL, IMapper mapper)
        {
            _performanceDAL = performanceDAL;
            _mapper = mapper;
        }

        public IEnumerable<Performance> GetAllScores()
        {
            return _performanceDAL.GetAllScores();
        }

        // public object GetAverage()
        // {
        //     try
        //     {
        //         return _performanceDAL.GetAverage();
        //     }
        //     catch
        //     {
        //         throw;
        //     }
        // }

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

        public IEnumerable<PerformanceDTO> GetAverage()
        {
            try
            {
                return _performanceDAL.GetAverage();
            }
            catch
            {
                throw;
            }
        }
    }
}
