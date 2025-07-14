using MainProject.Domain.Common;
using MainProject.Domain.Lessons;
using MainProject.Domain.Users;
using System.Collections.Generic;

namespace MainProject.Domain.Postings;

public class Posting : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }

    // Foreign key for the Lesson
    public Guid LessonId { get; set; }
    public Lesson Lesson { get; set; }

    // Foreign key for the Teacher (User)
    public Guid TeacherId { get; set; }
    public User Teacher { get; set; }

    // Collection of students enrolled in this posting
    public ICollection<PostingEnrollment> PostingEnrollments { get; set; } = new List<PostingEnrollment>();
}
