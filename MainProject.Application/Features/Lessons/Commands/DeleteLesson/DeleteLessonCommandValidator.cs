
using FluentValidation;
using System;

namespace MainProject.Application.Features.Lessons.Commands.DeleteLesson
{
    public class DeleteLessonCommandValidator : AbstractValidator<DeleteLessonCommand>
    {
        public DeleteLessonCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
