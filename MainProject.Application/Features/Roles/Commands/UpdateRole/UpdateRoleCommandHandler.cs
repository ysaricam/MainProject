using MainProject.Domain.Users;
using MainProject.Domain.Interfaces;
using MediatR;

namespace MainProject.Application.Features.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, bool>
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRoleCommandHandler(IRepository<Role> roleRepository, IUnitOfWork unitOfWork)
        {
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetByIdAsync(request.Id, cancellationToken);
            if (role == null)
                return false;

            role.Name = request.Name;

            _roleRepository.Update(role);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
