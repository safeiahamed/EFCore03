using Microsoft.EntityFrameworkCore;

namespace EFAssignment03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbcontext();

            #region Part2
            //if (!context.Students.Any())
            //{
            //    var students = new List<Student>
            //    {
            //        new Student { FullName = "Fatma Ali", Email = "fatma@gmail.com", DateOfBirth = new DateTime(2006, 3, 5) },
            //        new Student { FullName = "Menna Gamil", Email = "menna@gmail.com", DateOfBirth = new DateTime(2000, 7, 18) },
            //        new Student { FullName = "Nour Ibrahim", Email = "nour@gmail.com", DateOfBirth = new DateTime(2002, 1, 9) },
            //        new Student { FullName = "Khaled Saeed", Email = "khaled@gmail.com", DateOfBirth = new DateTime(1999, 1, 1) },
            //        new Student { FullName = "Sara Ahmed", Email = "sara@gmail.com", DateOfBirth = new DateTime(2006, 3, 5) }

            //    };

            //    context.Students.AddRange(students);
            //    context.SaveChanges();

            //    var enrollments = new List<Enrollment>
            //    {
            //        new Enrollment { StudentId = students[0].Id, CourseId = 1, EnrolledDate = new DateTime(2024, 1, 5),  Progress = 40,  Status = EnrollmentStatus.Active },
            //        new Enrollment { StudentId = students[0].Id, CourseId = 2, EnrolledDate = new DateTime(2024, 2, 10), Progress = 15,  Status = EnrollmentStatus.Active },
            //        new Enrollment { StudentId = students[1].Id, CourseId = 4, EnrolledDate = new DateTime(2024, 1, 20), Progress = 70,  Status = EnrollmentStatus.Active },
            //        new Enrollment { StudentId = students[1].Id, CourseId = 1, EnrolledDate = new DateTime(2023, 9, 1),  Progress = 100, Status = EnrollmentStatus.Completed, FinalGrade = 92.5m },
            //        new Enrollment { StudentId = students[2].Id, CourseId = 6, EnrolledDate = new DateTime(2023, 10, 3), Progress = 100, Status = EnrollmentStatus.Completed, FinalGrade = 85m },
            //        new Enrollment { StudentId = students[3].Id, CourseId = 2, EnrolledDate = new DateTime(2023, 11, 15), Progress = 100, Status = EnrollmentStatus.Completed, FinalGrade = 78.75m },
            //        new Enrollment { StudentId = students[2].Id, CourseId = 4, EnrolledDate = new DateTime(2024, 2, 1),  Progress = 20,  Status = EnrollmentStatus.Dropped },
            //        new Enrollment { StudentId = students[4].Id, CourseId = 6, EnrolledDate = new DateTime(2024, 3, 8),  Progress = 5,   Status = EnrollmentStatus.Dropped }

            //    };
            //    context.Enrollments.AddRange(enrollments);
            //    context.SaveChanges();


            //}
            #endregion


            #region Part3
            //AddInstructor();

            //AddCourse();

            //AddSeveralStudents();

            //EnrollStudent();

            //FindCourse();

            //FilterCourses();

            //PrintSubCategories();

            //PrintCourseRoster();

            //ChangeCoursePrice();

            //UpdateProgress();

            //PublishCourse();

            //UnenrollStudent();

            //DeleteCategory();

            //DeleteCourse();

            //BulkPriceRaise();

            BulkDelete();
            #endregion
        }

        #region AddInstructor
        static void AddInstructor()
        {
            using var context = new AppDbcontext();
            Instructor instructor = new Instructor
            {
                FullName = "Safeia Khaled",
                Email = "safeia123@gmail.com",
                Bio = "Backend Developer",
                JoinDate = DateTime.Now
            };
            context.Instructors.Add(instructor);
            context.SaveChanges();
            Console.WriteLine($"Instructor ID: {instructor.Id}");
        }
        #endregion

        #region AddCourse
        static void AddCourse()
        {
            using var context = new AppDbcontext();

            int instructorId = 1;
            int categoryId = 4;

            bool instructorExists = context.Instructors
                .Any(i => i.Id == instructorId);

            if (!instructorExists)
            {
                Console.WriteLine("Instructor not found");
                return;
            }

            bool categoryExists = context.Categories
                .Any(c => c.Id == categoryId);

            if (!categoryExists)
            {
                Console.WriteLine("Category not found!");
                return;
            }

            Course course = new Course
            {
                Title = "Java Script",
                Description = "Learn JS",
                Price = 599.99m,
                Level = CourseLevel.Intermediate,
                IsPublished = false,
                PublishedAt = null,
                InstructorId = instructorId,
                CategoryId = categoryId
            };

            context.Courses.Add(course);
            context.SaveChanges();
            Console.WriteLine($"Course ID: {course.Id}");
        }
        #endregion

        #region AddSeveralStudents
        static void AddSeveralStudents()
        {
            using var context = new AppDbcontext();
            Student std1 = new Student
            {
                FullName = "Ahmed Ali",
                Email = "ahmed@gmail.com",
                DateOfBirth = new DateTime(2002, 5, 10)
            };

            Student std2 = new Student
            {
                FullName = "Mona Mohamed",
                Email = "mona@gmail.com",
                DateOfBirth = new DateTime(2003, 8, 15)
            };

            Student std3 = new Student
            {
                FullName = "Omar Hassan",
                Email = "omar@gmail.com",
                DateOfBirth = new DateTime(2001, 12, 20)
            };
            context.Students.AddRange(std1, std2, std3);
            context.SaveChanges();

            Console.WriteLine($"Student 1 ID: {std1.Id}");
            Console.WriteLine($"Student 2 ID: {std2.Id}");
            Console.WriteLine($"Student 3 ID: {std3.Id}");
        }
        #endregion

        #region EnrollStudent
        static void EnrollStudent()
        {
            using var context = new AppDbcontext();
            int studentId = 5;
            int courseId = 1;
            bool studentExists = context.Students
                .Any(s => s.Id == studentId);

            if (!studentExists)
            {
                Console.WriteLine("Student not found!");
                return;
            }

            Course? course = context.Courses
                .FirstOrDefault(c => c.Id == courseId);
            if (course == null)
            {
                Console.WriteLine("Course not found!");
                return;
            }
            if (!course.IsPublished)
            {
                Console.WriteLine("Cannot enroll: Course is not published!");
                return;
            }
            bool alreadyEnrolled = context.Enrollments
                .Any(e => e.StudentId == studentId &&
                          e.CourseId == courseId);
            if (alreadyEnrolled)
            {
                Console.WriteLine("Student is already enrolled in this course!");
                return;
            }
            Enrollment enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrolledDate = DateTime.Now,
                Progress = 0,
                Status = EnrollmentStatus.Active,
                FinalGrade = null
            };

            context.Enrollments.Add(enrollment);
            context.SaveChanges();

        }
        #endregion

        #region FindCourse
        static void FindCourse()
        {
            using var context = new AppDbcontext();
            int courseId = 1;
            Course? courseById = context.Courses.Find(courseId);

            if (courseById == null)
            {
                Console.WriteLine("Course not found by ID!");
            }
            else
            {
                Console.WriteLine("Course found by ID");
                Console.WriteLine($"ID: {courseById.Id}");
                Console.WriteLine($"Title: {courseById.Title}");
                Console.WriteLine($"Price: {courseById.Price}");
            }
            string title = "C# Fundamentals";
            Course? courseByTitle = context.Courses
                .FirstOrDefault(c => c.Title == title);

            if (courseByTitle == null)
            {
                Console.WriteLine("Course not found by Title!");
            }
            else
            {
                Console.WriteLine("Course found by Title");
                Console.WriteLine($"ID: {courseByTitle.Id}");
                Console.WriteLine($"Title: {courseByTitle.Title}");
                Console.WriteLine($"Price: {courseByTitle.Price}");
            }
        }
        #endregion

        #region FilterCourses
        static void FilterCourses()
        {
            using var context = new AppDbcontext();

            decimal minPrice = 300;
            decimal maxPrice = 1000;

            var courses = context.Courses
                .Where(c => c.Price >= minPrice && c.Price <= maxPrice)
                .OrderByDescending(c => c.Price)
                .Select(c => new{c.Title,c.Level,c.Price}).ToList();

            if (courses.Count == 0)
            {
                Console.WriteLine("No courses found in this price range!");
                return;
            }
            foreach (var course in courses)
            {
                Console.WriteLine($"Title: {course.Title}");
                Console.WriteLine($"Level: {course.Level}");
                Console.WriteLine($"Price: {course.Price}");
            }
        }
        #endregion

        #region PrintSubCategories
        static void PrintSubCategories()
        {
            using var context = new AppDbcontext();

            int categoryId = 1;

            var subCategories = context.Categories
                .Where(c => c.PCategoryId == categoryId)
                .ToList();

            if (subCategories.Count == 0)
            {
                Console.WriteLine("No sub categories found!");
                return;
            }
            Console.WriteLine("Sub categories:");
            foreach (var category in subCategories)
            {
                Console.WriteLine(category.Name);
            }
        }
        #endregion

        #region PrintCourseRoster
        static void PrintCourseRoster()
        {
            using var context = new AppDbcontext();

            int courseId = 1;
            var studentIds = context.Enrollments
                .Where(e => e.CourseId == courseId)
                .Select(e => e.StudentId)
                .ToList();
            Console.WriteLine($"Number of Students: {studentIds.Count}");

            if (studentIds.Count == 0)
            {
                Console.WriteLine("No students enrolled in this course!");
                return;
            }
            var students = context.Students
                .Where(s => studentIds.Contains(s.Id))
                .ToList();

            Console.WriteLine("Students:");
            foreach (var student in students)
            {
                Console.WriteLine(student.FullName);
            }
        }
        #endregion

        #region ChangeCoursePrice
        static void ChangeCoursePrice()
        {
            using var context = new AppDbcontext();
            int courseId = 1;
            Course? course = context.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found!");
                return;
            }
            course.Price = 750m;
            context.SaveChanges();
            Console.WriteLine($"New Price: {course.Price}");
        }
        #endregion

        #region UpdateProgress
        static void UpdateProgress()
        {
            using var context = new AppDbcontext();
            int studentId = 1;
            int courseId = 1;
            int newProgress = 100;
            if (newProgress < 0 || newProgress > 100)
            {
                Console.WriteLine("Progress must be between 0 and 100!");
                return;
            }
            Enrollment? enrollment = context.Enrollments
                .Find(studentId, courseId);

            if (enrollment == null)
            {
                Console.WriteLine("Enrollment not found!");
                return;
            }
            enrollment.Progress = 100;
            if (newProgress == 100)
            {
                enrollment.Status = EnrollmentStatus.Completed;
            }
            context.SaveChanges();
            Console.WriteLine($"Progress: {enrollment.Progress}%");
            Console.WriteLine($"Status: {enrollment.Status}");
        }
        #endregion

        #region PublishCourse
        static void PublishCourse()
        {
            using var context = new AppDbcontext();
            int courseId = 1;
            Course? course = context.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found!");
                return;
            }
            course.IsPublished = true;
            course.PublishedAt = DateTime.Now;
            context.SaveChanges();
            Console.WriteLine($"Title: {course.Title}");
            Console.WriteLine($"Published: {course.IsPublished}");
            Console.WriteLine($"Published At: {course.PublishedAt}");
        }
        #endregion

        #region UnenrollStudent
        static void UnenrollStudent()
        {
            using var context = new AppDbcontext();
            int studentId = 1;
            int courseId = 1;
            Enrollment? enrollment = context.Enrollments
                .Find(studentId, courseId);
            if (enrollment == null)
            {
                Console.WriteLine("Enrollment not found!");
                return;
            }
            context.Enrollments.Remove(enrollment);
            context.SaveChanges();
        }
        #endregion

        #region DeleteCategory
        static void DeleteCategory()
        {
            using var context = new AppDbcontext();
            int categoryId = 1;
            Category? category = context.Categories.Find(categoryId);
            if (category == null)
            {
                Console.WriteLine("Category not found!");
                return;
            }
            try
            {
                context.Categories.Remove(category);
                context.SaveChanges();
                Console.WriteLine("Category deleted successfully!");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Cannot delete this category!");
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
            }
        }
        #endregion

        #region DeleteCourse
        static void DeleteCourse()
        {
            using var context = new AppDbcontext();
            int courseId = 1;
            Course? course = context.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found!");
                return;
            }
            int beforeCount = context.Enrollments
                .Count(e => e.CourseId == courseId);

            Console.WriteLine($"Enrollments before deletion: {beforeCount}");
            context.Courses.Remove(course);
            context.SaveChanges();
            int afterCount = context.Enrollments
                .Count(e => e.CourseId == courseId);
            Console.WriteLine($"Enrollments after deletion: {afterCount}");
            Console.WriteLine("Course deleted successfully!");
        }
        #endregion

        #region BulkPriceRaise
        static void BulkPriceRaise()
        {
            using var context = new AppDbcontext();
            CourseLevel level = CourseLevel.Beginner;
            int affectedRows = context.Courses
                .Where(c => c.IsPublished && c.Level == level)
                .ExecuteUpdate(s => s
                    .SetProperty(c => c.Price, c => c.Price * 1.10m));
            Console.WriteLine($"Number of affected courses: {affectedRows}");
        }
        #endregion

        #region BulkDelete
        static void BulkDelete()
        {
            using var context = new AppDbcontext();
            int affectedRows = context.Enrollments
                .Where(e => e.Status == EnrollmentStatus.Dropped)
                .ExecuteDelete();
            Console.WriteLine($"Number of deleted enrollments: {affectedRows}");
        }
        #endregion
    }
}
