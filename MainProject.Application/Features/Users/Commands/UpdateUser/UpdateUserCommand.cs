using MediatR;
using System;

namespace MainProject.Application.Features.Users.Commands.UpdateUser
{
    public record UpdateUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Username { get; init; }
        public string Email { get; init; }
        public string? Password { get; init; }
    }
}
