using School.Models;

namespace School.Services
{
    public interface IStudentService
    {
        public Task<bool> CreateStudent(Student student);
        public IEnumerable<Student> GetAllStudents();
    }
}
