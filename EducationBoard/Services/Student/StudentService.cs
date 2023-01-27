using EducationBoard.DAL;
using EducationBoard.Models;

namespace EducationBoard.Services
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
            try
            {
                _studentDAL.CreateStudent(student);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentDAL.GetAllStudents();
        }
    }
} 