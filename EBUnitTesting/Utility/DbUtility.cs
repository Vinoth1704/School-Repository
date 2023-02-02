using EducationBoard.DAL;
using Microsoft.EntityFrameworkCore;
using EBUnitTesting.MockData;

namespace EBUnitTesting.Utility
{
    public static class DbUtility
    {
        public static EducationBoardDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<EducationBoardDbContext>().UseInMemoryDatabase(databaseName: "Local Db").Options;
            return new EducationBoardDbContext(options); ;
        }
        public static void SeedInMemoryDb(EducationBoardDbContext dbContext)
        {
            dbContext.students!.AddRange(StudentsMock.ListOfStudents());
            dbContext.SaveChanges();
        }
    }
    public static class CommanUtility
    {
        public static string Problem { get; } = "Sorry some internal error occured";
    }

}