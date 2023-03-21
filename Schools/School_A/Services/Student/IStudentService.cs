using School.Models;

namespace School.Services
{
    public interface IStudentService
    {
        public Task<bool> CreateStudentAsync(Student student);
        public IEnumerable<Student> GetAllStudents();
    }
}
