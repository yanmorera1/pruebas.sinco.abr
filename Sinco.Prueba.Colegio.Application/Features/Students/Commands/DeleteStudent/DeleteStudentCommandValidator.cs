using FluentValidation;
using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Application.Validations;

namespace Sinco.Prueba.Colegio.Application.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
    {
        private readonly StudentValidations _studentValidations;

        public DeleteStudentCommandValidator(IUnitOfWork unitOfWork)
        {
            _studentValidations = new StudentValidations(unitOfWork);

            RuleFor(s => s.StudentId).MustAsync(async (id, cancelation) =>
            {
                return await _studentValidations.StudentExists(id);
            }).WithMessage("{PropertyName} is not a valid id");
        }
    }
}
