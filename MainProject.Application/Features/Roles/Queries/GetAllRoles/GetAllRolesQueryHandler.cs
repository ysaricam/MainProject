using MainProject.Application.Features.Roles.Dtos;
using MainProject.Domain.Users;
using MainProject.Domain.Interfaces;
using MediatR;

namespace MainProject.Application.Features.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<RoleDto>>
    {
        private readonly IRepository<Role> _roleRepository;

        public GetAllRolesQueryHandler(IRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<RoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository.GetAllAsync(cancellationToken);
            
            return roles.Select(r => new RoleDto 
            { 
                Id = r.Id, 
                Name = r.Name 
            }).ToList();
        }
    }
}
