using MainProject.Domain.Interfaces;
using MainProject.Domain.Lessons;
using MediatR;
using System;

namespace MainProject.Application.Features.Branches.Commands.DeleteBranch
{
    public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand>
    {
        private readonly IRepository<Branch> _branchRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBranchCommandHandler(IRepository<Branch> branchRepository, IUnitOfWork unitOfWork)
        {
            _branchRepository = branchRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var branchToDelete = await _branchRepository.GetByIdAsync(request.Id, cancellationToken);

            if (branchToDelete is null)
            {
                throw new Exception($"Branch with Id {request.Id} not found.");
            }

            _branchRepository.Remove(branchToDelete);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }   
}
