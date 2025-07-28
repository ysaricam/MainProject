using MainProject.Application.Features.Users.Dtos;
using MediatR;
using System;

namespace MainProject.Application.Features.Users.Queries.GetUserById
{
    public record GetUserByIdQuery : IRequest<UserDto>
    {
        public Guid Id { get; init; }
    }
}
