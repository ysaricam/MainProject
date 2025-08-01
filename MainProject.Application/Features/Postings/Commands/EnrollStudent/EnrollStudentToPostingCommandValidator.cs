
using FluentValidation;
using System;

namespace MainProject.Application.Features.Postings.Commands.EnrollStudent
{
    public class EnrollStudentToPostingCommandValidator : AbstractValidator<EnrollStudentToPostingCommand>
    {
        public EnrollStudentToPostingCommandValidator()
        {
            RuleFor(x => x.PostingId)
                .NotEmpty().WithMessage("PostingId is required.");

            RuleFor(x => x.StudentId)
                .NotEmpty().WithMessage("StudentId is required.");
        }
    }
}
