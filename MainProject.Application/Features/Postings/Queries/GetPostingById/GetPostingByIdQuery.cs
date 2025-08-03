
using MainProject.Application.Features.Postings.Dtos;
using MediatR;
using System;

namespace MainProject.Application.Features.Postings.Queries.GetPostingById
{
    public class GetPostingByIdQuery : IRequest<PostingDto>
    {
        public Guid Id { get; set; }
    }
}
