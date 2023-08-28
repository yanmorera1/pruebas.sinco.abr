using MediatR;
using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Application.Exceptions;
using Sinco.Prueba.Colegio.Domain;

namespace Sinco.Prueba.Colegio.Application.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStudentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.Repository<Student>()
                .GetFirstOrDefaultAsync(s => s.Id == request.StudentId, s => s.StudentSubjects);

            if (student.StudentSubjects.Any())
                throw new BadRequestException("No se puede eliminar un estudiante con asignaturas");

            student.Deactivate();
            await _unitOfWork.Complete();

            return true;
        }
    }
}
