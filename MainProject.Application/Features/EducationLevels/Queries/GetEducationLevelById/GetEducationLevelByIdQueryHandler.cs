
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

        public GetEducationLevelByIdQueryHandler(IRepository<EducationLevel> educationLevelRepository)
        {
            _educationLevelRepository = educationLevelRepository;
        }

        public async Task<EducationLevelDto> Handle(GetEducationLevelByIdQuery request, CancellationToken cancellationToken)
        {
            var educationLevel = await _educationLevelRepository.GetByIdAsync(request.Id, cancellationToken);

            if (educationLevel == null)
            {
                return null;
            }

            return new EducationLevelDto
            {
                Id = educationLevel.Id,
                Name = educationLevel.Name,
                Description = educationLevel.Description
            };
        }
    }

    public class EducationLevelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
