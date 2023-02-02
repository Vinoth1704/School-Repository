using System.ComponentModel.DataAnnotations;
using EducationBoard.DAL;
using EducationBoard.Models;
using EducationBoard.Validations;

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
            StudentValidation.IsStudentValid(student);
            try
            {
                return _studentDAL.CreateStudent(student) ? true : false;
            }
            catch (ValidationException VE)
            {
                throw VE;
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