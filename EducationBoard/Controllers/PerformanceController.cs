using Microsoft.AspNetCore.Mvc;
using EducationBoard.Services;

namespace EducationBoard.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PerformanceController : ControllerBase
    {
        private IPerformanceService _performanceService;
        public PerformanceController(IPerformanceService performanceService)
        {
            _performanceService = performanceService;
        }

        [HttpGet]
        public IActionResult GetAllScores()
        {
            try
            {
                return Ok(_performanceService.GetAllScores());
            }
            catch (Exception exception)
            {
                return Problem(exception.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAverage()
        {
            try
            {
                return Ok(_performanceService.GetAverage());
            }
            catch (Exception exception)
            {
                return Problem(exception.Message);
            }
        }
    }
}