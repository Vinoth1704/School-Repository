namespace School.Models
{
    public class Score
    {
        public int ScoreID { get; set; }
        public int RollNumber { get; set; }
        public int SubjectID { get; set; }
        public float Mark { get; set; }
        public Student? student { get; set; }
        public Subject? subject { get; set; }

    }
}