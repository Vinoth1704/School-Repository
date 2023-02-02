using System.ComponentModel.DataAnnotations;
using School.Models;

namespace School.Validations
{
    public static class StudentValidation
    {
        public static void IsStudentValid(Student student)
        {
            if (student == null) throw new ValidationException("Student can't be null");
            if (string.IsNullOrEmpty(student.StudentName)) throw new ValidationException("Student name can't be null");
            if (string.IsNullOrEmpty(student.Address)) throw new ValidationException("Student address can't be null");
        }

        public static void IsStudentIdValid(int studentID){
            if(studentID<=0) throw new ValidationException("Student ID can't be negative or zero");
        }
    }
}