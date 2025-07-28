
using MainProject.Application.Features.Branches.Dtos;
using MediatR;
using System;

namespace MainProject.Application.Features.Branches.Queries.GetBranchById
{
    public record GetBranchByIdQuery : IRequest<BranchDto>
    {
        public Guid Id { get; set; }
    }
}
