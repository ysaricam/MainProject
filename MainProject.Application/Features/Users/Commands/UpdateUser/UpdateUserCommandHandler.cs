using MainProject.Domain.Users;
using MainProject.Domain.Interfaces;
using MediatR;

namespace MainProject.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
                return false;

            user.Username = request.Username;
            user.Email = request.Email;

            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
