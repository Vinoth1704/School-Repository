namespace EducationBoard.Models
{
    public class PerformanceDTO
    {
        public string? SchoolName { get; set; }
        public IEnumerable<SubjectsDTO>? subjects { get; set; }
        public double OverAllPercentage { get; set; }
        public int NumberOfStudents { get; set; }
    }

    public class SubjectsDTO
    {
        public string? Subject { get; set; }
        public double Average { get; set; }
        public int NumberOfStudentsEachSubject { get; set; }

    }
}
