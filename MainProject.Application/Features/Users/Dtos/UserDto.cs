using System;

namespace MainProject.Application.Features.Users.Dtos
{
    public record UserDto
    {
        public Guid Id { get; init; }
        public string Username { get; init; }
        public string Email { get; init; }
    }
}
