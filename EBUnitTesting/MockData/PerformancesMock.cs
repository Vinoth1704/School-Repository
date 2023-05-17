using System.Collections.Generic;
using EducationBoard.Models;

namespace EBUnitTesting.MockData
{
    public static class PerformancesMock
    {

        public static IEnumerable<PerformanceDTO> ListOfAveragePerformances()
        {
            List<PerformanceDTO> PerformanceMock = new List<PerformanceDTO>();
            List<SubjectsDTO> SubjectMock = new List<SubjectsDTO>();
            SubjectMock.Add(new SubjectsDTO { Subject = "Tamil", Average = 90, NumberOfStudentsEachSubject = 10 });
            PerformanceMock.Add(new PerformanceDTO { SchoolName = "School A", subjects = SubjectMock, OverAllPercentage = 90, NumberOfStudents = 10 });
            return PerformanceMock;
        }
        public static IEnumerable<Performance>  ListOfPerformances()
        {
            List<Performance> PerformanceMock = new List<Performance>();
            PerformanceMock.Add(new Performance { RollNumber = 10001, SubjectID = 1, Mark = 90 });
            return PerformanceMock;
        }
        public static Performance CreatePerformance()
        {
            return new Performance() { RollNumber = 10000, SubjectID = 1, Mark = 90 };
        }
    }
}