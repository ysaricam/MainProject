using MediatR;

namespace MainProject.Application.Features.EducationLevels.Commands.UpdateEducationLevel
{
    public record UpdateEducationLevelCommand : IRequest<bool>
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
    }
}
