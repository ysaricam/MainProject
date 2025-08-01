
using FluentValidation;

namespace MainProject.Application.Features.Postings.Commands.CreatePosting
{
    public class CreatePostingCommandValidator : AbstractValidator<CreatePostingCommand>
    {
        public CreatePostingCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.");

            RuleFor(x => x.Capacity)
                .GreaterThan(0).WithMessage("Capacity must be greater than 0.");

            RuleFor(x => x.LessonId)
                .NotEmpty().WithMessage("LessonId is required.");

            RuleFor(x => x.TeacherId)
                .NotEmpty().WithMessage("TeacherId is required.");
        }
    }
}
