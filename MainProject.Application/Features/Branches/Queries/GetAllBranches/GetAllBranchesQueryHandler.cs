using MainProject.Application.Features.Branches.Dtos;
using MainProject.Domain.Interfaces;
using MainProject.Domain.Lessons;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.Application.Features.Branches.Queries.GetAllBranches
{
    public class GetAllBranchesQueryHandler : IRequestHandler<GetAllBranchesQuery, List<BranchDto>>
    {
        private readonly IRepository<Branch> _branchRepository;

        public GetAllBranchesQueryHandler(IRepository<Branch> branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<List<BranchDto>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            var branches = await _branchRepository.GetAllAsync(cancellationToken);
            return branches.Select(b => new BranchDto
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description
            }).ToList();
        }
    }
}