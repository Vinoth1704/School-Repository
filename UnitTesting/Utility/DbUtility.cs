using School.DAL;
using Microsoft.EntityFrameworkCore;
using UnitTesting.MockData;
using Microsoft.Extensions.Configuration;

namespace UnitTesting.Utility
{
    public static class DbUtility
    {
        private static IConfiguration? _config;
        private static int code;
        public static SchoolDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<SchoolDbContext>().UseInMemoryDatabase(databaseName: "Local Db").Options;
             _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
            code = Convert.ToInt32(_config.GetSection("SchoolSettings").GetSection("SchoolCode").Value)*10000;
            return new SchoolDbContext(options,_config!); ;
        }
        public static void SeedInMemoryDb(SchoolDbContext dbContext)
        {
            dbContext.students!.AddRange(StudentsMock.ListOfStudents());
            dbContext.SaveChanges();
        }
    }
}