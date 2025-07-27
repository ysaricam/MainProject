
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


        public CreateLessonCommandHandler(IRepository<Lesson> lessonRepository, IUnitOfWork unitOfWork)
        {
            _lessonRepository = lessonRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = new Lesson
            {
                Name = request.Name,
                Description = request.Description,
                BranchId = request.BranchId
            };

            _lessonRepository.Add(lesson);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return lesson.Id;
        }
    }
}
