
using MediatR;
using System;

namespace MainProject.Application.Features.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
