using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssignment03
{
    public class CourseConfig:IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(c => c.Description)
                .HasMaxLength(1000);
            builder.Property(c => c.Price).HasPrecision(18, 2);
            builder.Property(c => c.Level).IsRequired();
            builder.Property(c => c.IsPublished).IsRequired();
            builder.Property(c => c.PublishedAt);   

            builder.HasMany(c => c.Enrollments)
                   .WithOne(e => e.Course)
                   .HasForeignKey(e => e.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
                            new Course { Id = 1, Title = "C# Fundamentals", Description = "Learn C# from scratch", Price = 499.99m, Level = CourseLevel.Beginner, IsPublished = true, PublishedAt = new DateTime(2026, 11, 01), CategoryId = 1, InstructorId = 1 },
                            new Course { Id = 2, Title = "ASP.NET Core Web API", Description = "Build REST APIs", Price = 999.99m, Level = CourseLevel.Intermediate, IsPublished = true, PublishedAt = new DateTime(2026, 11, 01), CategoryId = 4, InstructorId = 1 },
                            new Course { Id = 3, Title = "Advanced EF Core", Description = null, Price = 129.99m, Level = CourseLevel.Advanced, IsPublished = false, PublishedAt = new DateTime(2026, 11, 01), CategoryId = 2, InstructorId = 2 },
                            new Course { Id = 4, Title = "React for Beginners", Description = "Components and hooks", Price = 59.99m, Level = CourseLevel.Beginner, IsPublished = true, PublishedAt = new DateTime(2026, 11, 01), CategoryId = 5, InstructorId = 2 },
                            new Course { Id = 5, Title = "Modern Frontend Architecture", Description = "Scalable UI design", Price = 149.99m, Level = CourseLevel.Advanced, IsPublished = false, PublishedAt = null, CategoryId = 3, InstructorId = 3 },
                            new Course { Id = 6, Title = "Backend Design Patterns", Description = "Clean architecture", Price = 89.99m, Level = CourseLevel.Intermediate, IsPublished = true, PublishedAt = new DateTime(2026, 11, 01), CategoryId = 2, InstructorId = 3 });
        }
    }
}
