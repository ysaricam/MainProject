
using MainProject.Domain.Users;
using MainProject.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BCrypt.Net;
using System;

namespace MainProject.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUserByUsername = await _userRepository.GetByUsernameAsync(request.Username, cancellationToken);
            if (existingUserByUsername != null)
            {
                throw new InvalidOperationException("The specified username already exists.");
            }

            var isEmailUnique = await _userRepository.IsEmailUniqueAsync(request.Email, cancellationToken);
            if (!isEmailUnique)
            {
                throw new InvalidOperationException("The specified email already exists.");
            }

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            _userRepository.Add(user);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
    }
}
