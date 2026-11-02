using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssignment03
{
    public class CategoryConfig :IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(c => c.Description).HasMaxLength(200);
            builder.HasOne(c => c.PCategory)
                   .WithMany(c => c.SubCategories)
                   .HasForeignKey(c => c.PCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Courses)
                   .WithOne(c => c.Category)
                   .HasForeignKey(c => c.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
                            new Category { Id = 1, Name = "Programming", Description = "Programming Courses", PCategoryId = null },
                            new Category { Id = 2, Name = "Backend", Description = "Server-side development", PCategoryId = 1 },
                            new Category { Id = 3, Name = "Frontend", Description = null, PCategoryId = 1 },
                            new Category { Id = 4, Name = "ASP.NET", Description = "ASP.NET Core framework", PCategoryId = 2 },
                            new Category { Id = 5, Name = "React", Description = "React library", PCategoryId = 3 });
        }
    }
}
