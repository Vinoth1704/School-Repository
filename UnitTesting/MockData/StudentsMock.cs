
using School.Models;

namespace UnitTesting.MockData
{
    public static class StudentsMock
    {

        public static List<Student> ListOfStudents()
        {
            List<Student> studentMock = new List<Student>();
            studentMock.Add(new Student { RollNumber = 10001, StudentName = "Alex", Address = "Coimbatore" });
            studentMock.Add(new Student { RollNumber = 10002, StudentName = "Bob", Address = "Coimbatore" });
            studentMock.Add(new Student { RollNumber = 10003, StudentName = "Charles", Address = "Coimbatore" });
            return studentMock;
        }
        public static Student CreateStudent()
        {
            return new Student() { Address = "Coimbatore", StudentName = "Alex" };
        }

        public static Student LastStudent()
        {
            return new Student() { Address = "Coimbatore", StudentName = "Alex", RollNumber = 10001 };
        }
    }
}