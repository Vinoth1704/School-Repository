using Microsoft.AspNetCore.Mvc;
using EducationBoard.Models;
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
        public IActionResult GetAllStudents()
        {
            Console.WriteLine("Hello");
            return Ok(_performanceService.GetAllScores());
        }

        [HttpGet]
        public IActionResult GetAverage()
        {
           
            return Ok( _performanceService.GetAverage());
        }
    }
}