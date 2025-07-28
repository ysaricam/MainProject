namespace MainProject.Application.Features.Postings.Dtos
{
    public record PostingDto
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Content { get; init; }
        public Guid LessonId { get; init; }
        public Guid TeacherId { get; init; }
    }
}
