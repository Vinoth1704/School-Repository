using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationBoard.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RollNumber { get; set; }
        public int SchoolID { get; set; }
        public string? StudentName { get; set; }
        public School? school { get; set; }
        public ICollection<Performance>? performances { get; set; }
    }
}