using System.ComponentModel.DataAnnotations;
using EducationBoard.Models;

namespace EducationBoard.Validations
{
    public static class PerformanceValidation
    {
        public static void IsScoreValid(Performance performance)
        {
            if(performance==null) throw new ValidationException("performance object can't be null or empty");
            if(performance.Mark<0) throw new ValidationException("Mark can't be in negative values");
            if(performance.Mark>100) throw new ValidationException("Mark can't be more than 100");
        }
        
    }
}