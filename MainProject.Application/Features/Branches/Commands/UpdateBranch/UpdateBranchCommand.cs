using MediatR;
using System;

namespace MainProject.Application.Features.Branches.Commands.UpdateBranch
{
    public record UpdateBranchCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; init; }
        public string Description { get; init; }
    }
}
