using School.Models;

namespace School.Services
{
    public interface IStudentService
    {
        public bool CreateStudent(Student student);
        public IEnumerable<Student> GetAllStudents();
    }
}