using MediatR;

namespace MainProject.Application.Features.Lessons.Commands.DeleteLesson
{
    public record DeleteLessonCommand(Guid Id) : IRequest<bool>;
}
