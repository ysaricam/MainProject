
using MainProject.Domain.Lessons;
using MainProject.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.Application.Features.EducationLevels.Commands.CreateEducationLevel
{
    public class CreateEducationLevelCommandHandler : IRequestHandler<CreateEducationLevelCommand, Guid>
    {
        private readonly IRepository<EducationLevel> _educationLevelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateEducationLevelCommandHandler(IRepository<EducationLevel> educationLevelRepository, IUnitOfWork unitOfWork)
        {
            _educationLevelRepository = educationLevelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateEducationLevelCommand request, CancellationToken cancellationToken)
        {
            var educationLevel = new EducationLevel
            {
                Name = request.Name,
                Description = request.Description
            };

            _educationLevelRepository.Add(educationLevel);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return educationLevel.Id;
        }
    }
}
