
using MainProject.Domain.Lessons;
using MainProject.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.Application.Features.Lessons.Queries.GetLessonById
{
    public class GetLessonByIdQueryHandler : IRequestHandler<GetLessonByIdQuery, LessonDto>
    {
        private readonly IRepository<Lesson> _lessonRepository;

        public GetLessonByIdQueryHandler(IRepository<Lesson> lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<LessonDto> Handle(GetLessonByIdQuery request, CancellationToken cancellationToken)
        {
            var lesson = await _lessonRepository.GetByIdAsync(request.Id, cancellationToken);

            if (lesson == null)
            {
                return null;
            }

            return new LessonDto
            {
                Id = lesson.Id,
                Name = lesson.Name,
                Description = lesson.Description,
                BranchId = lesson.BranchId
            };
        }
    }

    public class LessonDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid BranchId { get; set; }
    }
}
