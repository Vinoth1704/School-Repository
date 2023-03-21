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
            if (Subject == null || string.IsNullOrEmpty(Subject.SubjectName)) throw new ValidationException("Subject fields can't be empty");
            // try
            // {
            _SubjectService.CreateSubject(Subject);
            return Ok("Subject created successfully");
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
        public IActionResult GetAllSubjects()
        {
            // try
            // {
            return Ok(_SubjectService.GetAllSubjects());
            // }
            // catch (Exception exception)
            // {
            //     return Problem(exception.Message);
            // }
        }
    }
}