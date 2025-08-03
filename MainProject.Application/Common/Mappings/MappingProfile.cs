using AutoMapper;
using MainProject.Application.Features.Users.Commands.CreateUser;
using MainProject.Application.Features.Roles.Commands.CreateRole;
using MainProject.Domain.Users;

namespace MainProject.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            
            CreateMap<CreateRoleCommand, Role>();
        }
    }
}
