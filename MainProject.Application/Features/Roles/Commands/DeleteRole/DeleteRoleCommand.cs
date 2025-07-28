using MediatR;

namespace MainProject.Application.Features.Roles.Commands.DeleteRole
{
    public record DeleteRoleCommand : IRequest<bool>
    {
        public DeleteRoleCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
