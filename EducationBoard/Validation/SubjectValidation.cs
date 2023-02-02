using System.ComponentModel.DataAnnotations;
using EducationBoard.Models;

namespace EducationBoard.Validations
{
    public static class Subjectvalidation
    {
        public static void IsSubjectValid(Subject subject)
        {
            if(subject==null) throw new ValidationException("Subject can't be null or empty");
            if(string.IsNullOrEmpty(subject.SubjectName))throw new ValidationException("Subject name can't be null or empty");
        }
    }
}