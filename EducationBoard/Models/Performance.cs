using System.ComponentModel.DataAnnotations;

namespace EducationBoard.Models
{
    public class Performance
    {
        public int PerformanceID { get; set; }
        public int RollNumber { get; set; }
        public int SubjectID { get; set; }
        public float Mark { get; set; }
        public Student? student{get;set;}
        public Subject? subject { get; set; }
    }
}