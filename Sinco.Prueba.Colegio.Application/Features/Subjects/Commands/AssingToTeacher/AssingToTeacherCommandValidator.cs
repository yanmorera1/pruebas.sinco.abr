using FluentValidation;
using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Application.Validations;

namespace Sinco.Prueba.Colegio.Application.Features.Subjects.Commands.AssingToTeacher
{
    public class AssingToTeacherCommandValidator : AbstractValidator<AssingToTeacherCommand>
    {
        private readonly TeacherValidations _teacherValidations;
        private readonly SubjectValidations _subjectValidations;
        public AssingToTeacherCommandValidator(IUnitOfWork unitOfWork)
        {
            _teacherValidations = new TeacherValidations(unitOfWork);
            _subjectValidations = new SubjectValidations(unitOfWork);

            RuleFor(s => s.TeacherId).MustAsync(async (id, cancelation) =>
            {
                return await _teacherValidations.TeacherExists(id);
            }).WithMessage("{PropertyName} is not a valid id");

            RuleFor(s => s.SubjectId).MustAsync(async (id, cancelation) =>
            {
                return await _subjectValidations.SubjectExists(id);
            }).WithMessage("{PropertyName} is not a valid id");
        }
    }
}
