using MainProject.Domain.Users;

namespace MainProject.Domain.Postings;

public class PostingEnrollment
{
    public Guid PostingId { get; set; }
    public Posting Posting { get; set; } = null!;

    public Guid StudentId { get; set; }
    public User Student { get; set; } = null!;
}
