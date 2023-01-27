using School.Models;

namespace School.DAL
{
    public class StudentDAL : IStudentDAL
    {
        private SchoolDbContext _db;
        public StudentDAL(SchoolDbContext dbContext)
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