using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Services;

namespace School.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SubjectController : ControllerBase
    {
        private ISubjectService _SubjectService;
        public SubjectController(ISubjectService SubjectService)
        {
            _SubjectService = SubjectService;
        }
        [HttpPost]
        public IActionResult CreateSubject(Subject Subject)
        {
            try
            {
                _SubjectService.CreateSubject(Subject);
                return Ok("Subject created successfully");
            }
            catch (Exception exception)
            {
                return Problem(exception.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllSubjects()
        {
            return Ok(_SubjectService.GetAllSubjects());
        }
    }
}