
using MediatR;
using System;

namespace MainProject.Application.Features.Lessons.Queries.GetLessonById
{
    public class GetLessonByIdQuery : IRequest<LessonDto>
    {
        public Guid Id { get; set; }
    }
}
