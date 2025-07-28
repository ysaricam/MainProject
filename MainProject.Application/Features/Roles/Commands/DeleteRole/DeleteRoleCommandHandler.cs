using MainProject.Domain.Users;
using MainProject.Domain.Interfaces;
using MediatR;

namespace MainProject.Application.Features.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, bool>
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoleCommandHandler(IRepository<Role> roleRepository, IUnitOfWork unitOfWork)
        {
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetByIdAsync(request.Id, cancellationToken);
            if (role == null)
                return false;

            _roleRepository.Remove(role);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
