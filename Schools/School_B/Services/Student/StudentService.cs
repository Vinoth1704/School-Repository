using Newtonsoft.Json;
using School.DAL;
using School.Models;
using School.Validations;

namespace School.Services
{
    public class StudentService : IStudentService
    {
        private IStudentDAL _studentDAL;

        public StudentService(IStudentDAL studentDAL)
        {
            _studentDAL = studentDAL;
        }

        public bool CreateStudent(Student student)
        {
            StudentValidation.IsStudentValid(student);
            return _studentDAL.CreateStudent(student);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentDAL.GetAllStudents();
        }
    }
}
