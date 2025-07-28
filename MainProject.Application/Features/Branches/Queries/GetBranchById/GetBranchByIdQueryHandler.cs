using MainProject.Application.Features.Branches.Dtos;
using MainProject.Domain.Interfaces;
using MainProject.Domain.Lessons;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.Application.Features.Branches.Queries.GetBranchById
{
    public class GetBranchByIdQueryHandler : IRequestHandler<GetBranchByIdQuery, BranchDto>
    {
        private readonly IRepository<Branch> _branchRepository;

        public GetBranchByIdQueryHandler(IRepository<Branch> branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<BranchDto> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.GetByIdAsync(request.Id, cancellationToken);

            if (branch == null)
            {
                return null;
            }

            return new BranchDto
            {
                Id = branch.Id,
                Name = branch.Name,
                Description = branch.Description
            };
        }
    }
}