using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using School.Models;
using School.Services;

namespace School.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> CreateStudentAsync(Student student)
        {
            if (
                student == null
                || string.IsNullOrEmpty(student.StudentName)
                || string.IsNullOrEmpty(student.Address)
            )
                throw new ValidationException("Student fields can't be empty");
            // try
            // {
            await _studentService.CreateStudentAsync(student);
            return Ok(new { message = "Student created successfully" });
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
        public IActionResult GetAllStudents()
        {
            // try
            // {

            return Ok(_studentService.GetAllStudents());

            // }
            // catch (Exception exception)
            // {
            //     return Problem(exception.Message);
            // }
        }
    }
}
