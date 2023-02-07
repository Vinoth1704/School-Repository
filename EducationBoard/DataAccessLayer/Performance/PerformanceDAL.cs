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

        public IEnumerable<PerformanceDTO> GetAverage()
        {
            try
            {
                return (
                    (
                        from student in _db.performances
                        group student by student.student!.school into s
                        select new PerformanceDTO
                        {
                            SchoolName = s.Key.SchoolName,
                            subjects = s.GroupBy(s => s.subject!.SubjectName)
                                .Select(
                                    s =>
                                        new SubjectsDTO
                                        {
                                            Subject = s.Key,
                                            Average = Math.Round(s.Average(a => a.Mark), 2),
                                            NumberOfStudentsEachSubject = s.Select(
                                                    s => s.RollNumber
                                                )
                                                .Distinct()
                                                .Count()
                                        }
                                ),
                            NumberOfStudents = s.Select(s => s.RollNumber).Distinct().Count(),
                            OverAllPercentage = Math.Round(s.Average(s => s.Mark), 2),
                        }
                    )
                );
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
