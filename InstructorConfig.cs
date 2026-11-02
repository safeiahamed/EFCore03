using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssignment03
{
    public class InstructorConfig : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(P => P.FullName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.Email)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.Bio).HasMaxLength(200);   
            builder.Property(p => p.JoinDate).IsRequired();
            builder.HasIndex(p => p.Email).IsUnique();

            builder.HasMany(i => i.Courses)
                   .WithOne(c => c.Instructor)
                   .HasForeignKey(c => c.InstructorId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
                            new Instructor { Id = 1, FullName = "Safeia Hamed", Email = "safeia@gmail.com", Bio = "Backend .Net Developer", JoinDate = new DateTime(2026, 11, 01) },
                            new Instructor { Id = 2, FullName = "Khaled Ahmed", Email = "khaled@gmail.com", Bio = "FrontEnd Developer", JoinDate = new DateTime(2026, 11, 01) },
                            new Instructor { Id = 3, FullName = "Mai Omar", Email = "mai@gmail.com", Bio = "Backend .Net Developer", JoinDate = new DateTime(2026, 11, 01) });
        }
    }
}
