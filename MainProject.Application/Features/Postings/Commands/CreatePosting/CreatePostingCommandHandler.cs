
using AutoMapper;
using MainProject.Domain.Postings;
using MainProject.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.Application.Features.Postings.Commands.CreatePosting
{
    public class CreatePostingCommandHandler : IRequestHandler<CreatePostingCommand, Guid>
    {
        private readonly IRepository<Posting> _postingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePostingCommandHandler(IRepository<Posting> postingRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _postingRepository = postingRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePostingCommand request, CancellationToken cancellationToken)
        {
            var posting = _mapper.Map<Posting>(request);

            _postingRepository.Add(posting);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return posting.Id;
        }
    }
}

