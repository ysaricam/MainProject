
using FluentValidation;
using System;

namespace MainProject.Application.Features.Lessons.Commands.AddEducationLevel
{
    public class AddEducationLevelToLessonCommandValidator : AbstractValidator<AddEducationLevelToLessonCommand>
    {
        public AddEducationLevelToLessonCommandValidator()
        {
            RuleFor(x => x.LessonId)
                .NotEmpty().WithMessage("LessonId is required.");

            RuleFor(x => x.EducationLevelId)
                .NotEmpty().WithMessage("EducationLevelId is required.");
        }
    }
}
