using MainProject.Application.Features.Branches.Dtos;
using MediatR;
using System.Collections.Generic;

namespace MainProject.Application.Features.Branches.Queries.GetAllBranches
{
    public record GetAllBranchesQuery : IRequest<List<BranchDto>>
    {
    }
}