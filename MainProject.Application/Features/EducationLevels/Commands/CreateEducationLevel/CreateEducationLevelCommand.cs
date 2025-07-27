
using MediatR;
using System;

namespace MainProject.Application.Features.EducationLevels.Commands.CreateEducationLevel
{
    public class CreateEducationLevelCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
