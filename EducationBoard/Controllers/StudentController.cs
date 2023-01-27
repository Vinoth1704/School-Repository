using Microsoft.AspNetCore.Mvc;
using EducationBoard.Models;
using EducationBoard.Services;

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
            try
            {
                _studentService.CreateStudent(student);
                return Ok("Student created successfully");
            }
            catch (Exception exception)
            {
                return Problem(exception.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(_studentService.GetAllStudents());
        }
    }
}