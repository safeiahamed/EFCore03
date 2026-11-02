using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssignment03
{
    public class Enrollment
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; } 

        public DateTime EnrolledDate { get; set; }

        public decimal Progress { get; set; }  

        public EnrollmentStatus Status { get; set; }

        public decimal? FinalGrade { get; set; }   
    }
}
