using MainProject.Application.Features.Lessons.Dtos;
using MediatR;

namespace MainProject.Application.Features.Lessons.Queries.GetAllLessons
{
    public record GetAllLessonsQuery : IRequest<List<LessonDto>>;
}
