using MediatR;

namespace MainProject.Application.Features.Lessons.Commands.UpdateLesson
{
    public record UpdateLessonCommand : IRequest<bool>
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public Guid BranchId { get; init; }
    }
}
