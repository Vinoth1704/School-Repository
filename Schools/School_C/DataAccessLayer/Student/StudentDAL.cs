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
            catch
            {
                throw new Exception();
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return (from Student in _db.students select Student);
        }

        public Student GetParticularStudent()
        {
            var lastRecord = _db.students!.OrderByDescending(s => s.RollNumber).FirstOrDefault()!;
            return lastRecord;
        }
    }
}