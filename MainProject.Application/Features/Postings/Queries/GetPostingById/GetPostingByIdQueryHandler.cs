
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

        public GetPostingByIdQueryHandler(IRepository<Posting> postingRepository)
        {
            _postingRepository = postingRepository;
        }

        public async Task<PostingDto> Handle(GetPostingByIdQuery request, CancellationToken cancellationToken)
        {
            var posting = await _postingRepository.GetByIdAsync(request.Id, cancellationToken);

            if (posting == null)
            {
                return null;
            }

            return new PostingDto
            {
                Id = posting.Id,
                Title = posting.Title,
                Content = posting.Content,
                LessonId = posting.LessonId,
                TeacherId = posting.TeacherId
            };
        }
    }

    public class PostingDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid LessonId { get; set; }
        public Guid TeacherId { get; set; }
    }
}
