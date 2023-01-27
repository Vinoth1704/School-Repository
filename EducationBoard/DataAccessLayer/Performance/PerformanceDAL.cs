using EducationBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationBoard.DAL
{
    public class PerformanceDAL : IPerformanceDAL
    {
        private EducationBoardDbContext _db;

        public PerformanceDAL(EducationBoardDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Performance> GetAllScores()
        {
            return (from Performance in _db.performances select Performance);
        }

        public IQueryable GetAverage()
        {
            try
            {
                var query = from student in _db.performances
                            group student by student.student!.school into s
                            select new
                            {
                                SchoolName = s.Key.SchoolName,
                                Subjects = s.GroupBy(s => s.subject!.SubjectName)
                                    .Select(s => new
                                    {
                                        Subject = s.Key,
                                        Average = Math.Round(s.Average(a => a.Mark), 2)
                                    }),
                                OverAllPercentage = Math.Round(s.Average(s => s.Mark), 2),
                                NumberOfStudents = s.Count()
                            };

                return query;
            }
            catch
            {
                throw new Exception("Internal server error");
            }
        }


        public bool InsertMark(Performance performance)
        {
            try
            {
                _db.Add<Performance>(performance);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Internal server error");
            }
        }
    }
}