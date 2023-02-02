using EducationBoard.Models;

namespace EBUnitTesting.MockData
{
    public static class SubjectsMock
    {
        public static List<Subject> ListOfSubjects()
        {
            List<Subject> subjectMock = new List<Subject>();
            subjectMock.Add(new Subject { SubjectID = 1, SubjectName = "Tamil" });
            subjectMock.Add(new Subject { SubjectID = 2, SubjectName = "Engish" });
            subjectMock.Add(new Subject { SubjectID = 3, SubjectName = "Social" });
            return subjectMock;
        }
        public static Subject CreateSubject()
        {
            return new Subject() { SubjectName = "Maths" };
        }
    }
}