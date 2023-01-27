using EducationBoard.Models;

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
            try
            {
                _db.Add(student);
                _db.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return (from Student in _db.students select Student);
        }
    }
}