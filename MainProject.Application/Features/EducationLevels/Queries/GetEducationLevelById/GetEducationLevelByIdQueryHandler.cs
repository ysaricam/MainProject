

using AutoMapper;
using MainProject.Application.Features.EducationLevels.Dtos;
using MainProject.Domain.Lessons;
using MainProject.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.Application.Features.EducationLevels.Queries.GetEducationLevelById
{
    public class GetEducationLevelByIdQueryHandler : IRequestHandler<GetEducationLevelByIdQuery, EducationLevelDto>
    {
        private readonly IRepository<EducationLevel> _educationLevelRepository;
        private readonly IMapper _mapper;

        public GetEducationLevelByIdQueryHandler(IRepository<EducationLevel> educationLevelRepository, IMapper mapper)
        {
            _educationLevelRepository = educationLevelRepository;
            _mapper = mapper;
        }

        public async Task<EducationLevelDto> Handle(GetEducationLevelByIdQuery request, CancellationToken cancellationToken)
        {
            var educationLevel = await _educationLevelRepository.GetByIdAsync(request.Id, cancellationToken);

            if (educationLevel == null)
            {
                return null;
            }

            return _mapper.Map<EducationLevelDto>(educationLevel);
        }
    }
}

