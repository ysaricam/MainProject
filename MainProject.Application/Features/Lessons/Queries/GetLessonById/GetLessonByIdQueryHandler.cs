

using AutoMapper;
using MainProject.Application.Features.Lessons.Dtos;
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
        private readonly IMapper _mapper;

        public GetLessonByIdQueryHandler(IRepository<Lesson> lessonRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public async Task<LessonDto> Handle(GetLessonByIdQuery request, CancellationToken cancellationToken)
        {
            var lesson = await _lessonRepository.GetByIdAsync(request.Id, cancellationToken);

            if (lesson == null)
            {
                return null;
            }

            return _mapper.Map<LessonDto>(lesson);
        }
    }
}

