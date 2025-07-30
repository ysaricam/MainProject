using MainProject.Domain.Users;
using MainProject.Domain.Interfaces;
using MediatR;
using BCrypt.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IRepository<User> _userRepository;

        public LoginUserCommandHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Note: This is a simplified implementation. In a real application, you would also handle user not found scenarios.
            var user = await _userRepository.GetByUsernameAsync(request.Username, cancellationToken); 

            if (user != null && BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                // Note: Implement JWT token generation here.
                return "Login successful"; 
            }

            return "Invalid username or password";
        }
    }
}
