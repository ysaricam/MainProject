using MediatR;

namespace MainProject.Application.Features.EducationLevels.Commands.DeleteEducationLevel
{
    public record DeleteEducationLevelCommand(Guid Id) : IRequest<bool>;
}
