using School.Models;
using School.Validations;

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
            StudentValidation.IsStudentValid(student);
            try
            {
                // _db.Add(student);
                // _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {
            try
            {
                return (from Student in _db.students select Student);
            }
            catch
            {
                throw new Exception("Interanl error occured...");
            }
        }

        public Student GetLastSavedStudent()
        {
            try
            {
                var lastRecord = _db.students!.OrderByDescending(s => s.RollNumber).FirstOrDefault()!;
                return lastRecord;
            }
            catch
            {
                throw new Exception("Interanl error occured...");
            }

        }
    }
}