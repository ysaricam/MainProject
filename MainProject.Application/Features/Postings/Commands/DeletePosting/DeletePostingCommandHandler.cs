using MainProject.Domain.Postings;
using MainProject.Domain.Interfaces;
using MediatR;

namespace MainProject.Application.Features.Postings.Commands.DeletePosting
{
    public class DeletePostingCommandHandler : IRequestHandler<DeletePostingCommand, bool>
    {
        private readonly IRepository<Posting> _postingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePostingCommandHandler(IRepository<Posting> postingRepository, IUnitOfWork unitOfWork)
        {
            _postingRepository = postingRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeletePostingCommand request, CancellationToken cancellationToken)
        {
            var posting = await _postingRepository.GetByIdAsync(request.Id, cancellationToken);
            if (posting == null)
                return false;

            _postingRepository.Remove(posting);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
