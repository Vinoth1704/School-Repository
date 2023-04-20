using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.DAL
{
    public class SchoolDbContext : DbContext
    {
        public int code;
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options, IConfiguration configuration) : base(options)
        {
            code = Convert.ToInt32(configuration.GetSection("SchoolSettings").GetSection("SchoolCode").Value) * 10000;
        }

        public DbSet<Student>? students { get; set; }
        public DbSet<Subject>? subjects { get; set; }
        public DbSet<Score>? scores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(s => s.RollNumber);
            modelBuilder.Entity<Subject>().HasKey(s => s.SubjectID);
            modelBuilder.Entity<Score>().HasKey(s => s.ScoreID);

            modelBuilder.Entity<Student>()
            .Property(p => p.RollNumber)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn(code, 1);

            modelBuilder.Entity<Score>()
            .HasOne<Student>(st => st.student)
            .WithMany(st => st.scores)
            .HasForeignKey(s => s.RollNumber);

            modelBuilder.Entity<Score>()
            .HasOne<Subject>(st => st.subject)
            .WithMany(st => st.scores)
            .HasForeignKey(s => s.SubjectID);

            modelBuilder.Entity<Subject>().HasData(
                new Subject { SubjectID = 1, SubjectName = "Tamil" },
                new Subject { SubjectID = 2, SubjectName = "English" },
                new Subject { SubjectID = 3, SubjectName = "Maths" },
                new Subject { SubjectID = 4, SubjectName = "Science" },
                new Subject { SubjectID = 5, SubjectName = "Social" }
            );
        }

    }
}