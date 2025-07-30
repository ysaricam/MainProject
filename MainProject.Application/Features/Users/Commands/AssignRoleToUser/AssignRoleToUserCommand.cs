using MediatR;
using System;

namespace MainProject.Application.Features.Users.Commands.AssignRoleToUser;

public class AssignRoleToUserCommand : IRequest<bool>
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
}