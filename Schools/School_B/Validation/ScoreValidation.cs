using School.Models;

namespace School.Validations
{
    public static class ScoreValidation
    {
        public static void IsScoreValid(Score score)
        {
            if(score==null) throw new Exception("Score object can't be null or empty");
            if(score.Mark<0) throw new Exception("Mark can't be in negative values");
            if(score.Mark>100) throw new Exception("Mark can't be more than 100");
        }
        
    }
}