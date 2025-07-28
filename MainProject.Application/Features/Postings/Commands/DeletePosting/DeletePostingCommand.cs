using MediatR;

namespace MainProject.Application.Features.Postings.Commands.DeletePosting
{
    public record DeletePostingCommand(Guid Id) : IRequest<bool>;
}
