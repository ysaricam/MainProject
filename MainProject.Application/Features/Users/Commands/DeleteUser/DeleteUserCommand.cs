using MediatR;
using System;

namespace MainProject.Application.Features.Users.Commands.DeleteUser
{
    public record DeleteUserCommand(Guid Id) : IRequest;
}