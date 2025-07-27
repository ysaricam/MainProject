
using MainProject.Domain.Users;
using MainProject.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.Application.Features.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleDto>
    {
        private readonly IRepository<Role> _roleRepository;

        public GetRoleByIdQueryHandler(IRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetByIdAsync(request.Id, cancellationToken);

            if (role == null)
            {
                return null;
            }

            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }

    public class RoleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
