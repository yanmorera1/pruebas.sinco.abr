using MediatR;
using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Domain;

namespace Sinco.Prueba.Colegio.Application.Features.Subjects.Commands.AddSubject
{
    public class AddSubjectCommandHandler : IRequestHandler<AddSubjectCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddSubjectCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AddSubjectCommand request, CancellationToken cancellationToken)
        {
            var newSubject = new Subject(request.Code, request.Name, request.TeacherId);
            await _unitOfWork.Repository<Subject>().AddAsync(newSubject);
            return newSubject.Id;
        }
    }
}
