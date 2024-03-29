﻿// <auto-generated />
using EducationBoard.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EducationBoard.Migrations
{
    [DbContext(typeof(EducationBoardDbContext))]
    [Migration("20230404052737_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EducationBoard.Models.Performance", b =>
                {
                    b.Property<int>("PerformanceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PerformanceID"));

                    b.Property<float>("Mark")
                        .HasColumnType("real");

                    b.Property<int>("RollNumber")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.HasKey("PerformanceID");

                    b.HasIndex("RollNumber");

                    b.HasIndex("SubjectID");

                    b.ToTable("performances");
                });

            modelBuilder.Entity("EducationBoard.Models.School", b =>
                {
                    b.Property<int>("SchoolID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SchoolID"));

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchoolID");

                    b.ToTable("schools");
                });

            modelBuilder.Entity("EducationBoard.Models.Student", b =>
                {
                    b.Property<int>("RollNumber")
                        .HasColumnType("int");

                    b.Property<int>("SchoolID")
                        .HasColumnType("int");

                    b.Property<string>("StudentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RollNumber");

                    b.HasIndex("SchoolID");

                    b.ToTable("students");
                });

            modelBuilder.Entity("EducationBoard.Models.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectID"));

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectID");

                    b.ToTable("subjects");

                    b.HasData(
                        new
                        {
                            SubjectID = 1,
                            SubjectName = "Tamil"
                        },
                        new
                        {
                            SubjectID = 2,
                            SubjectName = "English"
                        },
                        new
                        {
                            SubjectID = 3,
                            SubjectName = "Maths"
                        },
                        new
                        {
                            SubjectID = 4,
                            SubjectName = "Science"
                        },
                        new
                        {
                            SubjectID = 5,
                            SubjectName = "Social"
                        });
                });

            modelBuilder.Entity("EducationBoard.Models.Performance", b =>
                {
                    b.HasOne("EducationBoard.Models.Student", "student")
                        .WithMany("performances")
                        .HasForeignKey("RollNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EducationBoard.Models.Subject", "subject")
                        .WithMany("performances")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("student");

                    b.Navigation("subject");
                });

            modelBuilder.Entity("EducationBoard.Models.Student", b =>
                {
                    b.HasOne("EducationBoard.Models.School", "school")
                        .WithMany("students")
                        .HasForeignKey("SchoolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("school");
                });

            modelBuilder.Entity("EducationBoard.Models.School", b =>
                {
                    b.Navigation("students");
                });

            modelBuilder.Entity("EducationBoard.Models.Student", b =>
                {
                    b.Navigation("performances");
                });

            modelBuilder.Entity("EducationBoard.Models.Subject", b =>
                {
                    b.Navigation("performances");
                });
#pragma warning restore 612, 618
        }
    }
}
