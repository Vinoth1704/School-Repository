
using EducationBoard.Models;

namespace EBUnitTesting.MockData
{
    public static class StudentsMock
    {

        public static List<Student> ListOfStudents()
        {
            List<Student> studentMock = new List<Student>();
            studentMock.Add(new Student { RollNumber = 10001, StudentName = "Alex", SchoolID = 1 });
            studentMock.Add(new Student { RollNumber = 10002, StudentName = "Bob", SchoolID = 1 });
            studentMock.Add(new Student { RollNumber = 10003, StudentName = "Charles", SchoolID = 1 });
            return studentMock;
        }
        public static Student CreateStudent()
        {
            return new Student() { SchoolID = 1, StudentName = "Alex" };
        }
    }
}