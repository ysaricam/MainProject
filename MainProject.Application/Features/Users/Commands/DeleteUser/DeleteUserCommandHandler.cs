using MainProject.Domain.Users;
using MainProject.Domain.Interfaces;
using MediatR;

namespace MainProject.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var branchToDelete = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

            if (branchToDelete is null)
            {
                throw new Exception($"Branch with Id {request.Id} not found.");
            }

            _userRepository.Remove(branchToDelete);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
