
using AutoMapper;
using MainProject.Application.Features.Branches.Dtos;
using MainProject.Application.Features.EducationLevels.Dtos;
using MainProject.Application.Features.Lessons.Dtos;
using MainProject.Application.Features.Postings.Dtos;
using MainProject.Application.Features.Roles.Dtos;
using MainProject.Application.Features.Users.Dtos;
using MainProject.Domain.Lessons;
using MainProject.Domain.Postings;
using MainProject.Domain.Users;

namespace MainProject.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Branch, BranchDto>();
            CreateMap<EducationLevel, EducationLevelDto>();
            CreateMap<Lesson, LessonDto>();
            CreateMap<Posting, PostingDto>();
            CreateMap<Role, RoleDto>();
        }
    }
}
