using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Services;

namespace School.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ScoreController : ControllerBase
    {
        private IScoreService _scoreService;
        public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }
        [HttpPost]
        public IActionResult CreateScore(Score score)
        {
            try
            {
                _scoreService.CreateScore(score);
                return Ok("Score created successfully");
            }
            catch (Exception exception)
            {
                return Problem(exception.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllScores()
        {
            return Ok(_scoreService.GetAllScores());

        }
    }
}