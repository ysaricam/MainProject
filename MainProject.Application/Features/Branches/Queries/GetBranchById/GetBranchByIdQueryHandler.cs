
using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetBranchByIdQueryHandler(IRepository<Branch> branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<BranchDto> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.GetByIdAsync(request.Id, cancellationToken);

            if (branch == null)
            {
                return null;
            }

            return _mapper.Map<BranchDto>(branch);
        }
    }
}
