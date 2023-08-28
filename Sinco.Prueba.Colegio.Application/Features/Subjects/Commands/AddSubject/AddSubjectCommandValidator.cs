using FluentValidation;

namespace Sinco.Prueba.Colegio.Application.Features.Subjects.Commands.AddSubject
{
    public class AddSubjectCommandValidator : AbstractValidator<AddSubjectCommand>
    {
        public AddSubjectCommandValidator()
        {
            RuleFor(s => s.Name)
                .NotNull().WithMessage("{PropertyName} cannot be null")
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}
