using MediatR;

namespace MainProject.Application.Features.Postings.Commands.UpdatePosting
{
    public record UpdatePostingCommand : IRequest<bool>
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Content { get; init; }
        public Guid LessonId { get; init; }
    }
}
