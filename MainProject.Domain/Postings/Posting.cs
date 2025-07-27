using MainProject.Domain.Common;
using MainProject.Domain.Interfaces;
using MainProject.Domain.Lessons;
using MainProject.Domain.Users;
using System.Collections.Generic;

namespace MainProject.Domain.Postings;

public class Posting : BaseEntity, IAggregateRoot
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    // Foreign key for the Lesson
    public Guid LessonId { get; set; }
    public Lesson Lesson { get; set; } = null!;

    // Foreign key for the Teacher (User)
    public Guid TeacherId { get; set; }
    public User Teacher { get; set; } = null!;

    // Collection of students enrolled in this posting
    public ICollection<PostingEnrollment> PostingEnrollments { get; set; } = new List<PostingEnrollment>();
}
