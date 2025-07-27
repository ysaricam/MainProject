
using MainProject.Domain.Lessons;
using MainProject.Domain.Postings;
using MainProject.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace MainProject.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<EducationLevel> EducationLevels { get; set; }
    public DbSet<LessonEducationLevel> LessonEducationLevels { get; set; }
    public DbSet<Posting> Postings { get; set; }
    public DbSet<PostingEnrollment> PostingEnrollments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
        modelBuilder.Entity<LessonEducationLevel>().HasKey(lel => new { lel.LessonId, lel.EducationLevelId });

        modelBuilder.Entity<User>()
            .HasMany(u => u.PostingsAsTeacher)
            .WithOne(p => p.Teacher)
            .HasForeignKey(p => p.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.EnrollmentsAsStudent)
            .WithOne(pe => pe.Student)
            .HasForeignKey(pe => pe.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PostingEnrollment>().HasKey(pe => new { pe.PostingId, pe.StudentId });
    }
}
