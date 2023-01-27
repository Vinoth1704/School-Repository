﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using School.DAL;

#nullable disable

namespace SchoolC.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20230109071605_Create_database")]
    partial class Createdatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("School.Models.Score", b =>
                {
                    b.Property<int>("RollNumber")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.Property<decimal>("Mark")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ScoreID")
                        .HasColumnType("int");

                    b.HasKey("RollNumber", "SubjectID");

                    b.HasIndex("SubjectID");

                    b.ToTable("scores");
                });

            modelBuilder.Entity("School.Models.Student", b =>
                {
                    b.Property<int>("RollNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RollNumber"), 3000L);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RollNumber");

                    b.ToTable("students");
                });

            modelBuilder.Entity("School.Models.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectID"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectID");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("School.Models.Score", b =>
                {
                    b.HasOne("School.Models.Student", "student")
                        .WithMany("scores")
                        .HasForeignKey("RollNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School.Models.Subject", "subject")
                        .WithMany("scores")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("student");

                    b.Navigation("subject");
                });

            modelBuilder.Entity("School.Models.Student", b =>
                {
                    b.Navigation("scores");
                });

            modelBuilder.Entity("School.Models.Subject", b =>
                {
                    b.Navigation("scores");
                });
#pragma warning restore 612, 618
        }
    }
}