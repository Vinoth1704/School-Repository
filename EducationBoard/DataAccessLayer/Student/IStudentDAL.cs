using EducationBoard.Models;

namespace EducationBoard.DAL
{
    public interface IStudentDAL
    {
        public bool CreateStudent(Student student);
        public IEnumerable<Student> GetAllStudents();
    }
}