using MainProject.Application.Features.Postings.Dtos;
using MediatR;

namespace MainProject.Application.Features.Postings.Queries.GetAllPostings
{
    public record GetAllPostingsQuery : IRequest<List<PostingDto>>;
}
