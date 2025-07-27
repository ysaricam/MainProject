using MainProject.Domain.Common;
using MainProject.Domain.Interfaces;
using MainProject.Domain.Postings;
using System.Collections.Generic;

namespace MainProject.Domain.Users;

public class User : BaseEntity, IAggregateRoot
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    // Roles assigned to the user
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    // Postings created by the user (as a teacher)
    public ICollection<Posting> PostingsAsTeacher { get; set; } = new List<Posting>();

    // Postings the user is enrolled in (as a student)
    public ICollection<PostingEnrollment> EnrollmentsAsStudent { get; set; } = new List<PostingEnrollment>();
}
