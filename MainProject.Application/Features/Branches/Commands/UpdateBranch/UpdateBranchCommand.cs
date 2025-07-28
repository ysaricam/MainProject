using MediatR;

namespace MainProject.Application.Features.Branches.Commands.UpdateBranch
{
    public record UpdateBranchCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
