using EducationBoard.Models;

namespace EducationBoard.Services
{
    public interface IStudentService
    {
        public bool CreateStudent(Student student);
        public IEnumerable<Student> GetAllStudents();
    }
}