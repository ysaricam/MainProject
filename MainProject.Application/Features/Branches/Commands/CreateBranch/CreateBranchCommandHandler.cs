
using AutoMapper;
using MainProject.Domain.Lessons;
using MainProject.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.Application.Features.Branches.Commands.CreateBranch
{
    public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, Guid>
    {
        private readonly IRepository<Branch> _branchRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CreateBranchCommandHandler(IRepository<Branch> branchRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = _mapper.Map<Branch>(request);

            _branchRepository.Add(branch);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return branch.Id;
        }
    }
}
