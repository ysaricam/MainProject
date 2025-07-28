using MainProject.Application.Features.Users.Dtos;
using MainProject.Domain.Users;
using MainProject.Domain.Interfaces;
using MediatR;

namespace MainProject.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {
        private readonly IRepository<User> _userRepository;

        public GetAllUsersQueryHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync(cancellationToken);
            
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email
            }).ToList();
        }
    }
}
