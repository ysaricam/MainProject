using MediatR;
using System;

namespace MainProject.Application.Features.Roles.Commands.CreateRole
{
    public record CreateRoleCommand : IRequest<Guid>
    {
        public string Name { get; init; }
    }
}

