
using MediatR;
using System;

namespace MainProject.Application.Features.Postings.Commands.CreatePosting
{
    public class CreatePostingCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid LessonId { get; set; }
        public Guid TeacherId { get; set; }
    }
}
