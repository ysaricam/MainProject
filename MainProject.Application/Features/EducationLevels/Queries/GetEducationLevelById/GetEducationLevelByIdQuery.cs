
using MediatR;
using System;

namespace MainProject.Application.Features.EducationLevels.Queries.GetEducationLevelById
{
    public class GetEducationLevelByIdQuery : IRequest<EducationLevelDto>
    {
        public Guid Id { get; set; }
    }
}
