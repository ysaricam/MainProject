using MainProject.Domain.Common;
using MainProject.Domain.Interfaces;
using MainProject.Domain.Lessons;
using MainProject.Domain.Users;
using System.Collections.Generic;
using System.Linq;

namespace MainProject.Domain.Postings;

public class Posting : BaseEntity, IAggregateRoot
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int Capacity { get; set; }

    // Foreign key for the Lesson
    public Guid LessonId { get; set; }
    public Lesson Lesson { get; set; } = null!;

    // Foreign key for the Teacher (User)
    public Guid TeacherId { get; set; }
    public User Teacher { get; set; } = null!;

    // Collection of students enrolled in this posting
    private readonly List<PostingEnrollment> _postingEnrollments = new();
    public IReadOnlyCollection<PostingEnrollment> PostingEnrollments => _postingEnrollments.AsReadOnly();

    public void EnrollStudent(User student)
    {
        if (student is null)
        {
            throw new ArgumentNullException(nameof(student));
        }

        // Business Rule: Check if the posting is full.
        if (_postingEnrollments.Count >= Capacity)
        {
            throw new InvalidOperationException("The posting is full.");
        }

        // Business Rule: A student cannot enroll in the same posting twice.
        if (_postingEnrollments.Any(e => e.StudentId == student.Id))
        {
            // Already enrolled, do nothing.
            return;
        }

        // Business Rule: The teacher of the posting cannot enroll as a student.
        if (this.TeacherId == student.Id)
        {
            throw new InvalidOperationException("Teacher cannot enroll in their own posting.");
        }

        _postingEnrollments.Add(new PostingEnrollment { PostingId = this.Id, StudentId = student.Id });
    }

    public void UnenrollStudent(Guid studentId)
    {
        var enrollment = _postingEnrollments.FirstOrDefault(e => e.StudentId == studentId);
        if (enrollment != null)
        {
            _postingEnrollments.Remove(enrollment);
        }
    }
}
