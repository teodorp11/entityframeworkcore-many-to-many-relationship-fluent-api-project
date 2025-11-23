using entityframeworkcore_many_to_many_relationship_project.Models;
using Microsoft.EntityFrameworkCore;

namespace entityframeworkcore_many_to_many_relationship_project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentSubject>(entity =>
            { 
                entity.HasKey(ss => new { ss.StudentID, ss.SubjectID }); // composite key

                entity.HasOne(s => s.Student)
                    .WithMany(s => s.StudentSubjects)
                    .HasForeignKey(ss => ss.StudentID)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(s => s.Subject)
                    .WithMany(s => s.StudentSubjects)
                    .HasForeignKey(ss => ss.SubjectID)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}