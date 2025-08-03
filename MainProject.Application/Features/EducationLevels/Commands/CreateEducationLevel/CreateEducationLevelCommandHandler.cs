
using AutoMapper;
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
        private readonly IMapper _mapper;

        public CreateEducationLevelCommandHandler(IRepository<EducationLevel> educationLevelRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _educationLevelRepository = educationLevelRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateEducationLevelCommand request, CancellationToken cancellationToken)
        {
            var educationLevel = _mapper.Map<EducationLevel>(request);

            _educationLevelRepository.Add(educationLevel);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return educationLevel.Id;
        }
    }
}
