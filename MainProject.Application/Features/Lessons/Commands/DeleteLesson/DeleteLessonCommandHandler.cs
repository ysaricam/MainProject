using MainProject.Domain.Lessons;
using MainProject.Domain.Interfaces;
using MediatR;

namespace MainProject.Application.Features.Lessons.Commands.DeleteLesson
{
    public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommand, bool>
    {
        private readonly IRepository<Lesson> _lessonRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLessonCommandHandler(IRepository<Lesson> lessonRepository, IUnitOfWork unitOfWork)
        {
            _lessonRepository = lessonRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = await _lessonRepository.GetByIdAsync(request.Id, cancellationToken);
            if (lesson == null)
                return false;

            _lessonRepository.Remove(lesson);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
