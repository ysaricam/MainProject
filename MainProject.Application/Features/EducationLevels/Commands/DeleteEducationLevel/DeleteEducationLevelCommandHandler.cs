using MainProject.Domain.Lessons;
using MainProject.Domain.Interfaces;
using MediatR;

namespace MainProject.Application.Features.EducationLevels.Commands.DeleteEducationLevel
{
    public class DeleteEducationLevelCommandHandler : IRequestHandler<DeleteEducationLevelCommand, bool>
    {
        private readonly IRepository<EducationLevel> _educationLevelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEducationLevelCommandHandler(IRepository<EducationLevel> educationLevelRepository, IUnitOfWork unitOfWork)
        {
            _educationLevelRepository = educationLevelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteEducationLevelCommand request, CancellationToken cancellationToken)
        {
            var educationLevel = await _educationLevelRepository.GetByIdAsync(request.Id, cancellationToken);
            if (educationLevel == null)
                return false;

            _educationLevelRepository.Remove(educationLevel);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
