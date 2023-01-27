using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }
        public string? Name { get; set; }
        public ICollection<Score>? scores { get; set; }

    }
}