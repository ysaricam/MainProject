
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

        public CreatePostingCommandHandler(IRepository<Posting> postingRepository, IUnitOfWork unitOfWork)
        {
            _postingRepository = postingRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreatePostingCommand request, CancellationToken cancellationToken)
        {
            var posting = new Posting
            {
                Title = request.Title,
                Content = request.Content,
                Capacity = request.Capacity,
                LessonId = request.LessonId,
                TeacherId = request.TeacherId
            };

            _postingRepository.Add(posting);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return posting.Id;
        }
    }
}

