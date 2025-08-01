
using FluentValidation;

namespace MainProject.Application.Features.Postings.Commands.UpdatePosting
{
    public class UpdatePostingCommandValidator : AbstractValidator<UpdatePostingCommand>
    {
        public UpdatePostingCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.");

            RuleFor(x => x.LessonId)
                .NotEmpty().WithMessage("LessonId is required.");
        }
    }
}
