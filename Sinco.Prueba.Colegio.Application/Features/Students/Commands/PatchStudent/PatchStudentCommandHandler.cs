using AutoMapper;
using MediatR;
using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;
using Sinco.Prueba.Colegio.Domain;

namespace Sinco.Prueba.Colegio.Application.Features.Students.Commands.PatchStudent
{
    public class PatchStudentCommandHandler : IRequestHandler<PatchStudentCommand, StudentVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatchStudentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<StudentVm> Handle(PatchStudentCommand request, CancellationToken cancellationToken)
        {
            var studentUpdated = await _unitOfWork.Repository<Student>().PatchAync(request.StudentId, request.StudentPatch);
            return _mapper.Map<StudentVm>(studentUpdated);
        }
    }
}
