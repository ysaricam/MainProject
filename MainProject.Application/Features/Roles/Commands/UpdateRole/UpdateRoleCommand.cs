using MediatR;
using System;

namespace MainProject.Application.Features.Roles.Commands.UpdateRole
{
    public record UpdateRoleCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; init; }
    }
}
