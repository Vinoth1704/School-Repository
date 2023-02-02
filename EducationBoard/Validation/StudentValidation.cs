using System.ComponentModel.DataAnnotations;
using EducationBoard.Models;

namespace EducationBoard.Validations
{
    public static class StudentValidation
    {
        public static void IsStudentValid(Student student)
        {
            if (student == null) throw new ValidationException("Student can't be null");
            if (string.IsNullOrEmpty(student.StudentName)) throw new ValidationException("Student name can't be null");
            if(student.SchoolID<=0) throw new ValidationException("school ID can't be 0 or lesser than it.");
        }

        public static void IsStudentIdValid(int studentID){
            if(studentID<=0) throw new ValidationException("Student ID can't be negative or zero");
        }
    }
}