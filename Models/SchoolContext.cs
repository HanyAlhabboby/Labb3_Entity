using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Labb3_Entity.Models
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<ClassCourse> ClassCourses { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentClass> StudentClasses { get; set; } = null!;
        public virtual DbSet<Titel> Titels { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog=School;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.ClassName).HasMaxLength(50);
            });

            modelBuilder.Entity<ClassCourse>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Class_Course");

                entity.Property(e => e.FkClassId).HasColumnName("FK_ClassID");

                entity.Property(e => e.FkCourseId).HasColumnName("FK_CourseID");

                entity.HasOne(d => d.FkClass)
                    .WithMany()
                    .HasForeignKey(d => d.FkClassId)
                    .HasConstraintName("FK_Class_Course_Class");

                entity.HasOne(d => d.FkCourse)
                    .WithMany()
                    .HasForeignKey(d => d.FkCourseId)
                    .HasConstraintName("FK_Class_Course_Course");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FkEmployee).HasColumnName("FK_Employee");

                entity.HasOne(d => d.FkEmployeeNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.FkEmployee)
                    .HasConstraintName("FK_Course_Employee");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FkTitelId).HasColumnName("FK_TitelID");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.HasOne(d => d.FkTitel)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.FkTitelId)
                    .HasConstraintName("FK_Employee_Titel");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                
                entity.ToTable("Grade");

                entity.Property(e => e.GradeID).HasColumnName("GradeID");


                entity.Property(e => e.FkCourseId).HasColumnName("FK_CourseID");

                entity.Property(e => e.FkStudentId).HasColumnName("FK_StudentID");

                entity.Property(e => e.GradeDate).HasColumnType("date");

                entity.Property(e => e.GradeInfo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkCourse)
                    .WithMany()
                    .HasForeignKey(d => d.FkCourseId)
                    .HasConstraintName("FK_Grade_Course");

                entity.HasOne(d => d.FkStudent)
                    .WithMany()
                    .HasForeignKey(d => d.FkStudentId)
                    .HasConstraintName("FK_Grade_Student");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PersonalNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentClass>(entity =>
            {
                entity.HasKey(sc => new { sc.FkStudentId, sc.FkClassId });

                entity.ToTable("Student_Class");

                entity.Property(e => e.FkClassId).HasColumnName("FK_ClassID");

                entity.Property(e => e.FkStudentId).HasColumnName("FK_StudentID");

                entity.HasOne(d => d.FkClass)
                    .WithMany()
                    .HasForeignKey(d => d.FkClassId)
                    .HasConstraintName("FK_Student_Class_Class");

                entity.HasOne(d => d.FkStudent)
                    .WithMany()
                    .HasForeignKey(d => d.FkStudentId)
                    .HasConstraintName("FK_Student_Class_Student");
            });

            modelBuilder.Entity<Titel>(entity =>
            {
                entity.ToTable("Titel");

                entity.Property(e => e.TitelId).HasColumnName("TitelID");

                entity.Property(e => e.Titel1)
                    .HasMaxLength(50)
                    .HasColumnName("Titel");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
