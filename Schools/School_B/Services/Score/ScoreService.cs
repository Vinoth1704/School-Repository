using AutoMapper;
using Newtonsoft.Json;
using School.DAL;
using School.Models;

namespace School.Services
{
    public class ScoreService : IScoreService
    {
        private IScoreDAL _scoreDAL;
        private IMapper _mapper;
        private IMessagingService _messagingService;

        public ScoreService(IScoreDAL scoreDAL, IMapper mapper, IMessagingService messagingService)
        {
            _scoreDAL = scoreDAL;
            _mapper = mapper;
            _messagingService = messagingService;
        }

        public bool CreateScore(Score score)
        {
            if (_scoreDAL.CreateScore(score))
            {
                try
                {
                    string scoreDetails = JsonConvert.SerializeObject(new
                    {
                        Function = "Added Score",
                        RollNumber = score.RollNumber,
                        SubjectID = score.SubjectID,
                        Mark = score.Mark
                    });
                    _messagingService.SendMessage(scoreDetails);
                }
                catch
                {
                    throw new Exception("Intrenal Error occured");
                }
                return true;
            }
            else
            {
                throw new Exception("Intrenal Error occured");
            }

        }

        public IEnumerable<ScoreDTO> GetAllScores()
        {
            try
            {
                var scores = _scoreDAL.GetAllScores();
                var scoresDTO = _mapper.Map<List<ScoreDTO>>(scores);
                return scoresDTO;
            }
            catch
            {
                throw new Exception("Internal server error");
            }
        }
    }
}