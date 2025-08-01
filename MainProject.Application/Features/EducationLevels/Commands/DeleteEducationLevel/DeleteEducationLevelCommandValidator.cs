
using FluentValidation;
using System;

namespace MainProject.Application.Features.EducationLevels.Commands.DeleteEducationLevel
{
    public class DeleteEducationLevelCommandValidator : AbstractValidator<DeleteEducationLevelCommand>
    {
        public DeleteEducationLevelCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
