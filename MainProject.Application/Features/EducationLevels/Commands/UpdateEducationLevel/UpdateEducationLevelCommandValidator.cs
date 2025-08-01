
using FluentValidation;

namespace MainProject.Application.Features.EducationLevels.Commands.UpdateEducationLevel
{
    public class UpdateEducationLevelCommandValidator : AbstractValidator<UpdateEducationLevelCommand>
    {
        public UpdateEducationLevelCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
        }
    }
}
