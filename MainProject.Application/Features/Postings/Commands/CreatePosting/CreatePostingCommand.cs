
using MediatR;
using System;

namespace MainProject.Application.Features.Postings.Commands.CreatePosting
{
    public record CreatePostingCommand : IRequest<Guid>
    {
        public string Title { get; init; }
        public string Content { get; init; }
        public int Capacity { get; init; }
        public Guid LessonId { get; init; }
        public Guid TeacherId { get; init; }
    }
}

