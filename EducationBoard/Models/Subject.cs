using System.ComponentModel.DataAnnotations;

namespace EducationBoard.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string? SubjectName { get; set; }
        public ICollection<Performance>? performances { get; set; }
    }
}