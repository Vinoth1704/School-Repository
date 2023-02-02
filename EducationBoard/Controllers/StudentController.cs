using Microsoft.AspNetCore.Mvc;
using EducationBoard.Models;
using EducationBoard.Services;
using System.ComponentModel.DataAnnotations;

namespace EducationBoard.Controllers
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
            if (student == null || string.IsNullOrEmpty(student.StudentName)) return BadRequest("Student fields can't be empty");
            try
            {
                return _studentService.CreateStudent(student) ? Ok("Student created successfully") : Problem("Internal error occured");
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