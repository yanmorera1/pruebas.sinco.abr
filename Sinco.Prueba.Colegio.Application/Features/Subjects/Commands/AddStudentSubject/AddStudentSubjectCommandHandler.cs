using MediatR;
using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Domain;

namespace Sinco.Prueba.Colegio.Application.Features.Subjects.Commands.AddStudentSubject
{
    public class AddStudentSubjectCommandHandler : IRequestHandler<AddStudentSubjectCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddStudentSubjectCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AddStudentSubjectCommand request, CancellationToken cancellationToken)
        {
            var studentSubjects = await _unitOfWork.Repository<StudentSubject>().GetAsync(ss => ss.StudentId == request.StudentId);
            if (studentSubjects.Any(ss => ss.SubjectId == request.SubjectId && ss.CreatedAt.Value.Year == DateTime.Now.Year))
                throw new BadImageFormatException("No se puede registrar una materia repetida para este año escolar");
            var newStudentSubject = new StudentSubject(request.Rating, request.StudentId, request.SubjectId);
            await _unitOfWork.Repository<StudentSubject>().AddAsync(newStudentSubject);
            return newStudentSubject.Id;
        }
    }
}