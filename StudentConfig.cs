using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssignment03
{
    public class StudentConfig:IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FullName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.Email)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.DateOfBirth).IsRequired();
            builder.HasIndex(p => p.Email).IsUnique();

            builder.HasMany(s=> s.Enrollments)
                   .WithOne(e => e.Student)
                   .HasForeignKey(e => e.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
