
using MediatR;
using System;

namespace MainProject.Application.Features.Branches.Commands.CreateBranch
{
    public class CreateBranchCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
