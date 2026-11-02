using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssignment03
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }  

        public decimal Price { get; set; }

        public CourseLevel Level { get; set; }

        public bool IsPublished { get; set; }

        public DateTime? PublishedAt { get; set; }  

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();   

    }
}
