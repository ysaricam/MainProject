
using AutoMapper;
using MainProject.Domain.Lessons;
using MainProject.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.Application.Features.Lessons.Commands.CreateLesson
{
    public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, Guid>
    {
        private readonly IRepository<Lesson> _lessonRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CreateLessonCommandHandler(IRepository<Lesson> lessonRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = _mapper.Map<Lesson>(request);

            _lessonRepository.Add(lesson);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return lesson.Id;
        }
    }
}
