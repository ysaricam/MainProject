using MediatR;

namespace MainProject.Application.Features.Users.Commands.LoginUser
{
    public record LoginUserCommand : IRequest<string> // Returns a JWT token upon successful login
    {
        public string Username { get; init; }
        public string Password { get; init; }
    }
}
