using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssignment03
{
    public class EnrollmentConfig:IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => new { e.StudentId, e.CourseId });

            builder.Property(e => e.EnrolledDate).IsRequired();
            builder.Property(e => e.Progress).HasPrecision(8, 2);
            builder.Property(e => e.Status).IsRequired();
            builder.Property(e => e.FinalGrade).HasPrecision(8, 2);   

            builder.ToTable(t => t.HasCheckConstraint(
                "CheckEnrollmentProgress", "[Progress] >= 0 AND [Progress] <= 100"));
        }
    }
}
