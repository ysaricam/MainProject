using MediatR;
using System;

namespace MainProject.Application.Features.Postings.Commands.EnrollStudent;

public class EnrollStudentToPostingCommand : IRequest<bool>
{
    public Guid PostingId { get; set; }
    public Guid StudentId { get; set; }
}