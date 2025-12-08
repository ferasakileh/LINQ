using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SchoolDataExample
{
    class Program
    {
        static float gradeToGPA(string Grade) {
            Dictionary<string, float> grades = new Dictionary<string, float>{
                {"A", 4.0f}, {"A-", 3.7f}, {"B+", 3.3f},
                {"B", 3.0f}, {"B-", 2.7f}, {"C+", 2.3f},
                {"C", 2.0f}, {"C-", 1.7f}, {"D+", 1.3f},
                {"D", 1.0f}, {"E", 0.0f}, {"S", 4.0f},
                {"U", 0.0f}
            };
            return grades[Grade];
        }

        static bool isPassing(string Grade) {
            string[] passingGrades = {"A", "A-", "B+", "B", "B-", "C+", "C", "C-", "S"};
            return passingGrades.Contains(Grade);
        }

        // ----------------------------------------------------------
        // 1. Print all students sorted by GPA (descending)
        // ----------------------------------------------------------
        static void printByGPAs(SchoolContext db) {
            var StudentGPAs = db.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                .AsEnumerable()
                .Select(s => new {
                    Student = s,
                    GPA = s.Enrollments.Any() 
                        ? s.Enrollments.Average(e => gradeToGPA(e.Grade))
                        : 0f
                })
                .OrderByDescending(x => x.GPA);

            Console.WriteLine("\n--- Students by GPA ---");
            foreach (var s in StudentGPAs)
                Console.WriteLine($"{s.Student.FirstName} {s.Student.LastName}: {s.GPA:F2}");
            Console.WriteLine();
        }

        // ----------------------------------------------------------
        // 2. Print students missing prereqs for 425X courses
        // prereqs: 2231 and 2321
        // ----------------------------------------------------------
        static void printInvalidStudents(SchoolContext db) {
            int[] prereqs = {2231, 2321};
            int[] programmingCourses = {4251, 4252, 4253, 4254, 4255};
            string[] passing = {"A","A-","B+","B","B-","C+","C","C-"};

            var invalidStudents = db.Students
                .Include(s => s.Enrollments)
                .Where(s =>
                    // Taking a 425X course
                    s.Enrollments.Any(e => programmingCourses.Contains(e.CourseId)) &&

                    // Missing one or both prerequisites
                    !prereqs.All(req =>
                        s.Enrollments.Any(e => e.CourseId == req && passing.Contains(e.Grade))
                    )
                )
                .ToList();

            Console.WriteLine("--- Invalid Students ---");
            foreach (Student s in invalidStudents) {
                var programmingEnrollments = s.Enrollments
                    .Where(e => programmingCourses.Contains(e.CourseId));

                foreach (Enrollment e in programmingEnrollments)
                    Console.WriteLine($"{s.FirstName} {s.LastName} is taking {e.CourseId} without prereqs");
            }
            Console.WriteLine();
        }

        // ----------------------------------------------------------
        // 3. Print students on probation (GPA < 2.0)
        // ----------------------------------------------------------
        static void printStudentsOnProbabtion(SchoolContext db) {
            var StudentGPAs = db.Students
                .Include(s => s.Enrollments)
                .AsEnumerable()
                .Select(s => new {
                    Student = s,
                    GPA = s.Enrollments.Any()
                        ? s.Enrollments.Average(e => gradeToGPA(e.Grade))
                        : 0f
                })
                .Where(x => x.GPA < 2.0)
                .OrderBy(x => x.GPA);

            Console.WriteLine("--- Students on Probation (GPA < 2.0) ---");
            foreach (var s in StudentGPAs)
                Console.WriteLine($"{s.Student.FirstName} {s.Student.LastName}: {s.GPA:F2}");
            Console.WriteLine();
        }

        // ----------------------------------------------------------
        // 4. Print top 5 students by GPA
        // ----------------------------------------------------------
        static void printBestStudents(SchoolContext db) {
            var StudentGPAs = db.Students
                .Include(s => s.Enrollments)
                .AsEnumerable()
                .Select(s => new {
                    Student = s,
                    GPA = s.Enrollments.Any()
                        ? s.Enrollments.Average(e => gradeToGPA(e.Grade))
                        : 0f
                })
                .OrderByDescending(x => x.GPA)
                .Take(5);

            Console.WriteLine("--- Top 5 Students ---");
            foreach (var s in StudentGPAs)
                Console.WriteLine($"{s.Student.FirstName} {s.Student.LastName}: {s.GPA:F2}");
            Console.WriteLine();
        }

        // ----------------------------------------------------------
        // 5. Print 5 most popular courses (ranked by enrollment count)
        // ----------------------------------------------------------
        static void printMostPopularCourses(SchoolContext db) {
            var courses = db.Courses
                .Include(c => c.Enrollments)
                .Select(c => new {
                    Course = c,
                    StudentCount = c.Enrollments.Count
                })
                .OrderByDescending(x => x.StudentCount)
                .Take(5);

            Console.WriteLine("--- Most Popular Courses ---");
            foreach (var c in courses)
                Console.WriteLine($"{c.Course.Id} {c.Course.Title}: {c.StudentCount} students");
            Console.WriteLine();
        }

        // ----------------------------------------------------------
        static void Main(string[] args)
        {
            using var db = new SchoolContext();

            db.Database.EnsureCreated();

            printInvalidStudents(db);
            printByGPAs(db);
            printStudentsOnProbabtion(db);
            printBestStudents(db);
            printMostPopularCourses(db);
        }
    }
}
