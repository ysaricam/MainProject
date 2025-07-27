
using MediatR;
using System;

namespace MainProject.Application.Features.Lessons.Commands.CreateLesson
{
    public class CreateLessonCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid BranchId { get; set; }
    }
}
