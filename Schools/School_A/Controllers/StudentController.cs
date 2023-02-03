using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using School.Models;
using School.Services;

namespace School.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (
                student == null
                || string.IsNullOrEmpty(student.StudentName)
                || string.IsNullOrEmpty(student.Address)
            )
                return BadRequest("Student fields can't be empty");
            try
            {
                _studentService.CreateStudent(student);
                return Ok("Student created successfully");
            }
            catch (ValidationException studentNotValid)
            {
                return BadRequest(studentNotValid.Message);
            }
            catch (Exception exception)
            {
                return Problem(exception.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            try
            {
                return Ok(_studentService.GetAllStudents());
            }
            catch (Exception exception)
            {
                return Problem(exception.Message);
            }
        }
    }
}
