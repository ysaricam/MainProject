
using FluentValidation;

namespace MainProject.Application.Features.EducationLevels.Commands.CreateEducationLevel
{
    public class CreateEducationLevelCommandValidator : AbstractValidator<CreateEducationLevelCommand>
    {
        public CreateEducationLevelCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
        }
    }
}
