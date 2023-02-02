using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class Student
    {
       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RollNumber { get; set; }
        public string? StudentName { get; set; }
        public string? Address { get; set; }
        public ICollection<Score>? scores { get; set; }

    }
}