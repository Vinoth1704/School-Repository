using Microsoft.AspNetCore.Mvc;
using EducationBoard.Models;
using EducationBoard.Services;
using System.ComponentModel.DataAnnotations;

namespace EducationBoard.Controllers
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
            if (Subject == null || string.IsNullOrEmpty(Subject.SubjectName)) return BadRequest("Subject fields can't be empty");
            try
            {
                _SubjectService.CreateSubject(Subject);
                return Ok("Subject created successfully");
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                return Problem(exception.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllSubjects()
        {
            try
            {
                return Ok(_SubjectService.GetAllSubjects());
            }
            catch
            {
                return Problem("Internal error occured");
            }
        }
    }
}