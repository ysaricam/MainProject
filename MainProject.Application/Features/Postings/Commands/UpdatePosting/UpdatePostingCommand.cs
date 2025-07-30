using MediatR;
using System;

namespace MainProject.Application.Features.Postings.Commands.UpdatePosting
{
    public record UpdatePostingCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Title { get; init; }
        public string Content { get; init; }
        public Guid LessonId { get; init; }
    }
}
