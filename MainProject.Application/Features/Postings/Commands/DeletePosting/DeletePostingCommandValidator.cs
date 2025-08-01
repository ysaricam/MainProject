
using FluentValidation;
using System;

namespace MainProject.Application.Features.Postings.Commands.DeletePosting
{
    public class DeletePostingCommandValidator : AbstractValidator<DeletePostingCommand>
    {
        public DeletePostingCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
