using FluentValidation;
using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Application.Validations;

namespace Sinco.Prueba.Colegio.Application.Features.Teachers.Commands.PatchTeacher
{
    public class PatchTeacherCommandValidator : AbstractValidator<PatchTeacherCommand>
    {
        private readonly TeacherValidations _teacherValidations;
        public PatchTeacherCommandValidator(IUnitOfWork unitOfWork)
        {
            _teacherValidations = new TeacherValidations(unitOfWork);

            RuleFor(s => s.TeacherId).MustAsync(async (id, cancelation) =>
            {
                return await _teacherValidations.TeacherExists(id);
            }).WithMessage("{PropertyName} is not a valid id");
        }
    }
}
