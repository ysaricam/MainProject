

using AutoMapper;
using MainProject.Application.Features.Postings.Dtos;
using MainProject.Domain.Postings;
using MainProject.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.Application.Features.Postings.Queries.GetPostingById
{
    public class GetPostingByIdQueryHandler : IRequestHandler<GetPostingByIdQuery, PostingDto>
    {
        private readonly IRepository<Posting> _postingRepository;
        private readonly IMapper _mapper;

        public GetPostingByIdQueryHandler(IRepository<Posting> postingRepository, IMapper mapper)
        {
            _postingRepository = postingRepository;
            _mapper = mapper;
        }

        public async Task<PostingDto> Handle(GetPostingByIdQuery request, CancellationToken cancellationToken)
        {
            var posting = await _postingRepository.GetByIdAsync(request.Id, cancellationToken);

            if (posting == null)
            {
                return null;
            }

            return _mapper.Map<PostingDto>(posting);
        }
    }
}

