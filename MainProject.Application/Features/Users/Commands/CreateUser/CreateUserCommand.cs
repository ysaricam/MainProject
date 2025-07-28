using MediatR;
using System;

namespace MainProject.Application.Features.Users.Commands.CreateUser
{
    public record CreateUserCommand : IRequest<Guid>
    {
        public string Username { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
