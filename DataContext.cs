using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SchoolDataExample
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // SQLite DB file created locally, no SQL required
            options.UseSqlite("Data Source=school.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // All of this would ideally already be in the database,
            // or at least loaded from an XML file for example.
            // This is hardcoded in here instead just to make it
            // slightly easier to read and see examples.

            // Composite key: Student + Course
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.StudentId, e.CourseId });

            // Seed Students
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Alice", LastName = "Anderson" },
                new Student { Id = 2, FirstName = "Brandon", LastName = "Brooks" },
                new Student { Id = 3, FirstName = "Chloe", LastName = "Carter" },
                new Student { Id = 4, FirstName = "Daniel", LastName = "Dawson" },
                new Student { Id = 5, FirstName = "Emma", LastName = "Ellis" },
                new Student { Id = 6, FirstName = "Faith", LastName = "Foster" },
                new Student { Id = 7, FirstName = "Gavin", LastName = "Grant" },
                new Student { Id = 8, FirstName = "Hannah", LastName = "Hayes" },
                new Student { Id = 9, FirstName = "Isaac", LastName = "Irving" },
                new Student { Id = 10, FirstName = "Julia", LastName = "Jennings" },
                new Student { Id = 11, FirstName = "Kyle", LastName = "Kingston" },
                new Student { Id = 12, FirstName = "Lily", LastName = "Lawson" },
                new Student { Id = 13, FirstName = "Mason", LastName = "Mitchell" },
                new Student { Id = 14, FirstName = "Natalie", LastName = "Norris" },
                new Student { Id = 15, FirstName = "Oliver", LastName = "Owens" },
                new Student { Id = 16, FirstName = "Paige", LastName = "Parker" },
                new Student { Id = 17, FirstName = "Quentin", LastName = "Quinn" },
                new Student { Id = 18, FirstName = "Rachel", LastName = "Rivers" },
                new Student { Id = 19, FirstName = "Samuel", LastName = "Sanders" },
                new Student { Id = 20, FirstName = "Taylor", LastName = "Thompson" },
                new Student { Id = 21, FirstName = "Ursula", LastName = "Underwood" },
                new Student { Id = 22, FirstName = "Victor", LastName = "Vaughn" },
                new Student { Id = 23, FirstName = "Willow", LastName = "Watson" },
                new Student { Id = 24, FirstName = "Xavier", LastName = "Xander" },
                new Student { Id = 25, FirstName = "Yara", LastName = "Young" },
                new Student { Id = 26, FirstName = "Zoe", LastName = "Zimmerman" }
            );

            // Seed Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1222, Credits = 3, Title = "Intro to C++" },
                new Course { Id = 1223, Credits = 3, Title = "Intro to Java" },
                new Course { Id = 1224, Credits = 3, Title = "Intro to Python"},

                new Course { Id = 2221, Credits = 4, Title = "Software I"},
                new Course { Id = 2231, Credits = 4, Title = "Software II"},
                new Course { Id = 2321, Credits = 3, Title = "Foundations I"},
                new Course { Id = 2331, Credits = 3, Title = "Foundations II"},
                new Course { Id = 2421, Credits = 4, Title = "Systems I"},
                new Course { Id = 2431, Credits = 3, Title = "Systems II"},

                new Course { Id = 3241, Credits = 3, Title = "Intro to Databases"},
                new Course { Id = 3321, Credits = 3, Title = "Automata and Formal Languages"},
                new Course { Id = 3341, Credits = 3, Title = "Principles of Programming Languages"},
                new Course { Id = 3421, Credits = 3, Title = "Intro to Computer Architecture"},
                new Course { Id = 3461, Credits = 3, Title = "Intro to Computer Networking"},
                new Course { Id = 3521, Credits = 3, Title = "Intro to AI"},
                new Course { Id = 3541, Credits = 3, Title = "Intro to Graphics"},

                new Course { Id = 3901, Credits = 4, Title = "Project: Web Dev"},
                new Course { Id = 3902, Credits = 4, Title = "Project: Game Dev"},
                new Course { Id = 3903, Credits = 4, Title = "Project: System Dev"},

                new Course { Id = 4251, Credits = 1, Title = "Unix Programming"},
                new Course { Id = 4252, Credits = 1, Title = "C++ Programming"},
                new Course { Id = 4253, Credits = 1, Title = "C# Programming"},
                new Course { Id = 4254, Credits = 1, Title = "Lisp Programming"},
                new Course { Id = 4255, Credits = 1, Title = "Python Programming"}
            );

            // Seed Enrollments
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { StudentId = 1, CourseId = 1222, Grade = "A" },
                new Enrollment { StudentId = 1, CourseId = 2221, Grade = "A" },
                new Enrollment { StudentId = 1, CourseId = 2231, Grade = "B+" },
                new Enrollment { StudentId = 1, CourseId = 2321, Grade = "A-" },
                new Enrollment { StudentId = 1, CourseId = 2421, Grade = "A" },
                new Enrollment { StudentId = 1, CourseId = 2331, Grade = "B-" },
                new Enrollment { StudentId = 1, CourseId = 2431, Grade = "E" },

                new Enrollment { StudentId = 2, CourseId = 1223, Grade = "B+" },
                new Enrollment { StudentId = 2, CourseId = 2221, Grade = "B+" },
                new Enrollment { StudentId = 2, CourseId = 2231, Grade = "C+" },
                new Enrollment { StudentId = 2, CourseId = 2321, Grade = "B-" },
                new Enrollment { StudentId = 2, CourseId = 2421, Grade = "B" },
                new Enrollment { StudentId = 2, CourseId = 2331, Grade = "A-" },
                new Enrollment { StudentId = 2, CourseId = 2431, Grade = "B-" },
                new Enrollment { StudentId = 2, CourseId = 3461, Grade = "A" },
                new Enrollment { StudentId = 2, CourseId = 3541, Grade = "B+" },
                new Enrollment { StudentId = 2, CourseId = 3903, Grade = "C" },

                new Enrollment { StudentId = 3, CourseId = 1224, Grade = "A" },
                new Enrollment { StudentId = 3, CourseId = 2221, Grade = "A" },
                new Enrollment { StudentId = 3, CourseId = 2231, Grade = "D+" },
                // Invalid enrollment!
                new Enrollment { StudentId = 3, CourseId = 4252, Grade = "S" },

                new Enrollment { StudentId = 4, CourseId = 1222, Grade = "B-" },
                new Enrollment { StudentId = 4, CourseId = 2221, Grade = "B-" },
                new Enrollment { StudentId = 4, CourseId = 2231, Grade = "E" },
                // Invalid enrollment!
                new Enrollment { StudentId = 4, CourseId = 4253, Grade = "U" },

                new Enrollment { StudentId = 5, CourseId = 1222, Grade = "A" },
                new Enrollment { StudentId = 5, CourseId = 2221, Grade = "C" },
                new Enrollment { StudentId = 5, CourseId = 2231, Grade = "A-" },
                new Enrollment { StudentId = 5, CourseId = 2321, Grade = "B+" },
                new Enrollment { StudentId = 5, CourseId = 2421, Grade = "E" },

                new Enrollment { StudentId = 6, CourseId = 1223, Grade = "B" },
                new Enrollment { StudentId = 6, CourseId = 2221, Grade = "C" },
                new Enrollment { StudentId = 6, CourseId = 2231, Grade = "D+" },

                new Enrollment { StudentId = 7, CourseId = 1224, Grade = "B-" },
                new Enrollment { StudentId = 7, CourseId = 2221, Grade = "B-" },
                new Enrollment { StudentId = 7, CourseId = 2231, Grade = "A-" },
                new Enrollment { StudentId = 7, CourseId = 2321, Grade = "B+" },
                new Enrollment { StudentId = 7, CourseId = 2421, Grade = "A-" },
                new Enrollment { StudentId = 7, CourseId = 2331, Grade = "C+" },
                new Enrollment { StudentId = 7, CourseId = 2431, Grade = "C+" },
                new Enrollment { StudentId = 7, CourseId = 3241, Grade = "C+" },
                new Enrollment { StudentId = 7, CourseId = 3421, Grade = "A" },
                new Enrollment { StudentId = 7, CourseId = 3521, Grade = "A" },
                new Enrollment { StudentId = 7, CourseId = 3541, Grade = "B" },
                new Enrollment { StudentId = 7, CourseId = 3902, Grade = "D" },

                new Enrollment { StudentId = 8, CourseId = 1224, Grade = "C" },
                new Enrollment { StudentId = 8, CourseId = 2221, Grade = "B" },
                new Enrollment { StudentId = 8, CourseId = 2231, Grade = "D+" },

                new Enrollment { StudentId = 9, CourseId = 1222, Grade = "C" },
                new Enrollment { StudentId = 9, CourseId = 2221, Grade = "A" },
                new Enrollment { StudentId = 9, CourseId = 2231, Grade = "B+" },
                new Enrollment { StudentId = 9, CourseId = 2321, Grade = "C+" },
                new Enrollment { StudentId = 9, CourseId = 2421, Grade = "A" },
                new Enrollment { StudentId = 9, CourseId = 2331, Grade = "B-" },
                new Enrollment { StudentId = 9, CourseId = 2431, Grade = "B-" },
                new Enrollment { StudentId = 9, CourseId = 3421, Grade = "E" },
                new Enrollment { StudentId = 9, CourseId = 3541, Grade = "A" },
                new Enrollment { StudentId = 9, CourseId = 3903, Grade = "A" },

                new Enrollment { StudentId = 10, CourseId = 1223, Grade = "C+" },
                new Enrollment { StudentId = 10, CourseId = 2221, Grade = "B" },
                new Enrollment { StudentId = 10, CourseId = 2231, Grade = "B-" },
                new Enrollment { StudentId = 10, CourseId = 2321, Grade = "B+" },
                new Enrollment { StudentId = 10, CourseId = 2421, Grade = "C-" },
                new Enrollment { StudentId = 10, CourseId = 2331, Grade = "B+" },
                new Enrollment { StudentId = 10, CourseId = 2431, Grade = "B+" },
                new Enrollment { StudentId = 10, CourseId = 3241, Grade = "C-" },
                new Enrollment { StudentId = 10, CourseId = 3461, Grade = "B" },
                new Enrollment { StudentId = 10, CourseId = 3521, Grade = "A" },
                new Enrollment { StudentId = 10, CourseId = 3541, Grade = "A" },
                new Enrollment { StudentId = 10, CourseId = 3903, Grade = "C+" },

                new Enrollment { StudentId = 11, CourseId = 1223, Grade = "E" },

                new Enrollment { StudentId = 12, CourseId = 1222, Grade = "C-" },
                new Enrollment { StudentId = 12, CourseId = 2221, Grade = "B-" },
                new Enrollment { StudentId = 12, CourseId = 2231, Grade = "E" },
                // Invalid enrollment!
                new Enrollment { StudentId = 12, CourseId = 4252, Grade = "S" },

                new Enrollment { StudentId = 13, CourseId = 1223, Grade = "B+" },
                new Enrollment { StudentId = 13, CourseId = 2221, Grade = "A-" },
                new Enrollment { StudentId = 13, CourseId = 2231, Grade = "B" },
                new Enrollment { StudentId = 13, CourseId = 2321, Grade = "B" },
                new Enrollment { StudentId = 13, CourseId = 2421, Grade = "A-" },
                new Enrollment { StudentId = 13, CourseId = 2331, Grade = "D+" },

                new Enrollment { StudentId = 14, CourseId = 1224, Grade = "B+" },
                new Enrollment { StudentId = 14, CourseId = 2221, Grade = "C+" },
                new Enrollment { StudentId = 14, CourseId = 2231, Grade = "C+" },
                new Enrollment { StudentId = 14, CourseId = 2321, Grade = "A" },
                new Enrollment { StudentId = 14, CourseId = 2421, Grade = "C" },
                new Enrollment { StudentId = 14, CourseId = 2331, Grade = "A-" },
                new Enrollment { StudentId = 14, CourseId = 2431, Grade = "C-" },
                new Enrollment { StudentId = 14, CourseId = 3341, Grade = "A" },
                new Enrollment { StudentId = 14, CourseId = 3461, Grade = "A" },
                new Enrollment { StudentId = 14, CourseId = 3541, Grade = "C" },
                new Enrollment { StudentId = 14, CourseId = 3902, Grade = "A" },

                new Enrollment { StudentId = 15, CourseId = 1223, Grade = "D" },
                new Enrollment { StudentId = 16, CourseId = 1223, Grade = "A" },
                new Enrollment { StudentId = 16, CourseId = 2221, Grade = "B" },
                new Enrollment { StudentId = 16, CourseId = 2231, Grade = "C" },
                new Enrollment { StudentId = 16, CourseId = 2321, Grade = "D" },

                new Enrollment { StudentId = 17, CourseId = 1223, Grade = "E" },
                new Enrollment { StudentId = 18, CourseId = 1224, Grade = "A-" },
                new Enrollment { StudentId = 18, CourseId = 2221, Grade = "B" },
                new Enrollment { StudentId = 18, CourseId = 2231, Grade = "A" },
                new Enrollment { StudentId = 18, CourseId = 2321, Grade = "A-" },
                new Enrollment { StudentId = 18, CourseId = 2421, Grade = "B+" },
                new Enrollment { StudentId = 18, CourseId = 2331, Grade = "B-" },
                new Enrollment { StudentId = 18, CourseId = 2431, Grade = "B" },
                new Enrollment { StudentId = 18, CourseId = 3241, Grade = "C-" },
                new Enrollment { StudentId = 18, CourseId = 3521, Grade = "B+" },
                new Enrollment { StudentId = 18, CourseId = 3903, Grade = "C+" },

                new Enrollment { StudentId = 19, CourseId = 1224, Grade = "C" },
                new Enrollment { StudentId = 19, CourseId = 2221, Grade = "A" },
                new Enrollment { StudentId = 19, CourseId = 2231, Grade = "B" },
                new Enrollment { StudentId = 19, CourseId = 2321, Grade = "B-" },
                new Enrollment { StudentId = 19, CourseId = 2421, Grade = "A" },
                new Enrollment { StudentId = 19, CourseId = 2331, Grade = "B+" },
                new Enrollment { StudentId = 19, CourseId = 2431, Grade = "B+" },
                new Enrollment { StudentId = 19, CourseId = 3321, Grade = "B+" },
                new Enrollment { StudentId = 19, CourseId = 3521, Grade = "B" },
                new Enrollment { StudentId = 19, CourseId = 3901, Grade = "C-" },

                new Enrollment { StudentId = 20, CourseId = 1222, Grade = "B" },
                new Enrollment { StudentId = 20, CourseId = 2221, Grade = "A-" },
                new Enrollment { StudentId = 20, CourseId = 2231, Grade = "A" },
                new Enrollment { StudentId = 20, CourseId = 2321, Grade = "C+" },
                new Enrollment { StudentId = 20, CourseId = 2421, Grade = "B+" },
                new Enrollment { StudentId = 20, CourseId = 2331, Grade = "A-" },
                new Enrollment { StudentId = 20, CourseId = 2431, Grade = "D" },

                new Enrollment { StudentId = 21, CourseId = 1222, Grade = "A" },
                new Enrollment { StudentId = 21, CourseId = 2221, Grade = "B" },
                new Enrollment { StudentId = 21, CourseId = 2231, Grade = "A" },
                new Enrollment { StudentId = 21, CourseId = 2321, Grade = "B" },
                new Enrollment { StudentId = 21, CourseId = 2421, Grade = "A-" },
                new Enrollment { StudentId = 21, CourseId = 2331, Grade = "A" },
                new Enrollment { StudentId = 21, CourseId = 2431, Grade = "B" },
                new Enrollment { StudentId = 21, CourseId = 3341, Grade = "C+" },
                new Enrollment { StudentId = 21, CourseId = 3421, Grade = "D+" },
                new Enrollment { StudentId = 21, CourseId = 3903, Grade = "B+" },

                new Enrollment { StudentId = 22, CourseId = 1223, Grade = "B" },
                new Enrollment { StudentId = 22, CourseId = 2221, Grade = "A" },
                new Enrollment { StudentId = 22, CourseId = 2231, Grade = "B-" },
                new Enrollment { StudentId = 22, CourseId = 2321, Grade = "B-" },
                new Enrollment { StudentId = 22, CourseId = 2421, Grade = "B+" },
                new Enrollment { StudentId = 22, CourseId = 2331, Grade = "D" },

                new Enrollment { StudentId = 23, CourseId = 1224, Grade = "A" },
                new Enrollment { StudentId = 23, CourseId = 2221, Grade = "C+" },
                new Enrollment { StudentId = 23, CourseId = 2231, Grade = "A-" },
                new Enrollment { StudentId = 23, CourseId = 2321, Grade = "E" },

                new Enrollment { StudentId = 24, CourseId = 1222, Grade = "B" },
                new Enrollment { StudentId = 24, CourseId = 2221, Grade = "C" },
                new Enrollment { StudentId = 24, CourseId = 2231, Grade = "B+" },
                new Enrollment { StudentId = 24, CourseId = 2321, Grade = "A-" },
                new Enrollment { StudentId = 24, CourseId = 2421, Grade = "C-" },
                new Enrollment { StudentId = 24, CourseId = 2331, Grade = "A" },
                new Enrollment { StudentId = 24, CourseId = 2431, Grade = "B+" },
                new Enrollment { StudentId = 24, CourseId = 3241, Grade = "E" },
                new Enrollment { StudentId = 24, CourseId = 3902, Grade = "B+" },

                new Enrollment { StudentId = 25, CourseId = 1223, Grade = "B-" },
                new Enrollment { StudentId = 25, CourseId = 2221, Grade = "B" },
                new Enrollment { StudentId = 25, CourseId = 2231, Grade = "B+" },
                new Enrollment { StudentId = 25, CourseId = 2321, Grade = "A" },
                new Enrollment { StudentId = 25, CourseId = 2421, Grade = "C" },
                new Enrollment { StudentId = 25, CourseId = 2331, Grade = "B-" },
                new Enrollment { StudentId = 25, CourseId = 2431, Grade = "C-" },
                new Enrollment { StudentId = 25, CourseId = 3241, Grade = "B+" },
                new Enrollment { StudentId = 25, CourseId = 3341, Grade = "B" },
                new Enrollment { StudentId = 25, CourseId = 3521, Grade = "A" },
                new Enrollment { StudentId = 25, CourseId = 3541, Grade = "C" },
                new Enrollment { StudentId = 25, CourseId = 3901, Grade = "B-" },

                new Enrollment { StudentId = 26, CourseId = 1224, Grade = "C" },
                new Enrollment { StudentId = 26, CourseId = 2221, Grade = "B-" },
                new Enrollment { StudentId = 26, CourseId = 2231, Grade = "A" },
                new Enrollment { StudentId = 26, CourseId = 2321, Grade = "E" }
            );
        }
    }

    // ---------- Entity Classes ----------

    public class Student
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public override string ToString() {
            return $"{Id}: {FirstName} {LastName}";
        }
    }

    public class Course
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public override string ToString() {
            return $"ID: {Id}, Title: {Title}, Credits {Credits}";
        }
    }

    public class Enrollment
    {
        // Composite key: StudentId + CourseId
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public required string Grade { get; set; }

        public Student? Student { get; set; }
        public Course? Course { get; set; }

        public override string ToString() {
            return $"Student: {StudentId}, Course: {CourseId}, Grade: {Grade}";
        }
    }
}
