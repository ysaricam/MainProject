using MainProject.Application.Features.EducationLevels.Dtos;
using MediatR;

namespace MainProject.Application.Features.EducationLevels.Queries.GetAllEducationLevels
{
    public record GetAllEducationLevelsQuery : IRequest<List<EducationLevelDto>>;
}
