
using MainProject.Application.Features.Roles.Dtos;
using MediatR;
using System;

namespace MainProject.Application.Features.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQuery : IRequest<RoleDto>
    {
        public Guid Id { get; set; }
    }
}
