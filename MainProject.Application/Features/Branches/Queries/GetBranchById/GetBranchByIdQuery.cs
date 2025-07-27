
using MediatR;
using System;

namespace MainProject.Application.Features.Branches.Queries.GetBranchById
{
    public class GetBranchByIdQuery : IRequest<BranchDto>
    {
        public Guid Id { get; set; }
    }
}
