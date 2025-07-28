using MainProject.Application.Features.Users.Dtos;
using MediatR;
using System.Collections.Generic;

namespace MainProject.Application.Features.Users.Queries.GetAllUsers
{
    public record GetAllUsersQuery : IRequest<List<UserDto>>;
}
public class UserListDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}
