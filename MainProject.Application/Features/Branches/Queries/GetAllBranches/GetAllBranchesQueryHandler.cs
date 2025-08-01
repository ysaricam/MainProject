using AutoMapper;
using MainProject.Application.Features.Branches.Dtos;
using MainProject.Domain.Interfaces;
using MainProject.Domain.Lessons;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.Application.Features.Branches.Queries.GetAllBranches
{
    public class GetAllBranchesQueryHandler : IRequestHandler<GetAllBranchesQuery, List<BranchDto>>
    {
        private readonly IRepository<Branch> _branchRepository;
        private readonly IMapper _mapper;

        public GetAllBranchesQueryHandler(IRepository<Branch> branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<List<BranchDto>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            var branches = await _branchRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<BranchDto>>(branches);
        }
    }
}