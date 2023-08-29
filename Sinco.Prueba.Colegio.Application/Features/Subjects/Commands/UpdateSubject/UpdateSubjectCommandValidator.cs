using FluentValidation;
using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Application.Validations;

namespace Sinco.Prueba.Colegio.Application.Features.Subjects.Commands.UpdateSubject
{
    public class UpdateSubjectCommandValidator : AbstractValidator<UpdateSubjectCommand>
    {
        private readonly TeacherValidations _teacherValidations;
        private readonly SubjectValidations _subjectValidations;
        public UpdateSubjectCommandValidator(IUnitOfWork unitOfWork)
        {
            _teacherValidations = new TeacherValidations(unitOfWork);
            _subjectValidations = new SubjectValidations(unitOfWork);

            RuleFor(s => s.SubjectId).MustAsync(async (id, cancelation) =>
            {
                return await _subjectValidations.SubjectExists(id);
            }).WithMessage("{PropertyName} is not a valid id");
        }
    }
}
