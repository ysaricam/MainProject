using MediatR;
using System;

namespace MainProject.Application.Features.Lessons.Commands.AddEducationLevel;

public class AddEducationLevelToLessonCommand : IRequest<bool>
{
    public Guid LessonId { get; set; }
    public Guid EducationLevelId { get; set; }
}