using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string? SubjectName { get; set; }
        public ICollection<Score>? scores { get; set; }
    }
}