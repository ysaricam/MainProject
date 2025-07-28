using MainProject.Application.Features.Roles.Dtos;
using MediatR;

namespace MainProject.Application.Features.Roles.Queries.GetAllRoles
{
    public record GetAllRolesQuery : IRequest<List<RoleDto>>;
}
