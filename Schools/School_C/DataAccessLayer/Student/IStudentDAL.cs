using School.Models;

namespace School.DAL
{
    public interface IStudentDAL
    {
        public bool CreateStudent(Student student);
        public IEnumerable<Student> GetAllStudents();
        public Student GetParticularStudent();
    }
}