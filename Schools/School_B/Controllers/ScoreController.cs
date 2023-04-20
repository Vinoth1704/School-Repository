using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Services;

namespace School.Controllers
{
    [Authorize]
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
            if (score == null)
                throw new ValidationException("Score Object can't be null");
            // try
            // {
            _scoreService.CreateScore(score!);
            return Created("Score created successfully",score);
            // }
            // catch (ValidationException studentNotValid)
            // {
            //     return BadRequest(studentNotValid.Message);
            // }
            // catch (Exception exception)
            // {
            //     return Problem(exception.Message);
            // }
        }

        [HttpGet]
        public IActionResult GetAllScores()
        {
            // try
            // {
            return Ok(_scoreService.GetAllScores());
            // }
            // catch (Exception exception)
            // {
            //     return Problem(exception.Message);
            // }
        }
    }
}
