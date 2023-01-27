using AutoMapper;
using School.DAL;
using School.Models;

namespace School.Services
{
    public class ScoreService : IScoreService
    {
        private IScoreDAL _scoreDAL;
        private IMapper _mapper;
        public ScoreService(IScoreDAL scoreDAL, IMapper mapper)
        {
            _scoreDAL = scoreDAL;
            _mapper = mapper;
        }

        public bool CreateScore(Score score)
        {
            try
            {
                _scoreDAL.CreateScore(score);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<ScoreDTO> GetAllScores()
        {
            var scores = _scoreDAL.GetAllScores();
            var scoresDTO = _mapper.Map<IEnumerable<ScoreDTO>>(scores);
            return scoresDTO;
        }
    }
}