using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssignment03
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }   
        public int? PCategoryId { get; set; }
        public Category? PCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; } = new HashSet<Category>();

        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}
