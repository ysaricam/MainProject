using MainProject.Domain.Lessons;
using MainProject.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.Application.Features.Lessons.Commands.AddEducationLevel;

public class AddEducationLevelToLessonCommandHandler : IRequestHandler<AddEducationLevelToLessonCommand, bool>
{
    private readonly IRepository<Lesson> _lessonRepository;
    private readonly IRepository<EducationLevel> _educationLevelRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddEducationLevelToLessonCommandHandler(IRepository<Lesson> lessonRepository, IRepository<EducationLevel> educationLevelRepository, IUnitOfWork unitOfWork)
    {
        _lessonRepository = lessonRepository;
        _educationLevelRepository = educationLevelRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(AddEducationLevelToLessonCommand request, CancellationToken cancellationToken)
    {
        var lesson = await _lessonRepository.GetByIdAsync(request.LessonId);
        if (lesson == null)
        {
            return false; // Lesson not found
        }

        var educationLevel = await _educationLevelRepository.GetByIdAsync(request.EducationLevelId);
        if (educationLevel == null)
        {
            return false; // EducationLevel not found
        }

        lesson.AddEducationLevel(educationLevel);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
