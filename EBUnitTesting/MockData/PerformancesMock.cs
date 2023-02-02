using System.Collections.Generic;
using EducationBoard.Models;

namespace EBUnitTesting.MockData
{
    public static class PerformancesMock
    {

        public static List<Performance> ListOfPerformances()
        {
            List<Performance> PerformanceMock = new List<Performance>();
            PerformanceMock.Add(new Performance { RollNumber = 10000, SubjectID = 1, Mark = 90 });
            PerformanceMock.Add(new Performance { RollNumber = 10000, SubjectID = 2, Mark = 90 });
            PerformanceMock.Add(new Performance { RollNumber = 10000, SubjectID = 3, Mark = 90 });
            return PerformanceMock;
        }
        public static Performance CreatePerformance()
        {
            return new Performance() { RollNumber = 10000, SubjectID = 1, Mark = 90 };
        }
    }
}