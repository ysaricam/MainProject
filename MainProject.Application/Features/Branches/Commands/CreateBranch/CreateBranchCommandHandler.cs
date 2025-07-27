
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


        public CreateBranchCommandHandler(IRepository<Branch> branchRepository, IUnitOfWork unitOfWork)
        {
            _branchRepository = branchRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = new Branch
            {
                Name = request.Name,
                Description = request.Description
            };

            _branchRepository.Add(branch);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return branch.Id;
        }
    }
}
