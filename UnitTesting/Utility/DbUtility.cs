using School.DAL;
using Microsoft.EntityFrameworkCore;
using UnitTesting.MockData;
using Microsoft.Extensions.Configuration;

namespace UnitTesting.Utility
{
    public static class DbUtility
    {
        private static readonly IConfiguration _config;
        public static SchoolDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<SchoolDbContext>().UseInMemoryDatabase(databaseName: "Local Db").Options;
            return new SchoolDbContext(options,_config); ;
        }
        public static void SeedInMemoryDb(SchoolDbContext dbContext)
        {
            dbContext.students!.AddRange(StudentsMock.ListOfStudents());
            dbContext.SaveChanges();
        }
    }
}