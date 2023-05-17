
using EducationBoard.Models;

namespace EBUnitTesting.MockData
{
    public static class StudentsMock
    {

        public static IEnumerable<StudentsDTO> ListOfStudents()
        {
            List<StudentsDTO> studentMock = new List<StudentsDTO>();
            studentMock.Add(new StudentsDTO { RollNumber = 10001, StudentName = "Alex", SchoolName = "School A" });
            studentMock.Add(new StudentsDTO { RollNumber = 10002, StudentName = "Bob", SchoolName = "School A" });
            studentMock.Add(new StudentsDTO { RollNumber = 10003, StudentName = "Charles", SchoolName = "School A" });
            return studentMock;
        }
        public static IEnumerable<Student> GetAllStudents()
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