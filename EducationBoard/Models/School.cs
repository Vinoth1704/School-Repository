using System.ComponentModel.DataAnnotations;

namespace EducationBoard.Models
{
    public class School
    {
        public int SchoolID { get; set; }
        public string? SchoolName { get; set; }

        public ICollection<Student>? students { get; set; }
    }
}