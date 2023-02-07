using EducationBoard.Models;
using EducationBoard.Validations;
using Microsoft.EntityFrameworkCore;

namespace EducationBoard.DAL
{
    public class StudentDAL : IStudentDAL
    {
        private EducationBoardDbContext _db;

        public StudentDAL(EducationBoardDbContext dbContext)
        {
            _db = dbContext;
        }

        public bool CreateStudent(Student student)
        {
            StudentValidation.IsStudentValid(student);
            try
            {
                _db.Add(student);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Internal error occured");
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {
            try
            {
                return (from Student in _db.students!.Include(s => s.school) select Student);
            }
            catch
            {
                throw new Exception("Internal server error occured");
            }
        }
    }
}
