using Microsoft.EntityFrameworkCore;
using EducationBoard.Models;

namespace EducationBoard.DAL
{
    public class EducationBoardDbContext : DbContext
    {
        public EducationBoardDbContext(DbContextOptions<EducationBoardDbContext> options) : base(options)
        {

        }

        public DbSet<School>? schools { get; set; }
        public DbSet<Student>? students { get; set; }
        public DbSet<Subject>? subjects { get; set; }
        public DbSet<Performance>? performances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(k=>k.RollNumber);
            modelBuilder.Entity<School>().HasKey(k=>k.SchoolID);
            modelBuilder.Entity<Subject>().HasKey(k=>k.SubjectID);
            modelBuilder.Entity<Performance>().HasKey(k=>k.PerformanceID);

            modelBuilder.Entity<Performance>()
            .HasOne<Student>(p => p.student)
            .WithMany(p => p.performances)
            .HasForeignKey(f => f.RollNumber);

            modelBuilder.Entity<Performance>()
            .HasOne<Subject>(s => s.subject)
            .WithMany(s => s.performances)
            .HasForeignKey(f => f.SubjectID);

            modelBuilder.Entity<Student>()
            .HasOne<School>(s => s.school)
            .WithMany(s => s.students)
            .HasForeignKey(f => f.SchoolID);
        }
    }
}