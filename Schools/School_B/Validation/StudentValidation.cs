using School.Models;

namespace School.Validations
{
    public static class StudentValidation
    {
        public static void IsStudentValid(Student student)
        {
            if (student == null) throw new Exception("Student can't be null");
            if (string.IsNullOrEmpty(student.StudentName)) throw new Exception("Student name can't be null");
            if (string.IsNullOrEmpty(student.Address)) throw new Exception("Student address can't be null");
        }

        public static void IsStudentIdValid(int studentID){
            if(studentID<=0) throw new Exception("Student ID can't be negative or zero");
        }
    }
}