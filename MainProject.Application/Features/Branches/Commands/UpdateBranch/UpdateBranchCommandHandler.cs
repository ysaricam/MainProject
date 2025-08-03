
using AutoMapper;
using MainProject.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using MainProject.Domain.Lessons;

namespace MainProject.Application.Features.Branches.Commands.UpdateBranch
{
    public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, bool>
    {
        private readonly IRepository<Branch> _branchRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBranchCommandHandler(IRepository<Branch> branchRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.GetByIdAsync(request.Id);
            if (branch == null)
            {
                return false;
            }

            _mapper.Map(request, branch);

            _branchRepository.Update(branch);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
