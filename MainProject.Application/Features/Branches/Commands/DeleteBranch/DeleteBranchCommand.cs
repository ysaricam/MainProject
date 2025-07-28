using MediatR;
using System;

namespace MainProject.Application.Features.Branches.Commands.DeleteBranch
{
    public record DeleteBranchCommand(Guid Id) : IRequest;

}
